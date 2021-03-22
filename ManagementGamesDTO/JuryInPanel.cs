using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagementGamesDTO
{
    [Table("Jury in panel")]
    //[Index(nameof(JuryPanelId), nameof(JuryParticipantId), nameof(TournamentWithJuryId), Name = "IX_Судьи в коллегиях", IsUnique = true)]
    public partial class JuryInPanel
    {
        [Key]
        [Column("Jury in panel ID")]
        public int JuryInPanelId { get; set; }
        [Column("Tournament with jury ID")]
        public int TournamentWithJuryId { get; set; }
        [Column("Jury-participant ID")]
        public int JuryParticipantId { get; set; }
        [Column("Jury panel ID")]
        public int? JuryPanelId { get; set; }

        [ForeignKey(nameof(JuryPanelId))]
        [InverseProperty("JuryInPanels")]
        public virtual JuryPanel JuryPanel { get; set; }
        [ForeignKey(nameof(JuryParticipantId))]
        [InverseProperty(nameof(Participant.JuryInPanels))]
        public virtual Participant JuryParticipant { get; set; }
        [ForeignKey(nameof(TournamentWithJuryId))]
        [InverseProperty(nameof(Tournament.JuryInPanels))]
        public virtual Tournament TournamentWithJury { get; set; }
    }
}
