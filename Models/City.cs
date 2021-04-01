using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }

        public int? Population { get; set; }
    }
}
