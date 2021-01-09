using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GropProject3.Models
{
    [Table("User")]
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Column("Username")]
        [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; }

        [Column("Password")]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Write valid Email")]
        public string Email { get; set; }

        [Column("Phone")]
        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage = "Write valid Phone Number")]
        public string Phone { get; set; }


        [ForeignKey("UserType")]
        public int UserType { get; set; }



      

       
    }
}
