using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GarageManagementApp.Enums;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Classe abstraite représentant un véhicule générique
    /// Implémente IComparable pour permettre le tri des véhicules
    /// </summary>
    [JsonDerivedType(typeof(Voiture), typeDiscriminator: "voiture")]
    [JsonDerivedType(typeof(Camion), typeDiscriminator: "camion")]
    [JsonDerivedType(typeof(Moto), typeDiscriminator: "moto")]
    public abstract class Vehicule : IComparable<Vehicule>
    {
        // Variable statique pour l'auto-incrémentation des IDs
        private static int _increment = 0;

        /// <summary>
        /// Identifiant unique du véhicule (généré automatiquement)
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nom du véhicule
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prix hors taxe du véhicule
        /// </summary>
        public decimal PrixHT { get; set; }

        /// <summary>
        /// Marque du véhicule
        /// </summary>
        public Marque LaMarque { get; set; }

        /// <summary>
        /// Moteur du véhicule
        /// </summary>
        public Moteur LeMoteur { get; set; }

        /// <summary>
        /// Liste des options du véhicule
        /// </summary>
        public List<Option> Options { get; set; }

        /// <summary>
        /// Prix total du véhicule (Prix HT + Options + Taxe)
        /// </summary>
        public decimal PrixTotal
        {
            get
            {
                decimal prixOptions = 0;
                foreach (var option in Options)
                {
                    prixOptions += option.Prix;
                }
                return PrixHT + prixOptions + CalculerTaxe();
            }
        }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Vehicule(string nom, decimal prixHT, Marque marque, Moteur moteur)
        {
            Id = ++_increment;
            Nom = nom;
            PrixHT = prixHT;
            LaMarque = marque;
            LeMoteur = moteur;
            Options = new List<Option>();
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Vehicule()
        {
            Options = new List<Option>();
            LeMoteur = new Moteur();
        }

        /// <summary>
        /// Calcule la taxe sur le véhicule (implémentation spécifique dans les classes dérivées)
        /// </summary>
        public abstract decimal CalculerTaxe();

        /// <summary>
        /// Ajoute une option au véhicule
        /// </summary>
        public void AjouterOption(Option option)
        {
            Options.Add(option);
            Console.WriteLine($"Option '{option.Nom}' ajoutée au véhicule '{Nom}'.");
        }

        /// <summary>
        /// Affiche les options du véhicule
        /// </summary>
        public void AfficherOptions()
        {
            Console.WriteLine($"--- Options pour {Nom} ---");
            if (Options.Count == 0)
            {
                Console.WriteLine("Aucune option.");
            }
            else
            {
                Options.ForEach(o => o.Afficher());
            }
        }

        /// <summary>
        /// Affiche les informations du véhicule
        /// </summary>
        public virtual void Afficher()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Retourne une représentation textuelle du véhicule
        /// </summary>
        public override string ToString()
        {
            string optionsStr = Options.Count > 0 ? $"{Options.Count} option(s)" : "Aucune option";
            return $"[#{Id}] {Nom} ({LaMarque}) - Moteur: {LeMoteur.Nom}\n" +
                   $"    Prix HT: {PrixHT:C} | Taxe: {CalculerTaxe():C} | Options: {optionsStr}\n" +
                   $"    PRIX TOTAL: {PrixTotal:C}";
        }

        /// <summary>
        /// Implémentation de IComparable pour le tri par prix total
        /// </summary>
        public int CompareTo(Vehicule? other)
        {
            if (other == null) return 1;
            return this.PrixTotal.CompareTo(other.PrixTotal);
        }
    }
}
