using System;
using System.Linq;
using GarageManagementApp.Models;
using GarageManagementApp.Enums;
using GarageManagementApp.Exceptions;

namespace GarageManagementApp.Services
{
    /// <summary>
    /// Gère le menu interactif de l'application
    /// </summary>
    public class Menu
    {
        private Garage garage;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        /// <summary>
        /// Lance la boucle principale du menu
        /// </summary>
        public void Start()
        {
            bool quitter = false;

            while (!quitter)
            {
                try
                {
                    AfficherMenuPrincipal();
                    int choix = GetChoixMenu(1, 13);

                    switch (choix)
                    {
                        case 1: AfficherVehicules(); break;
                        case 2: AjouterVehicule(); break;
                        case 3: SupprimerVehicule(); break;
                        case 4: SelectionnerVehicule(); break;
                        case 5: AfficherOptionsVehicule(); break;
                        case 6: AjouterOptionVehicule(); break;
                        case 7: SupprimerOptionVehicule(); break;
                        case 8: AfficherOptions(); break;
                        case 9: AfficherMarques(); break;
                        case 10: AfficherTypesMoteurs(); break;
                        case 11: ChargerGarage(); break;
                        case 12: SauvegarderGarage(); break;
                        case 13: quitter = true; Console.WriteLine("\nAu revoir !"); break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERREUR] {ex.Message}");
                    Console.ResetColor();
                }
                catch (MenuException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERREUR MENU] {ex.Message}");
                    Console.ResetColor();
                }
                catch (VehiculeNotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[ATTENTION] {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERREUR INATTENDUE] {ex.Message}");
                    Console.ResetColor();
                }

                if (!quitter)
                {
                    Console.WriteLine("\nAppuyez sur Entree pour continuer...");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Affiche le menu principal
        /// </summary>
        private void AfficherMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("       GESTION GARAGE - MENU PRINCIPAL");
            Console.WriteLine("============================================================");
            Console.WriteLine("  1.  Afficher les vehicules");
            Console.WriteLine("  2.  Ajouter un vehicule");
            Console.WriteLine("  3.  Supprimer un vehicule");
            Console.WriteLine("  4.  Selectionner un vehicule");
            Console.WriteLine("  5.  Afficher les options d'un vehicule");
            Console.WriteLine("  6.  Ajouter des options a un vehicule");
            Console.WriteLine("  7.  Supprimer des options a un vehicule");
            Console.WriteLine("  8.  Afficher les options (catalogue)");
            Console.WriteLine("  9.  Afficher les marques");
            Console.WriteLine("  10. Afficher les types de moteurs");
            Console.WriteLine("  11. Charger le garage");
            Console.WriteLine("  12. Sauvegarder le garage");
            Console.WriteLine("  13. Quitter l'application");
            Console.WriteLine("============================================================");
            Console.Write("Votre choix : ");
        }

        /// <summary>
        /// Récupère le choix de l'utilisateur et le convertit en int
        /// </summary>
        private int GetChoix()
        {
            string input = Console.ReadLine();
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                throw new FormatException("Le choix saisi n'est pas un nombre.");
            }
        }

        /// <summary>
        /// Récupère le choix et vérifie qu'il est dans la plage valide
        /// </summary>
        private int GetChoixMenu(int min, int max)
        {
            int choix = GetChoix();
            if (choix < min || choix > max)
            {
                throw new MenuException($"Le choix n'est pas compris entre {min} et {max}.");
            }
            return choix;
        }

        // ========== METHODES DU MENU (SQUELETTES) ==========

        private void AfficherVehicules()
        {
            Console.WriteLine("\n=== LISTE DES VEHICULES ===\n");
            garage.Afficher();
            
            // Option de tri
            Console.Write("\nVoulez-vous trier les vehicules par prix ? (o/n) : ");
            string reponse = Console.ReadLine()?.ToLower();
            
            if (reponse == "o" || reponse == "oui")
            {
                garage.TrierVehicule();
                Console.WriteLine();
                garage.Afficher();
            }
        }

