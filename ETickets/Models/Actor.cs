using ETickets.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="ProfilePicture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name is most be between 3 and 50 characters")]

        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]

        public string Bio { get; set; }
        public List<Actor_Movie> Actor_Movie { get; set; }


    }
}
