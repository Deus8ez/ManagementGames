using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace BackEnd.Models
{
    [Table("Tournament")]
    [Index(nameof(Date), nameof(TournamentLocationId), Name = "IX_Турниры", IsUnique = true)]
    public partial class Tournament 
    {
        public Tournament()
        {
            JuryInPanels = new HashSet<JuryInPanel>();
            ParticipantInTournaments = new HashSet<ParticipantInTournament>();
        }

        [Key]
        [Column("Tournament ID")]
        public int TournamentId { get; set; }
        [Required]
        [Column("Tournament name")]
        [StringLength(200)]
        public string TournamentName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("Start time")]
        [StringLength(6)]
        public string StartTime { get; set; }
        [Column("End time")]
        [StringLength(6)]
        public string EndTime { get; set; }
        [Column("Tournament format ID")]
        public int TournamentFormatId { get; set; }
        [Column("Tournament type ID")]
        public int TournamentTypeId { get; set; }
        [Column("Tournament location ID")]
        public int TournamentLocationId { get; set; }
        [Column("Tournament grid ID")]
        public int TournamentGridId { get; set; }

        [ForeignKey(nameof(TournamentFormatId))]
        [InverseProperty("Tournaments")]
        public virtual TournamentFormat TournamentFormat { get; set; }
        [ForeignKey(nameof(TournamentGridId))]
        [InverseProperty(nameof(TournamentGridType.Tournaments))]
        public virtual TournamentGridType TournamentGrid { get; set; }
        [ForeignKey(nameof(TournamentLocationId))]
        [InverseProperty(nameof(Location.Tournaments))]
        public virtual Location TournamentLocation { get; set; }
        [ForeignKey(nameof(TournamentTypeId))]
        [InverseProperty("Tournaments")]
        public virtual TournamentType TournamentType { get; set; }
        [InverseProperty(nameof(JuryInPanel.TournamentWithJury))]
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        [InverseProperty(nameof(ParticipantInTournament.TournamentWithParticipant))]
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }
    }
}
