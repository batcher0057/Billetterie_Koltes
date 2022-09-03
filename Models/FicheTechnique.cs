using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class FicheTechnique
    {
        public int IdFiche { get; set; }
        public string? DimensionsSalle { get; set; }
        public int? HauteurSSGrillSalle { get; set; }
        public bool ServiceReservations { get; set; }
        public bool PersonnelsFournis { get; set; }
        public string? ContratsPratiques { get; set; }
        public int IdSalle { get; set; }

        public virtual Salle IdSalleNavigation { get; set; } = null!;
    }
}
