using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("Participant in school")]
    [Index(nameof(ParticipantInSchoolId), Name = "IX_Участники в школах", IsUnique = true)]
    public partial class ParticipantInSchool
    {
        [Key]
        [Column("School participant ID")]
        public int SchoolParticipantId { get; set; }
        [Column("Participant in school ID")]
        public int ParticipantInSchoolId { get; set; }
        [Column("Participant school ID")]
        public int? ParticipantSchoolId { get; set; }

        [ForeignKey(nameof(ParticipantInSchoolId))]
        [InverseProperty(nameof(Participant.ParticipantInSchool))]
        public virtual Participant ParticipantInSchoolNavigation { get; set; }
        [ForeignKey(nameof(ParticipantSchoolId))]
        [InverseProperty(nameof(School.ParticipantInSchools))]
        public virtual School ParticipantSchool { get; set; }
    }
}
