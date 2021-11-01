using ETickets.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        public string Description { get; set; }

        public List<Actor_Movie> Actor_Movie { get; set; }
    }
}