        private void AjouterVehicule()
        {
            Console.WriteLine("\n=== AJOUTER UN VEHICULE ===\n");
            
            try
            {
                // Choix du type de véhicule
                Console.WriteLine("Type de vehicule :");
                Console.WriteLine("  1. Voiture");
                Console.WriteLine("  2. Camion");
                Console.WriteLine("  3. Moto");
                Console.Write("Votre choix : ");
                int typeVehicule = GetChoixMenu(1, 3);
                
                // Informations communes
                Console.Write("\nNom du vehicule : ");
                string nom = Console.ReadLine();
                
                Console.Write("Prix HT (euros) : ");
                decimal prixHT = decimal.Parse(Console.ReadLine());
                
                // Choix de la marque
                Console.WriteLine("\nMarques disponibles :");
                var marques = Enum.GetValues(typeof(Marque)).Cast<Marque>().ToArray();
                for (int i = 0; i < marques.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {marques[i]}");
                }
                Console.Write("Votre choix : ");
                int choixMarque = GetChoixMenu(1, marques.Length);
                Marque marque = marques[choixMarque - 1];
                
                // Choix du moteur
                Console.WriteLine("\nMoteurs disponibles :");
                if (garage.Moteurs.Count == 0)
                {
                    Console.WriteLine("Aucun moteur disponible ! Ajout annule.");
                    return;
                }
                for (int i = 0; i < garage.Moteurs.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {garage.Moteurs[i]}");
                }
                Console.Write("Votre choix : ");
                int choixMoteur = GetChoixMenu(1, garage.Moteurs.Count);
                Moteur moteur = garage.Moteurs[choixMoteur - 1];
                
                // Création selon le type
                Vehicule nouveauVehicule = null;
                
                switch (typeVehicule)
                {
                    case 1: // Voiture
                        Console.Write("\nChevaux fiscaux : ");
                        int cv = int.Parse(Console.ReadLine());
                        Console.Write("Nombre de portes : ");
                        int portes = int.Parse(Console.ReadLine());
                        Console.Write("Nombre de sieges : ");
                        int sieges = int.Parse(Console.ReadLine());
                        Console.Write("Taille du coffre (m3) : ");
                        double coffre = double.Parse(Console.ReadLine());
                        nouveauVehicule = new Voiture(nom, prixHT, marque, moteur, cv, portes, sieges, coffre);
                        break;
                        
                    case 2: // Camion
                        Console.Write("\nNombre d'essieux : ");
                        int essieux = int.Parse(Console.ReadLine());
                        Console.Write("Poids de chargement (tonnes) : ");
                        decimal poids = decimal.Parse(Console.ReadLine());
                        Console.Write("Volume de chargement (m3) : ");
                        decimal volume = decimal.Parse(Console.ReadLine());
                        nouveauVehicule = new Camion(nom, prixHT, marque, moteur, essieux, poids, volume);
                        break;
                        
                    case 3: // Moto
                        Console.Write("\nCylindree (cm3) : ");
                        int cylindree = int.Parse(Console.ReadLine());
                        nouveauVehicule = new Moto(nom, prixHT, marque, moteur, cylindree);
                        break;
                }
                
                if (nouveauVehicule != null)
                {
                    garage.AjouterVehicule(nouveauVehicule);
                    Console.WriteLine("\n[OK] Vehicule ajoute avec succes !");
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Erreur : donnee invalide saisie.");
            }
        }

        private void SupprimerVehicule()
        {
            Console.WriteLine("\n=== SUPPRIMER UN VEHICULE ===\n");
            
            if (garage.Vehicules.Count == 0)
            {
                Console.WriteLine("Aucun vehicule dans le garage.");
                return;
            }
            
            // Afficher la liste
            Console.WriteLine("Vehicules actuels :");
            foreach (var v in garage.Vehicules)
            {
                Console.WriteLine($"  [ID {v.Id}] {v.Nom} - {v.PrixTotal:C}");
            }
            
            try
            {
                Console.Write("\nEntrez l'ID du vehicule a supprimer : ");
                int id = GetChoix();
                
                Vehicule vehicule = garage.Vehicules.FirstOrDefault(v => v.Id == id);
                
                if (vehicule == null)
                {
                    throw new VehiculeNotFoundException($"Aucun vehicule trouve avec l'ID {id}.");
                }
                
                Console.Write($"Confirmer la suppression de '{vehicule.Nom}' ? (o/n) : ");
                string confirmation = Console.ReadLine()?.ToLower();
                
                if (confirmation == "o" || confirmation == "oui")
                {
                    garage.Vehicules.Remove(vehicule);
                    Console.WriteLine($"\n[OK] Vehicule '{vehicule.Nom}' supprime avec succes !");
                }
                else
                {
                    Console.WriteLine("\nSuppression annulee.");
                }
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void SelectionnerVehicule()
        {
            Console.WriteLine("\n=== SELECTIONNER UN VEHICULE ===\n");
            
            if (garage.Vehicules.Count == 0)
            {
                Console.WriteLine("Aucun vehicule dans le garage.");
                return;
            }
            
            // Afficher la liste
            Console.WriteLine("Vehicules disponibles :");
            foreach (var v in garage.Vehicules)
            {
                Console.WriteLine($"  [ID {v.Id}] {v.Nom}");
            }
            
            try
            {
                Console.Write("\nEntrez l'ID du vehicule : ");
                int id = GetChoix();
                
                Vehicule vehicule = garage.Vehicules.FirstOrDefault(v => v.Id == id);
                
                if (vehicule == null)
                {
                    throw new VehiculeNotFoundException($"Aucun vehicule trouve avec l'ID {id}.");
                }
                
                Console.WriteLine("\n--- INFORMATIONS DU VEHICULE ---");
                vehicule.Afficher();
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void AfficherOptionsVehicule()
        {
            Console.WriteLine("\n=== AFFICHER OPTIONS D'UN VEHICULE ===\n");
            
            try
            {
                Console.Write("Entrez l'ID du vehicule : ");
                int id = GetChoix();
                
                Vehicule vehicule = garage.Vehicules.FirstOrDefault(v => v.Id == id);
                
                if (vehicule == null)
                {
                    throw new VehiculeNotFoundException($"Aucun vehicule trouve avec l'ID {id}.");
                }
                
                Console.WriteLine($"\nVehicule selectionne : {vehicule.Nom}");
                vehicule.AfficherOptions();
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void AjouterOptionVehicule()
        {
            Console.WriteLine("\n=== AJOUTER UNE OPTION A UN VEHICULE ===\n");
            
            if (garage.Vehicules.Count == 0)
            {
                Console.WriteLine("Aucun vehicule dans le garage.");
                return;
            }
            
            if (garage.Options.Count == 0)
            {
                Console.WriteLine("Aucune option disponible dans le catalogue.");
                return;
            }
            
            try
            {
                // Sélectionner un véhicule
                Console.WriteLine("Vehicules disponibles :");
                foreach (var v in garage.Vehicules)
                {
                    Console.WriteLine($"  [ID {v.Id}] {v.Nom}");
                }
                Console.Write("\nID du vehicule : ");
                int idVehicule = GetChoix();
                
                Vehicule vehicule = garage.Vehicules.FirstOrDefault(v => v.Id == idVehicule);
                if (vehicule == null)
                {
                    throw new VehiculeNotFoundException($"Aucun vehicule trouve avec l'ID {idVehicule}.");
                }
                
                // Sélectionner une option
                Console.WriteLine("\nOptions disponibles :");
                for (int i = 0; i < garage.Options.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {garage.Options[i]}");
                }
                Console.Write("\nNumero de l'option : ");
                int choixOption = GetChoixMenu(1, garage.Options.Count);
                
                Option option = garage.Options[choixOption - 1];
                vehicule.AjouterOption(option);
                
                Console.WriteLine($"\n[OK] Option '{option.Nom}' ajoutee au vehicule '{vehicule.Nom}' !");
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void SupprimerOptionVehicule()
        {
            Console.WriteLine("\n=== SUPPRIMER UNE OPTION D'UN VEHICULE ===\n");
            
            if (garage.Vehicules.Count == 0)
            {
                Console.WriteLine("Aucun vehicule dans le garage.");
                return;
            }
            
            try
            {
                // Sélectionner un véhicule
                Console.WriteLine("Vehicules disponibles :");
                foreach (var v in garage.Vehicules)
                {
                    Console.WriteLine($"  [ID {v.Id}] {v.Nom} ({v.Options.Count} option(s))");
                }
                Console.Write("\nID du vehicule : ");
                int idVehicule = GetChoix();
                
                Vehicule vehicule = garage.Vehicules.FirstOrDefault(v => v.Id == idVehicule);
                if (vehicule == null)
                {
                    throw new VehiculeNotFoundException($"Aucun vehicule trouve avec l'ID {idVehicule}.");
                }
                
                if (vehicule.Options.Count == 0)
                {
                    Console.WriteLine($"\nLe vehicule '{vehicule.Nom}' n'a aucune option.");
                    return;
                }
                
                // Afficher les options du véhicule
                Console.WriteLine($"\nOptions du vehicule '{vehicule.Nom}' :");
                for (int i = 0; i < vehicule.Options.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {vehicule.Options[i]}");
                }
                Console.Write("\nNumero de l'option a supprimer : ");
                int choixOption = GetChoixMenu(1, vehicule.Options.Count);
                
                Option optionASupprimer = vehicule.Options[choixOption - 1];
                vehicule.Options.Remove(optionASupprimer);
                
                Console.WriteLine($"\n[OK] Option '{optionASupprimer.Nom}' supprimee du vehicule '{vehicule.Nom}' !");
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void AfficherOptions()
        {
            Console.WriteLine("\n=== CATALOGUE DES OPTIONS ===\n");
            
            if (garage.Options.Count == 0)
            {
                Console.WriteLine("Aucune option disponible dans le catalogue.");
            }
            else
            {
                foreach (var option in garage.Options)
                {
                    option.Afficher();
                }
                Console.WriteLine($"\nTotal : {garage.Options.Count} option(s) disponible(s)");
            }
        }

        private void AfficherMarques()
        {
            Console.WriteLine("\n=== MARQUES DISPONIBLES ===\n");
            
            var marques = Enum.GetValues(typeof(Marque));
            int index = 1;
            
            foreach (Marque marque in marques)
            {
                Console.WriteLine($"  {index}. {marque}");
                index++;
            }
            
            Console.WriteLine($"\nTotal : {marques.Length} marque(s) disponible(s)");
        }

        private void AfficherTypesMoteurs()
        {
            Console.WriteLine("\n=== CATALOGUE DES MOTEURS ===\n");
            
            if (garage.Moteurs.Count == 0)
            {
                Console.WriteLine("Aucun moteur disponible dans le catalogue.");
            }
            else
            {
                foreach (var moteur in garage.Moteurs)
                {
                    moteur.Afficher();
                }
                Console.WriteLine($"\nTotal : {garage.Moteurs.Count} moteur(s) disponible(s)");
            }
        }

        private void ChargerGarage()
        {
            Console.WriteLine("\n[TODO] Charger le garage depuis un fichier");
        }

        private void SauvegarderGarage()
        {
            Console.WriteLine("\n[TODO] Sauvegarder le garage dans un fichier");
        }
    }
}
