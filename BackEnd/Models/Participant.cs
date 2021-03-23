using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Participant")]
    [Index(nameof(DateOfBirth), nameof(Name), nameof(Surname), nameof(Patronym), Name = "IX_Участники", IsUnique = true)]
    public partial class Participant 
    {
        public Participant()
        {
            JuryInPanels = new HashSet<JuryInPanel>();
            ParticipantInTournaments = new HashSet<ParticipantInTournament>();
        }

        [Key]
        [Column("Participant ID")]
        public int ParticipantId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [StringLength(20)]
        public string Patronym { get; set; }
        [Column("Date of birth", TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        [Column("Classic game rank")]
        [StringLength(20)]
        public string ClassicGameRank { get; set; }
        [Column("Blitz game rank")]
        [StringLength(20)]
        public string BlitzGameRank { get; set; }
        [Column("Can be a jury")]
        public bool CanBeAJury { get; set; }
        public string RoleName { get; set; }
        public string SchoolName { get; set; }
        [InverseProperty("ParticipantInSchoolNavigation")]
        public virtual ParticipantInSchool ParticipantInSchool { get; set; }
        [InverseProperty(nameof(JuryInPanel.JuryParticipant))]
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        [InverseProperty(nameof(ParticipantInTournament.ParticipantInTournamentNavigation))]
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }
    }
}
