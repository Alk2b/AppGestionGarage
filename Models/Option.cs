using System;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente une option qui peut être ajoutée à un véhicule
    /// </summary>
    public class Option
    {
        // Variable statique pour l'auto-incrémentation des IDs
        private static int _increment = 0;

        /// <summary>
        /// Identifiant unique de l'option (généré automatiquement)
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nom de l'option
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prix de l'option en euros
        /// </summary>
        public decimal Prix { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Option(string nom, decimal prix)
        {
            Id = ++_increment;
            Nom = nom;
            Prix = prix;
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Option() { }

        /// <summary>
        /// Affiche les informations de l'option
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Retourne une représentation textuelle de l'option
        /// </summary>
        public override string ToString()
        {
            return $"[Option #{Id}] {Nom} - {Prix:C}";
        }
    }
}
