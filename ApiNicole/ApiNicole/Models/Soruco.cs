using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiNicole.Models
{
    public enum CategoryType
    {
        centro=10,
        norte=20,
        sur=30,
        urubo=40,
        palmas=50,

    }
    public class Soruco
    {
        [Key]
        public int SorucoID { get; set; }

        [StringLength(24,ErrorMessage ="debe contener entre 2 a 24 caracteres",MinimumLength =2)]
        [Required(ErrorMessage ="debe ingresar este campo")]
        [Display(Name ="nombre completo")]
        public string FriendofSoruco { get; set; }
        
        [Required(ErrorMessage ="debe ingresar la categoria del tipo")]
        public CategoryType Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="cumpleaños")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Birthdayt { get; set; }


    }
}