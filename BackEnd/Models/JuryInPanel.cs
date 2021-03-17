using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Keyless]
    [Table("Jury in panel")]
    [Index(nameof(JuryPanelId), nameof(JuryParticipantId), nameof(TournamentWithJuryId), Name = "IX_Судьи в коллегиях", IsUnique = true)]
    public partial class JuryInPanel
    {
        [Column("Tournament with jury ID")]
        public int TournamentWithJuryId { get; set; }
        [Column("Jury-participant ID")]
        public int JuryParticipantId { get; set; }
        [Column("Jury panel ID")]
        public int? JuryPanelId { get; set; }

        [ForeignKey(nameof(JuryPanelId))]
        public virtual JuryPanel JuryPanel { get; set; }
        [ForeignKey(nameof(JuryParticipantId))]
        public virtual Participant JuryParticipant { get; set; }
        [ForeignKey(nameof(TournamentWithJuryId))]
        public virtual Tournament TournamentWithJury { get; set; }
    }
}
