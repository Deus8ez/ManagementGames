using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagementGamesDTO
{
    [Table("Tournament type")]
    public partial class TournamentType
    {
        public TournamentType()
        {
            Tournaments = new HashSet<Tournament>();
        }

        [Key]
        [Column("Type ID")]
        public int TypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [InverseProperty(nameof(Tournament.TournamentType))]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
