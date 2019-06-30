using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NhutShop.Web.Models
{
    public class ContactDetailViewModel
    {
        [Required]       
        public string Name { set; get; }

        [MaxLength(50, ErrorMessage="So dien thoai ko dc vuot qua 50")]
        public string Phone { set; get; }

        [MaxLength(250, ErrorMessage = "Email ko dc vuot qua 250")]
        public string Email { set; get; }

        [MaxLength(250, ErrorMessage = "Website ko dc vuot qua 250")]
        public string Website { set; get; }

        [MaxLength(250, ErrorMessage = "Address ko dc vuot qua 250")]
        public string Address { set; get; }

        public string Other { set; get; }

        public double? Lat { set; get; }

        public double? Lng { set; get; }

        public bool Status { set; get; }
    }
}