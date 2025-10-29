using System;
using GarageManagementApp.Enums;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente une moto
    /// </summary>
    public class Moto : Vehicule
    {
        /// <summary>
        /// Cylindrée en cm³
        /// </summary>
        public int Cylindree { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Moto(string nom, decimal prixHT, Marque marque, Moteur moteur, int cylindree)
            : base(nom, prixHT, marque, moteur)
        {
            Cylindree = cylindree;
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Moto() : base() { }

        /// <summary>
        /// Calcule la taxe : cylindrée × 0.3€ (partie entière)
        /// </summary>
        public override decimal CalculerTaxe()
        {
            return System.Math.Floor(Cylindree * 0.3m);
        }

        /// <summary>
        /// Affiche les informations de la moto
        /// </summary>
        public override string ToString()
        {
            return $"--- MOTO ---\n" +
                   base.ToString() + "\n" +
                   $"    Détails: {Cylindree} cm³";
        }
    }
}
