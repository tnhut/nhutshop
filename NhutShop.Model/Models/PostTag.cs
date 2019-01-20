using NhutShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Model.Models
{
   [Table("PostTags")]
    public class PostTag : Auditable
    {
        [Key]
        [Column(Order=1)]
        public int PostID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order =2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }

    }
}
