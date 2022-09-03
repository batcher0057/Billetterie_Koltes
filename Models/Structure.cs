using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Structure
    {
        public Structure()
        {
            CompteBancaires = new HashSet<CompteBancaire>();
            IdEmplacements = new HashSet<Emplacement>();
            IdIndividus = new HashSet<Individu>();
            IdMedia = new HashSet<Medium>();
        }

        public int IdStructure { get; set; }
        public string RaisonCommerciale { get; set; } = null!;
        public string RaisonSociale { get; set; } = null!;
        public string Siret { get; set; } = null!;
        public DateTime StructDateEnregistrement { get; set; }
        public short StructNumeroVoie { get; set; }
        public string StructVoie { get; set; } = null!;
        public string? StructBis { get; set; }
        public int StructCodePostal { get; set; }
        public string StructVille { get; set; } = null!;
        public string StructPays { get; set; } = null!;
        public string? StructCategorie { get; set; }
        public string StructActivitePrincipale { get; set; } = null!;

        public virtual ExtraStructure ExtraStructure { get; set; } = null!;
        public virtual ICollection<CompteBancaire> CompteBancaires { get; set; }

        public virtual ICollection<Emplacement> IdEmplacements { get; set; }
        public virtual ICollection<Individu> IdIndividus { get; set; }
        public virtual ICollection<Medium> IdMedia { get; set; }
    }
}
