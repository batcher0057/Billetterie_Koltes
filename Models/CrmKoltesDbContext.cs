using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRM_Koltes.Models
{
    public partial class CrmKoltesDbContext : DbContext
    {
        public CrmKoltesDbContext()
        {
        }

        public CrmKoltesDbContext(DbContextOptions<CrmKoltesDbContext> options) : base(options)
        {
        }

        public virtual DbSet<CompteBancaire> CompteBancaires { get; set; } = null!;
        public virtual DbSet<Emplacement> Emplacements { get; set; } = null!;
        public virtual DbSet<ExtraContact> ExtraContacts { get; set; } = null!;
        public virtual DbSet<ExtraStructure> ExtraStructures { get; set; } = null!;
        public virtual DbSet<Facture> Factures { get; set; } = null!;
        public virtual DbSet<FicheTechnique> FicheTechniques { get; set; } = null!;
        public virtual DbSet<Individu> Individus { get; set; } = null!;
        public virtual DbSet<Medium> Media { get; set; } = null!;
        public virtual DbSet<Salle> Salles { get; set; } = null!;
        public virtual DbSet<Spectacle> Spectacles { get; set; } = null!;
        public virtual DbSet<Structure> Structures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompteBancaire>(entity =>
            {
                entity.HasKey(e => e.IdRib)
                    .HasName("PK__CompteBa__6ABCC6A60FA0960D");

                entity.ToTable("CompteBancaire");

                entity.Property(e => e.IdRib).HasColumnName("id_rib");

                entity.Property(e => e.DomiciliationCpVille)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domiciliation_cp_ville");

                entity.Property(e => e.DomiciliationNom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domiciliation_nom");

                entity.Property(e => e.DomiciliationTel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("domiciliation_tel");

                entity.Property(e => e.DomiciliationVoie)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("domiciliation_voie");

                entity.Property(e => e.IdStructure).HasColumnName("id_structure");

                entity.Property(e => e.NomEtablissement)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_etablissement");

                entity.Property(e => e.NumeroBic)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("numero_bic");

                entity.Property(e => e.NumeroCompte).HasColumnName("numero_compte");

                entity.Property(e => e.NumeroIban)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("numero_iban");

                entity.Property(e => e.TitulaireCompte)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulaire_compte");

                entity.Property(e => e.TitulaireCpVille)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulaire_cp_ville");

                entity.Property(e => e.TitulaireNomPrenom)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("titulaire_nom_prenom");

                entity.Property(e => e.TitulaireVoie)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("titulaire_voie");

                entity.HasOne(d => d.IdStructureNavigation)
                    .WithMany(p => p.CompteBancaires)
                    .HasForeignKey(d => d.IdStructure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CompteBan__id_st__34C8D9D1");
            });

            modelBuilder.Entity<Emplacement>(entity =>
            {
                entity.HasKey(e => e.IdEmplacement)
                    .HasName("PK__Emplacem__2A197CC263F470CE");

                entity.ToTable("Emplacement");

                entity.Property(e => e.IdEmplacement).HasColumnName("id_emplacement");

                entity.Property(e => e.CapaciteLieu).HasColumnName("capacite_lieu");

                entity.Property(e => e.EmplacCpVille)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emplac_cp_ville");

                entity.Property(e => e.EmplacNom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emplac_nom");

                entity.Property(e => e.EmplacNumVoie).HasColumnName("emplac_num_voie");

                entity.Property(e => e.EmplacPays)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emplac_pays");

                entity.Property(e => e.EmplacTel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emplac_tel");

                entity.Property(e => e.EmplacTelecopie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emplac_telecopie");

                entity.Property(e => e.EmplacVoie)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emplac_voie");

                entity.Property(e => e.NombreSalles).HasColumnName("nombre_salles");

                entity.Property(e => e.SituationGeographique)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situation_geographique");

                entity.Property(e => e.TypeLieu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type_lieu");
            });

            modelBuilder.Entity<ExtraContact>(entity =>
            {
                entity.HasKey(e => e.IdContact)
                    .HasName("PK__ExtraCon__3D4F725E959A6EA2");

                entity.ToTable("ExtraContact");

                entity.HasIndex(e => e.IdIndividu, "UQ__ExtraCon__0A1AEFA9A89E9D0D")
                    .IsUnique();

                entity.Property(e => e.IdContact)
                    .ValueGeneratedNever()
                    .HasColumnName("id_contact");

                entity.Property(e => e.Bis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bis");

                entity.Property(e => e.CodePostal).HasColumnName("code_postal");

                entity.Property(e => e.IdIndividu).HasColumnName("id_individu");

                entity.Property(e => e.NumeroVoie).HasColumnName("numero_voie");

                entity.Property(e => e.Pays)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("pays");

                entity.Property(e => e.TelBureau)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tel_bureau");

                entity.Property(e => e.TelFixe)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tel_fixe");

                entity.Property(e => e.Telecopie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telecopie");

                entity.Property(e => e.Ville)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ville");

                entity.Property(e => e.Voie)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("voie");

                entity.HasOne(d => d.IdIndividuNavigation)
                    .WithOne(p => p.ExtraContact)
                    .HasForeignKey<ExtraContact>(d => d.IdIndividu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExtraCont__id_in__286302EC");
            });

            modelBuilder.Entity<ExtraStructure>(entity =>
            {
                entity.HasKey(e => e.IdExtrastructure)
                    .HasName("PK__ExtraStr__9DC8AF3C12750776");

                entity.ToTable("ExtraStructure");

                entity.HasIndex(e => e.IdStructure, "UQ__ExtraStr__5630DD6A3A08D416")
                    .IsUnique();

                entity.Property(e => e.IdExtrastructure)
                    .ValueGeneratedNever()
                    .HasColumnName("id_extrastructure");

                entity.Property(e => e.IdStructure).HasColumnName("id_structure");

                entity.Property(e => e.XstructActivite2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_activite2");

                entity.Property(e => e.XstructActivite3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_activite3");

                entity.Property(e => e.XstructCourriel)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_courriel");

                entity.Property(e => e.XstructNumeroTva)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_numero_tva");

                entity.Property(e => e.XstructSiteInternet)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_site_internet");

                entity.Property(e => e.XstructTelFixe)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_tel_fixe");

                entity.Property(e => e.XstructTelFixe2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_tel_fixe2");

                entity.Property(e => e.XstructTelecopie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("xstruct_telecopie");

                entity.HasOne(d => d.IdStructureNavigation)
                    .WithOne(p => p.ExtraStructure)
                    .HasForeignKey<ExtraStructure>(d => d.IdStructure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExtraStru__id_st__31EC6D26");
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.IdFacture)
                    .HasName("PK__Facture__6C08ED57A1F64601");

                entity.ToTable("Facture");

                entity.HasIndex(e => e.FactNumero, "UQ__Facture__AF0037E13D6FF482")
                    .IsUnique();

                entity.Property(e => e.IdFacture).HasColumnName("id_facture");

                entity.Property(e => e.FactBis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fact_bis");

                entity.Property(e => e.FactCodePostal).HasColumnName("fact_code_postal");

                entity.Property(e => e.FactDate).HasColumnName("fact_date");

                entity.Property(e => e.FactNumVoie).HasColumnName("fact_num_voie");

                entity.Property(e => e.FactNumero).HasColumnName("fact_numero");

                entity.Property(e => e.FactPays)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fact_pays");

                entity.Property(e => e.FactVille)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fact_ville");

                entity.Property(e => e.FactVoie)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fact_voie");

                entity.Property(e => e.IdIndividu).HasColumnName("id_individu");

                entity.HasOne(d => d.IdIndividuNavigation)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.IdIndividu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facture__id_indi__2C3393D0");
            });

            modelBuilder.Entity<FicheTechnique>(entity =>
            {
                entity.HasKey(e => e.IdFiche)
                    .HasName("PK__FicheTec__427B0F8ECCDCE73D");

                entity.ToTable("FicheTechnique");

                entity.HasIndex(e => e.IdSalle, "UQ__FicheTec__6C46738802B7B65F")
                    .IsUnique();

                entity.Property(e => e.IdFiche).HasColumnName("id_fiche");

                entity.Property(e => e.ContratsPratiques)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrats_pratiques");

                entity.Property(e => e.DimensionsSalle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dimensions_salle");

                entity.Property(e => e.HauteurSSGrillSalle).HasColumnName("hauteur_s_s_grill_salle");

                entity.Property(e => e.IdSalle).HasColumnName("id_salle");

                entity.Property(e => e.PersonnelsFournis).HasColumnName("personnels_fournis");

                entity.Property(e => e.ServiceReservations).HasColumnName("service_reservations");

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithOne(p => p.FicheTechnique)
                    .HasForeignKey<FicheTechnique>(d => d.IdSalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FicheTech__id_sa__3D5E1FD2");
            });

            modelBuilder.Entity<Individu>(entity =>
            {
                entity.HasKey(e => e.IdIndividu)
                    .HasName("PK__Individu__0A1AEFA8B6E4EB70");

                entity.ToTable("Individu");

                entity.HasIndex(e => e.Courriel, "UQ__Individu__049FB2029E450F15")
                    .IsUnique();

                entity.Property(e => e.IdIndividu).HasColumnName("id_individu");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categorie");

                entity.Property(e => e.Civilite)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("civilite");

                entity.Property(e => e.Courriel)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("courriel");

                entity.Property(e => e.DateNaissance).HasColumnName("date_naissance");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsCoworker).HasColumnName("is_coworker");

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("mot_de_passe");

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prenom");

                entity.Property(e => e.Pseudo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pseudo");

                entity.Property(e => e.TelMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tel_mobile");

                entity.HasMany(d => d.IdSpectacles)
                    .WithMany(p => p.IdIndividus)
                    .UsingEntity<Dictionary<string, object>>(
                        "Voit",
                        l => l.HasOne<Spectacle>().WithMany().HasForeignKey("IdSpectacle").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Voit__id_spectac__571DF1D5"),
                        r => r.HasOne<Individu>().WithMany().HasForeignKey("IdIndividu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Voit__id_individ__5629CD9C"),
                        j =>
                        {
                            j.HasKey("IdIndividu", "IdSpectacle").HasName("PK__Voit__26A6216CF7194081");

                            j.ToTable("Voit");

                            j.IndexerProperty<int>("IdIndividu").HasColumnName("id_individu");

                            j.IndexerProperty<int>("IdSpectacle").HasColumnName("id_spectacle");
                        });

                entity.HasMany(d => d.IdStructures)
                    .WithMany(p => p.IdIndividus)
                    .UsingEntity<Dictionary<string, object>>(
                        "Integre",
                        l => l.HasOne<Structure>().WithMany().HasForeignKey("IdStructure").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Integre__id_stru__47DBAE45"),
                        r => r.HasOne<Individu>().WithMany().HasForeignKey("IdIndividu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Integre__id_indi__46E78A0C"),
                        j =>
                        {
                            j.HasKey("IdIndividu", "IdStructure").HasName("PK__Integre__AF79E27E635D9E5B");

                            j.ToTable("Integre");

                            j.IndexerProperty<int>("IdIndividu").HasColumnName("id_individu");

                            j.IndexerProperty<int>("IdStructure").HasColumnName("id_structure");
                        });
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__Media__2112D168793AFC7B");

                entity.Property(e => e.IdMedia).HasColumnName("id_media");

                entity.Property(e => e.IdIndividu).HasColumnName("id_individu");

                entity.Property(e => e.MediaCredits)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("media_credits");

                entity.Property(e => e.MediaDate).HasColumnName("media_date");

                entity.Property(e => e.MediaLieu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("media_lieu");

                entity.Property(e => e.MediaMotsClefs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("media_mots_clefs");

                entity.Property(e => e.MediaProprietaire)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("media_proprietaire");

                entity.Property(e => e.MediaTitre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("media_titre");

                entity.HasOne(d => d.IdIndividuNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.IdIndividu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Media__id_indivi__403A8C7D");

                entity.HasMany(d => d.IdSpectacles)
                    .WithMany(p => p.IdMedia)
                    .UsingEntity<Dictionary<string, object>>(
                        "Promotionne",
                        l => l.HasOne<Spectacle>().WithMany().HasForeignKey("IdSpectacle").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Promotion__id_sp__4BAC3F29"),
                        r => r.HasOne<Medium>().WithMany().HasForeignKey("IdMedia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Promotion__id_me__4AB81AF0"),
                        j =>
                        {
                            j.HasKey("IdMedia", "IdSpectacle").HasName("PK__Promotio__0DAE1FACFFC933B8");

                            j.ToTable("Promotionne");

                            j.IndexerProperty<int>("IdMedia").HasColumnName("id_media");

                            j.IndexerProperty<int>("IdSpectacle").HasColumnName("id_spectacle");
                        });
            });

            modelBuilder.Entity<Salle>(entity =>
            {
                entity.HasKey(e => e.IdSalle)
                    .HasName("PK__Salle__6C467389EC553F03");

                entity.ToTable("Salle");

                entity.Property(e => e.IdSalle).HasColumnName("id_salle");

                entity.Property(e => e.IdEmplacement).HasColumnName("id_emplacement");

                entity.Property(e => e.SalleCapacite).HasColumnName("salle_capacite");

                entity.Property(e => e.SalleNom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("salle_nom");

                entity.HasOne(d => d.IdEmplacementNavigation)
                    .WithMany(p => p.Salles)
                    .HasForeignKey(d => d.IdEmplacement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salle__id_emplac__398D8EEE");
            });

            modelBuilder.Entity<Spectacle>(entity =>
            {
                entity.HasKey(e => e.IdSpectacle)
                    .HasName("PK__Spectacl__CBCCEC430C55D688");

                entity.ToTable("Spectacle");

                entity.HasIndex(e => e.IdSalle, "UQ__Spectacl__6C4673883C4D55CB")
                    .IsUnique();

                entity.Property(e => e.IdSpectacle).HasColumnName("id_spectacle");

                entity.Property(e => e.IdSalle).HasColumnName("id_salle");

                entity.Property(e => e.SpectacleAuteur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_auteur");

                entity.Property(e => e.SpectacleComediens)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_comediens");

                entity.Property(e => e.SpectacleDate).HasColumnName("spectacle_date");

                entity.Property(e => e.SpectacleMetteurEnScene)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_metteur_en_scene");

                entity.Property(e => e.SpectaclePartenaires)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_partenaires");

                entity.Property(e => e.SpectacleTechniciens)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_techniciens");

                entity.Property(e => e.SpectacleTitre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("spectacle_titre");

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithOne(p => p.Spectacle)
                    .HasForeignKey<Spectacle>(d => d.IdSalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Spectacle__id_sa__440B1D61");
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.HasKey(e => e.IdStructure)
                    .HasName("PK__Structur__5630DD6B67392E45");

                entity.ToTable("Structure");

                entity.Property(e => e.IdStructure).HasColumnName("id_structure");

                entity.Property(e => e.RaisonCommerciale)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("raison_commerciale");

                entity.Property(e => e.RaisonSociale)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("raison_sociale");

                entity.Property(e => e.Siret)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("siret");

                entity.Property(e => e.StructActivitePrincipale)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("struct_activite_principale");

                entity.Property(e => e.StructBis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("struct_bis");

                entity.Property(e => e.StructCategorie)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("struct_categorie");

                entity.Property(e => e.StructCodePostal).HasColumnName("struct_code_postal");

                entity.Property(e => e.StructDateEnregistrement).HasColumnName("struct_date_enregistrement");

                entity.Property(e => e.StructNumeroVoie).HasColumnName("struct_numero_voie");

                entity.Property(e => e.StructPays)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("struct_pays");

                entity.Property(e => e.StructVille)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("struct_ville");

                entity.Property(e => e.StructVoie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("struct_voie");

                entity.HasMany(d => d.IdEmplacements)
                    .WithMany(p => p.IdStructures)
                    .UsingEntity<Dictionary<string, object>>(
                        "Inclut",
                        l => l.HasOne<Emplacement>().WithMany().HasForeignKey("IdEmplacement").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Inclut__id_empla__534D60F1"),
                        r => r.HasOne<Structure>().WithMany().HasForeignKey("IdStructure").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Inclut__id_struc__52593CB8"),
                        j =>
                        {
                            j.HasKey("IdStructure", "IdEmplacement").HasName("PK__Inclut__64914AA762EBCCEC");

                            j.ToTable("Inclut");

                            j.IndexerProperty<int>("IdStructure").HasColumnName("id_structure");

                            j.IndexerProperty<int>("IdEmplacement").HasColumnName("id_emplacement");
                        });

                entity.HasMany(d => d.IdMedia)
                    .WithMany(p => p.IdStructures)
                    .UsingEntity<Dictionary<string, object>>(
                        "Produit",
                        l => l.HasOne<Medium>().WithMany().HasForeignKey("IdMedia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Produit__id_medi__4F7CD00D"),
                        r => r.HasOne<Structure>().WithMany().HasForeignKey("IdStructure").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Produit__id_stru__4E88ABD4"),
                        j =>
                        {
                            j.HasKey("IdStructure", "IdMedia").HasName("PK__Produit__C421F07DBB690478");

                            j.ToTable("Produit");

                            j.IndexerProperty<int>("IdStructure").HasColumnName("id_structure");

                            j.IndexerProperty<int>("IdMedia").HasColumnName("id_media");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
