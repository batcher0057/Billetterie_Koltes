using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Medium
    {
        public Medium()
        {
            IdSpectacles = new HashSet<Spectacle>();
            IdStructures = new HashSet<Structure>();
        }

        public int IdMedia { get; set; }
        public string MediaTitre { get; set; } = null!;
        public DateTime? MediaDate { get; set; }
        public string? MediaLieu { get; set; }
        public string? MediaProprietaire { get; set; }
        public string? MediaCredits { get; set; }
        public string? MediaMotsClefs { get; set; }
        public int IdIndividu { get; set; }

        public virtual Individu IdIndividuNavigation { get; set; } = null!;

        public virtual ICollection<Spectacle> IdSpectacles { get; set; }
        public virtual ICollection<Structure> IdStructures { get; set; }
    }
}
