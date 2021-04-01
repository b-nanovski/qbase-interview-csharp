using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("State")]
    public class State
    {
        public State() => this.Cities = new List<City>();

        [Key]
        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
