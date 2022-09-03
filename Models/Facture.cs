using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Facture
    {
        public int IdFacture { get; set; }
        public long? FactNumero { get; set; }
        public DateTime FactDate { get; set; }
        public short? FactNumVoie { get; set; }
        public string FactVoie { get; set; } = null!;
        public string? FactBis { get; set; }
        public int FactCodePostal { get; set; }
        public string FactVille { get; set; } = null!;
        public string FactPays { get; set; } = null!;
        public int IdIndividu { get; set; }

        public virtual Individu IdIndividuNavigation { get; set; } = null!;
    }
}
