using GarageManagementApp.Enums;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente une voiture
    /// </summary>
    public class Voiture : Vehicule
    {
        /// <summary>
        /// Puissance en chevaux fiscaux
        /// </summary>
        public int ChevauxFiscaux { get; set; }

        /// <summary>
        /// Nombre de portes
        /// </summary>
        public int NbPorte { get; set; }

        /// <summary>
        /// Nombre de sièges
        /// </summary>
        public int NbSiege { get; set; }

        /// <summary>
        /// Taille du coffre en m³
        /// </summary>
        public double TailleCoffre { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Voiture(string nom, decimal prixHT, Marque marque, Moteur moteur,
                       int chevauxFiscaux, int nbPorte, int nbSiege, double tailleCoffre)
            : base(nom, prixHT, marque, moteur)
        {
            ChevauxFiscaux = chevauxFiscaux;
            NbPorte = nbPorte;
            NbSiege = nbSiege;
            TailleCoffre = tailleCoffre;
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Voiture() : base() { }

        /// <summary>
        /// Calcule la taxe : chevaux fiscaux × 10€
        /// </summary>
        public override decimal CalculerTaxe()
        {
            return ChevauxFiscaux * 10m;
        }

        /// <summary>
        /// Affiche les informations de la voiture
        /// </summary>
        public override string ToString()
        {
            return $"--- VOITURE ---\n" +
                   base.ToString() + "\n" +
                   $"    Détails: {ChevauxFiscaux} CV | {NbPorte} portes | {NbSiege} sièges | Coffre: {TailleCoffre}m³";
        }
    }
}
