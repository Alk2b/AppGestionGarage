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
            Console.WriteLine("\n[TODO] Afficher les vehicules");
        }

        private void AjouterVehicule()
        {
            Console.WriteLine("\n[TODO] Ajouter un vehicule");
        }

        private void SupprimerVehicule()
        {
            Console.WriteLine("\n[TODO] Supprimer un vehicule");
        }

        private void SelectionnerVehicule()
        {
            Console.WriteLine("\n[TODO] Selectionner un vehicule");
        }

        private void AfficherOptionsVehicule()
        {
            Console.WriteLine("\n[TODO] Afficher options d'un vehicule");
        }

        private void AjouterOptionVehicule()
        {
            Console.WriteLine("\n[TODO] Ajouter option a un vehicule");
        }

        private void SupprimerOptionVehicule()
        {
            Console.WriteLine("\n[TODO] Supprimer option d'un vehicule");
        }

        private void AfficherOptions()
        {
            Console.WriteLine("\n[TODO] Afficher le catalogue d'options");
        }

        private void AfficherMarques()
        {
            Console.WriteLine("\n[TODO] Afficher les marques");
        }

        private void AfficherTypesMoteurs()
        {
            Console.WriteLine("\n[TODO] Afficher les types de moteurs");
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
