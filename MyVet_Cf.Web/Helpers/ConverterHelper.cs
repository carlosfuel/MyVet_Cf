using MyVet_Cf.Web.Data;
using MyVet_Cf.Web.Data.Entities;
using MyVet_Cf.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Tutorial 58 - part 15 - Add Pet
namespace MyVet_Cf.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Pet> ToPetAsync(PetViewModel model, string path)
        {
            return new Pet
            {
                Agendas = model.Agendas,
                Born = model.Born,
                Histories = model.Histories,
                //Id = model.Id == 0 ? null: model.Id,
                ImageUrl = path,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Race = model.Race,
                Remarks = model.Remarks
            };
        }

    }
}
