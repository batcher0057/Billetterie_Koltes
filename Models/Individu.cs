using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_Koltes.Models
{
    public partial class Individu
    {
        public Individu()
        {
            Factures = new HashSet<Facture>();
            Media = new HashSet<Medium>();
            IdSpectacles = new HashSet<Spectacle>();
            IdStructures = new HashSet<Structure>();
        }

        public int IdIndividu { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 6)]
        [Display(Name = "# Email")]
        [DataType(DataType.EmailAddress)]
        public string Courriel { get; set; } = null!;

        [Required]
        [StringLength(128, MinimumLength = 10)]
        [Display(Name = "# Mot de passe")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; } = null!;

        [StringLength(12, MinimumLength = 1)]
        [Display(Name = "Civilité")]
        public string? Civilite { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Nom")]
        public string? Nom { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Prénom")]
        public string? Prenom { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        private DateTime? _datenaissance;

        public DateTime? DateNaissance 
        {
            get
            {
                string s = String.Format("{0:dd/MM/yyyy HH:mm:ss}", _datenaissance);
                try
                {
                    DateTime retour = DateTime.Parse(s);
                    return retour;
                }
                catch (Exception ex)
                {
                    string Erreur = ex.Message;
                }

                return _datenaissance;
            }
            set
            {
                _datenaissance = value;
            }
        }

        [StringLength(20, MinimumLength = 10)]
        [Display(Name = "Téléphone mobile")]
        public string? TelMobile { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Pseudonyme")]
        public string? Pseudo { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Catégorie")]
        public string? Categorie { get; set; }

        [Display(Name = "Administrateur")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Employé")]
        public bool IsCoworker { get; set; }

        public virtual ExtraContact ExtraContact { get; set; } = null!;
        public virtual ICollection<Facture> Factures { get; set; }
        public virtual ICollection<Medium> Media { get; set; }

        public virtual ICollection<Spectacle> IdSpectacles { get; set; }
        public virtual ICollection<Structure> IdStructures { get; set; }
    }
}
