using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace weiapi练习.Models
{
    [Table("StaffTable")]
    public partial class StaffTable
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Nickname { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(200)]
        public string ImgURL { get; set; }
    }
}