using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet_Cf.Common.Models
{
    public class AgendaResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public OwnerResponse Owner { get; set; }

        public PetResponse Pet { get; set; }

        public string Remarks { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();
    }

}
