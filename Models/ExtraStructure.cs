using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class ExtraStructure
    {
        public int IdExtrastructure { get; set; }
        public string? XstructCourriel { get; set; }
        public string? XstructTelFixe { get; set; }
        public string? XstructTelFixe2 { get; set; }
        public string? XstructTelecopie { get; set; }
        public string? XstructSiteInternet { get; set; }
        public string? XstructNumeroTva { get; set; }
        public string? XstructActivite2 { get; set; }
        public string? XstructActivite3 { get; set; }
        public int IdStructure { get; set; }

        public virtual Structure IdStructureNavigation { get; set; } = null!;
    }
}
