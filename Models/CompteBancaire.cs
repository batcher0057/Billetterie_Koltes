using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class CompteBancaire
    {
        public int IdRib { get; set; }
        public string NomEtablissement { get; set; } = null!;
        public long NumeroCompte { get; set; }
        public string TitulaireCompte { get; set; } = null!;
        public string TitulaireNomPrenom { get; set; } = null!;
        public string TitulaireVoie { get; set; } = null!;
        public string TitulaireCpVille { get; set; } = null!;
        public string NumeroIban { get; set; } = null!;
        public string NumeroBic { get; set; } = null!;
        public string DomiciliationNom { get; set; } = null!;
        public string DomiciliationVoie { get; set; } = null!;
        public string DomiciliationCpVille { get; set; } = null!;
        public string? DomiciliationTel { get; set; }
        public int IdStructure { get; set; }

        public virtual Structure IdStructureNavigation { get; set; } = null!;
    }
}
