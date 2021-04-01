using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Country")]
    public class Country
    {
        public Country() => this.States = new List<State>();

        public string CountryName { get; set; }

        [Key]
        public int CountryId { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
