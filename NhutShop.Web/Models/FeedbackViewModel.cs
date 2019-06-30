using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NhutShop.Web.Models
{
    public class FeedbackViewModel
    {
        [MaxLength(250,ErrorMessage ="Tên ko dc vuot qua 250")]
        [Required(ErrorMessage ="Ten ko dc để trống")]
        public string Name { set; get; }

        [MaxLength(250, ErrorMessage = "Email ko dc vuot qua 250")]
        public string Email { set; get; }

        [MaxLength(500, ErrorMessage = "Message ko dc vuot qua 500")]
        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required(ErrorMessage ="Phải nhập trạng thái")]
        public bool Status { set; get; }

        public ContactDetailViewModel ContactDetail { set; get; }
    }
}