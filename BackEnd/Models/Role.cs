using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            ParticipantInTournaments = new HashSet<ParticipantInTournament>();
        }

        [Key]
        [Column("Role ID")]
        public int RoleId { get; set; }
        [Required]
        [Column("Role")]
        [StringLength(30)]
        public string Role1 { get; set; }

        [InverseProperty(nameof(ParticipantInTournament.ParticpantRole))]
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }
    }
}
