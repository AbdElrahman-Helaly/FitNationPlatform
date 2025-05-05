using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitNationApplication.DTOS
{
    public class RegisterReqDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)] public string PhoneNumber { get; set; }

        public int Age {  get; set; }

        public string Status { get; set; }  
        public int StatusCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    

    }

}
