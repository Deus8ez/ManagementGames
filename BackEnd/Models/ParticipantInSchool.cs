using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Keyless]
    [Table("Participant in school")]
    [Index(nameof(ParticipantInSchoolId), Name = "IX_Участники в школах", IsUnique = true)]
    public partial class ParticipantInSchool
    {
        [Column("Participant in school ID")]
        public int ParticipantInSchoolId { get; set; }
        [Column("Participant school ID")]
        public int? ParticipantSchoolId { get; set; }

        [ForeignKey(nameof(ParticipantInSchoolId))]
        public virtual Participant ParticipantInSchoolNavigation { get; set; }
        [ForeignKey(nameof(ParticipantSchoolId))]
        public virtual School ParticipantSchool { get; set; }
    }
}
