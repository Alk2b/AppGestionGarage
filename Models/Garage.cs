using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManagementApp.Models
{
    /// <summary>
    /// Représente un garage contenant une collection de véhicules
    /// </summary>
    public class Garage
    {
        /// <summary>
        /// Nom du garage
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Liste des véhicules du garage
        /// </summary>
        public List<Vehicule> Vehicules { get; set; }

        /// <summary>
        /// Liste des moteurs disponibles
        /// </summary>
        public List<Moteur> Moteurs { get; set; }

        /// <summary>
        /// Liste des options disponibles
        /// </summary>
        public List<Option> Options { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Garage(string nom)
        {
            Nom = nom;
            Vehicules = new List<Vehicule>();
            Moteurs = new List<Moteur>();
            Options = new List<Option>();
        }

        /// <summary>
        /// Constructeur vide pour la sérialisation JSON
        /// </summary>
        public Garage()
        {
            Vehicules = new List<Vehicule>();
            Moteurs = new List<Moteur>();
            Options = new List<Option>();
        }

        /// <summary>
        /// Ajoute un véhicule au garage
        /// </summary>
        public void AjouterVehicule(Vehicule vehicule)
        {
            Vehicules.Add(vehicule);
            Console.WriteLine($"Véhicule '{vehicule.Nom}' ajouté au garage.");
        }

        /// <summary>
        /// Ajoute un moteur au catalogue
        /// </summary>
        public void AjouterMoteur(Moteur moteur)
        {
            Moteurs.Add(moteur);
            Console.WriteLine($"Moteur '{moteur.Nom}' ajouté au catalogue.");
        }

        /// <summary>
        /// Ajoute une option au catalogue
        /// </summary>
        public void AjouterOption(Option option)
        {
            Options.Add(option);
            Console.WriteLine($"Option '{option.Nom}' ajoutée au catalogue.");
        }

        /// <summary>
        /// Affiche tous les véhicules du garage
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine($"\n{'=',60}");
            Console.WriteLine($"=== Garage '{Nom}' - {Vehicules.Count} véhicule(s) ===");
            Console.WriteLine($"{'=',60}");
            
            if (Vehicules.Count == 0)
            {
                Console.WriteLine("Le garage est vide.");
            }
            else
            {
                foreach (var vehicule in Vehicules)
                {
                    vehicule.Afficher();
                    Console.WriteLine(new string('-', 60));
                }
            }
            
            Console.WriteLine($"{'=',60}\n");
        }

        /// <summary>
        /// Affiche uniquement les voitures du garage
        /// </summary>
        public void AfficherVoiture()
        {
            var voitures = Vehicules.OfType<Voiture>().ToList();
            
            Console.WriteLine($"\n=== Voitures du garage ({voitures.Count}) ===");
            
            if (voitures.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le garage.");
            }
            else
            {
                foreach (var voiture in voitures)
                {
                    voiture.Afficher();
                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        /// <summary>
        /// Affiche uniquement les camions du garage
        /// </summary>
        public void AfficherCamion()
        {
            var camions = Vehicules.OfType<Camion>().ToList();
            
            Console.WriteLine($"\n=== Camions du garage ({camions.Count}) ===");
            
            if (camions.Count == 0)
            {
                Console.WriteLine("Aucun camion dans le garage.");
            }
            else
            {
                foreach (var camion in camions)
                {
                    camion.Afficher();
                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        /// <summary>
        /// Affiche uniquement les motos du garage
        /// </summary>
        public void AfficherMoto()
        {
            var motos = Vehicules.OfType<Moto>().ToList();
            
            Console.WriteLine($"\n=== Motos du garage ({motos.Count}) ===");
            
            if (motos.Count == 0)
            {
                Console.WriteLine("Aucune moto dans le garage.");
            }
            else
            {
                foreach (var moto in motos)
                {
                    moto.Afficher();
                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        /// <summary>
        /// Trie les véhicules par prix total (utilise IComparable)
        /// </summary>
        public void TrierVehicule()
        {
            Vehicules.Sort();
            Console.WriteLine("✓ Véhicules triés par prix total croissant.");
        }
    }
}
