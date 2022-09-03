using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Spectacle
    {
        public Spectacle()
        {
            IdIndividus = new HashSet<Individu>();
            IdMedia = new HashSet<Medium>();
        }

        public int IdSpectacle { get; set; }
        public string SpectacleTitre { get; set; } = null!;
        public DateTime? SpectacleDate { get; set; }
        public string? SpectacleAuteur { get; set; }
        public string? SpectacleMetteurEnScene { get; set; }
        public string? SpectacleComediens { get; set; }
        public string? SpectacleTechniciens { get; set; }
        public string? SpectaclePartenaires { get; set; }
        public int IdSalle { get; set; }

        public virtual Salle IdSalleNavigation { get; set; } = null!;

        public virtual ICollection<Individu> IdIndividus { get; set; }
        public virtual ICollection<Medium> IdMedia { get; set; }
    }
}
