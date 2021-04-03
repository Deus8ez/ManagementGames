using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    //[Table("Jury panel")]
    public partial class JuryPanel
    {
        public JuryPanel()
        {
            JuryInPanels = new HashSet<JuryInPanel>();
        }

        [Key]
        [Column("Panel ID")]
        public int PanelId { get; set; }
        [Required]
        [StringLength(30)]
        public string Panel { get; set; }

        [InverseProperty(nameof(JuryInPanel.JuryPanel))]
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
    }
}
