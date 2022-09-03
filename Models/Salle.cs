using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Salle
    {
        public int IdSalle { get; set; }
        public string SalleNom { get; set; } = null!;
        public int? SalleCapacite { get; set; }
        public int IdEmplacement { get; set; }

        public virtual Emplacement IdEmplacementNavigation { get; set; } = null!;
        public virtual FicheTechnique FicheTechnique { get; set; } = null!;
        public virtual Spectacle Spectacle { get; set; } = null!;
    }
}
