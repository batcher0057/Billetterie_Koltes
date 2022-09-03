using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class ExtraContact
    {
        public int IdContact { get; set; }
        public string? TelFixe { get; set; }
        public string? TelBureau { get; set; }
        public short? NumeroVoie { get; set; }
        public string? Bis { get; set; }
        public string? Voie { get; set; }
        public int? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public string? Telecopie { get; set; }
        public int IdIndividu { get; set; }

        public virtual Individu IdIndividuNavigation { get; set; } = null!;
    }
}
