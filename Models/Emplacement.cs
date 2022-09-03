using System;
using System.Collections.Generic;

namespace CRM_Koltes.Models
{
    public partial class Emplacement
    {
        public Emplacement()
        {
            Salles = new HashSet<Salle>();
            IdStructures = new HashSet<Structure>();
        }

        public int IdEmplacement { get; set; }
        public string EmplacNom { get; set; } = null!;
        public string EmplacVoie { get; set; } = null!;
        public short? EmplacNumVoie { get; set; }
        public string EmplacCpVille { get; set; } = null!;
        public string EmplacPays { get; set; } = null!;
        public string? EmplacTel { get; set; }
        public string? EmplacTelecopie { get; set; }
        public int? CapaciteLieu { get; set; }
        public byte? NombreSalles { get; set; }
        public string? TypeLieu { get; set; }
        public string? SituationGeographique { get; set; }

        public virtual ICollection<Salle> Salles { get; set; }

        public virtual ICollection<Structure> IdStructures { get; set; }
    }
}
