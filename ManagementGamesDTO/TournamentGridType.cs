using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ManagementGamesDTO
{
    [Table("Tournament grid type")]
    public partial class TournamentGridType
    {
        public TournamentGridType()
        {
            Tournaments = new HashSet<Tournament>();
        }

        [Key]
        [Column("Grid ID")]
        public int GridId { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [InverseProperty(nameof(Tournament.TournamentGrid))]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
