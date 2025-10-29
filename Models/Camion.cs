using GarageManagementApp.Enums;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente un camion
    /// </summary>
    public class Camion : Vehicule
    {
        /// <summary>
        /// Nombre d'essieux
        /// </summary>
        public int NbEssieux { get; set; }

        /// <summary>
        /// Poids de chargement en tonnes
        /// </summary>
        public decimal PoidsChargement { get; set; }

        /// <summary>
        /// Volume de chargement en m³
        /// </summary>
        public decimal VolumeChargement { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Camion(string nom, decimal prixHT, Marque marque, Moteur moteur,
                      int nbEssieux, decimal poidsChargement, decimal volumeChargement)
            : base(nom, prixHT, marque, moteur)
        {
            NbEssieux = nbEssieux;
            PoidsChargement = poidsChargement;
            VolumeChargement = volumeChargement;
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Camion() : base() { }

        /// <summary>
        /// Calcule la taxe : nombre d'essieux × 50€
        /// </summary>
        public override decimal CalculerTaxe()
        {
            return NbEssieux * 50m;
        }

        /// <summary>
        /// Affiche les informations du camion
        /// </summary>
        public override string ToString()
        {
            return $"--- CAMION ---\n" +
                   base.ToString() + "\n" +
                   $"    Détails: {NbEssieux} essieux | Poids: {PoidsChargement}T | Volume: {VolumeChargement}m³";
        }
    }
}
