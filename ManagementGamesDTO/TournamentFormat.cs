using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagementGamesDTO
{
    [Table("Tournament format")]
    public partial class TournamentFormat
    {
        public TournamentFormat()
        {
            Tournaments = new HashSet<Tournament>();
        }

        [Key]
        [Column("Format ID")]
        public int FormatId { get; set; }
        [Required]
        [StringLength(30)]
        public string Format { get; set; }
        [InverseProperty(nameof(Tournament.TournamentFormat))]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
