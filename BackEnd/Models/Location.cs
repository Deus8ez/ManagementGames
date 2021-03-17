using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Tournaments = new HashSet<Tournament>();
        }

        [Key]
        [Column("Location ID")]
        public int LocationId { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [InverseProperty(nameof(Tournament.TournamentLocation))]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
