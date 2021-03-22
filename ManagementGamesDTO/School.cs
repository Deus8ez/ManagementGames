using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagementGamesDTO
{
    [Table("School")]
    public partial class School
    {
        public School()
        {
            ParticipantInSchools = new HashSet<ParticipantInSchool>();
        }

        [Key]
        [Column("School ID")]
        public int SchoolId { get; set; }
        [Required]
        [Column("School")]
        [StringLength(100)]
        public string School1 { get; set; }

        [InverseProperty(nameof(ParticipantInSchool.ParticipantSchool))]
        public virtual ICollection<ParticipantInSchool> ParticipantInSchools { get; set; }
    }
}
