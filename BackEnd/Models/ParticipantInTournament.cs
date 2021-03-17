using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Participant in tournament")]
    [Index(nameof(ParticpantRoleId), nameof(ParticipantInTournamentId), nameof(TournamentWithParticipantId), Name = "IX_Участники в турнирах", IsUnique = true)]
    public partial class ParticipantInTournament
    {
        [Key]
        [Column("Tournament with participant ID")]
        public int TournamentWithParticipantId { get; set; }
        [Key]
        [Column("Participant in tournament ID")]
        public int ParticipantInTournamentId { get; set; }
        [Column("Particpant role ID")]
        public int? ParticpantRoleId { get; set; }

        [ForeignKey(nameof(ParticipantInTournamentId))]
        [InverseProperty(nameof(Participant.ParticipantInTournaments))]
        public virtual Participant ParticipantInTournamentNavigation { get; set; }
        [ForeignKey(nameof(ParticpantRoleId))]
        [InverseProperty(nameof(Role.ParticipantInTournaments))]
        public virtual Role ParticpantRole { get; set; }
        [ForeignKey(nameof(TournamentWithParticipantId))]
        [InverseProperty(nameof(Tournament.ParticipantInTournaments))]
        public virtual Tournament TournamentWithParticipant { get; set; }
    }
}
