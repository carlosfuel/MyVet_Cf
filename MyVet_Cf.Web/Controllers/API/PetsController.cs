﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using MyVet_Cf.Web.Data;
using MyVet_Cf.Web.Data.Entities;
using MyVet_Cf.Web.Helpers;

namespace MyVet_Cf.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PetsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IConverterHelper _converterHelper;

        public PetsController(
            DataContext dataContext,
            IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostPet([FromBody] PetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _dataContext.Owners.FindAsync(request.OwnerId);
            if (owner == null)
            {
                return BadRequest("Propietario no válido");
            }

            var petType = await _dataContext.PetTypes.FindAsync(request.PetTypeId);
            if (petType == null)
            {
                return BadRequest("Tipo de mascota no válido");
            }

            var imageUrl = string.Empty;
            if (request.ImageArray != null && request.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(request.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "wwwroot\\images\\Pets";
                var fullPath = $"~/images/Pets/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    imageUrl = fullPath;
                }
            }

            var pet = new Pet
            {
                Born = request.Born.ToUniversalTime(),
                ImageUrl = imageUrl,
                Name = request.Name,
                Owner = owner,
                PetType = petType,
                Race = request.Race,
                Remarks = request.Remarks
            };

            _dataContext.Pets.Add(pet);
            await _dataContext.SaveChangesAsync();
            return Ok(_converterHelper.ToPetResponse(pet));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet([FromRoute] int id, [FromBody] PetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            var oldPet = await _dataContext.Pets.FindAsync(request.Id);
            if (oldPet == null)
            {
                return BadRequest("La Mascota no existe");
            }

            var petType = await _dataContext.PetTypes.FindAsync(request.PetTypeId);
            if (petType == null)
            {
                return BadRequest("Tipo de mascota no válido");
            }

            var imageUrl = oldPet.ImageUrl;
            if (request.ImageArray != null && request.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(request.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "wwwroot\\images\\Pets";
                var fullPath = $"~/images/Pets/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    imageUrl = fullPath;
                }
            }

            oldPet.Born = request.Born.ToUniversalTime();
            oldPet.ImageUrl = imageUrl;
            oldPet.Name = request.Name;
            oldPet.PetType = petType;
            oldPet.Race = request.Race;
            oldPet.Remarks = request.Remarks;

            _dataContext.Pets.Update(oldPet);
            await _dataContext.SaveChangesAsync();
            return Ok(_converterHelper.ToPetResponse(oldPet));
        }
    }
}

