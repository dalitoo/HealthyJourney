using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Domain.Entities
{
    //[Table("ServiceProvider")]
    public abstract class ServiceProvider : User
    {

        public string Name { get; set; }

        public Adress Adress { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        virtual public IEnumerable<Speciality> Specialities { get; set; }

        virtual public Badge badge { get; set; }
    }
}
