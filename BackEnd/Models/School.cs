using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("School")]
    public partial class School
    {
        [Key]
        [Column("School ID")]
        public int SchoolId { get; set; }
        [Required]
        [Column("School")]
        [StringLength(100)]
        public string School1 { get; set; }
    }
}
