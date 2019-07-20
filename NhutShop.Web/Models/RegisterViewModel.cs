using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NhutShop.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tên")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập password")]
        [MinLength(6,ErrorMessage ="Password phải có ít nhất 6 ký tự")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập lại password.")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must match.")]
        public string ConfirmPassword { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập enail")]
        [EmailAddress(ErrorMessage ="Địa chỉ Email không hợp lệ")]
        public string Email { set; get; }
        public string Address { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập SDT")]
        public string PhoneNumber { set; get; }
    }
}