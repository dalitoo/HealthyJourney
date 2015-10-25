using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        [Display(Name = "username")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPAssword { get; set; }

        public bool IsApproved { get; set; }
        public string Thumbnail { get; set; }
    }
}
