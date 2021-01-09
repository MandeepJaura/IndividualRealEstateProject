using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GropProject3.Models
{
    [Table("HomeListing")]
    public class HomeListing
    {
        [Key]
        public int Id { get; set; }

        [Column("HomeType")]
        [Required(ErrorMessage = "Home Type is Required")]
        public string HomeType { get; set; }

        [Column("Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Column("City")]
        [Required(ErrorMessage = "City Name is Required")]
        public string City { get; set; }

        [Column("Price")]
        [Required(ErrorMessage = "Price is Required")]
        public int Price { get; set; }

        [Column("YearlyTax")]
        [Required(ErrorMessage = "Yearly Tax is Required")]
        public int YearlyTax { get; set; }

        [Column("HomeSize")]
        [Required(ErrorMessage = "Home Size is Required")]
        public string HomeSize { get; set; }

        [Column("Summary")]
        [Required(ErrorMessage = "Summary is Required")]
        public string Summary { get; set; }

        [ForeignKey("AgentId")]
        public int AgentId { get; set; }
        
    }
}
