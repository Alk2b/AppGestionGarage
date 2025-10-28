using System;
using GarageManagementApp.Enums;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente un moteur de véhicule
    /// </summary>
    public class Moteur
    {
        // Variable statique pour l'auto-incrémentation des IDs
        private static int _increment = 0;

        /// <summary>
        /// Identifiant unique du moteur (généré automatiquement)
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nom du moteur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Puissance du moteur en chevaux
        /// </summary>
        public int Puissance { get; set; }

        /// <summary>
        /// Type de moteur (Diesel, Essence, Hybride, Electrique)
        /// </summary>
        public TypeMoteur Type { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Moteur(string nom, int puissance, TypeMoteur type)
        {
            Id = ++_increment;
            Nom = nom;
            Puissance = puissance;
            Type = type;
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Moteur() { }

        /// <summary>
        /// Affiche les informations du moteur
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Retourne une représentation textuelle du moteur
        /// </summary>
        public override string ToString()
        {
            return $"[Moteur #{Id}] {Nom} - {Puissance}ch ({Type})";
        }
    }
}
