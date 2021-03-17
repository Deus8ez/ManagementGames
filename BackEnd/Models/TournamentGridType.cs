using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Tournament grid type")]
    public partial class TournamentGridType
    {
        public TournamentGridType()
        {
            Tournaments = new HashSet<Tournament>();
        }

        [Key]
        [Column("Grid ID")]
        public int GridId { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [InverseProperty(nameof(Tournament.TournamentGrid))]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
