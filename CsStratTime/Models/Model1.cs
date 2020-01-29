namespace EntityFramework
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class Model1 : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Model1 » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « EntityFramework.Model1 » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Model1 » dans le fichier de configuration de l'application.
        public Model1()
            : base("name=Model1")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Strat> Strats { get; set; }
    }


    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Password { get; set; }

    }


    public class Strat
    {
        public Strat(int idUtilisateur, string imagePath, string stratName)
        {
            IdUtilisateur = idUtilisateur;
            ImagePath = imagePath;
            StratName = stratName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUtilisateur { get; set; }
        public string StratName { get; set; }
        public string ImagePath { get; set; }
    }
}