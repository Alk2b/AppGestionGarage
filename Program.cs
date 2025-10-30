using System;
using GarageManagementApp.Models;
using GarageManagementApp.Enums;
using GarageManagementApp.Services;

namespace GarageManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("     APPLICATION GESTION GARAGE - VERSION 1.0");
            Console.WriteLine("     Initialisation du garage...");
            Console.WriteLine("============================================================\n");

            // === Creation du garage ===
            Garage monGarage = new Garage("Garage Central Paris");

            // === Ajout des moteurs au catalogue ===
            Moteur moteurEssence = new Moteur("1.2 PureTech", 110, TypeMoteur.Essence);
            Moteur moteurDiesel = new Moteur("2.0 BlueHDi", 150, TypeMoteur.Diesel);
            Moteur moteurElectrique = new Moteur("Electrique 150kW", 204, TypeMoteur.Electrique);
            Moteur moteurMoto = new Moteur("V-Twin 1200", 95, TypeMoteur.Essence);
            
            monGarage.AjouterMoteur(moteurEssence);
            monGarage.AjouterMoteur(moteurDiesel);
            monGarage.AjouterMoteur(moteurElectrique);
            monGarage.AjouterMoteur(moteurMoto);

            // === Ajout des options au catalogue ===
            Option gps = new Option("GPS Integre", 800);
            Option siegesChauffants = new Option("Sieges Chauffants", 450);
            Option toitOuvrant = new Option("Toit Ouvrant Panoramique", 1200);
            Option attelage = new Option("Attelage Remorque", 650);
            Option abs = new Option("ABS Pro", 300);
            
            monGarage.AjouterOption(gps);
            monGarage.AjouterOption(siegesChauffants);
            monGarage.AjouterOption(toitOuvrant);
            monGarage.AjouterOption(attelage);
            monGarage.AjouterOption(abs);

            // === Ajout de quelques vehicules de demonstration ===
            Voiture peugeot208 = new Voiture("Peugeot 208 GT", 22000, Marque.Peugeot, moteurEssence, 6, 5, 5, 0.311);
            peugeot208.AjouterOption(gps);
            monGarage.AjouterVehicule(peugeot208);

            Camion renaultMaster = new Camion("Renault Master Pro", 38000, Marque.Renault, moteurDiesel, 2, 3.5m, 12);
            monGarage.AjouterVehicule(renaultMaster);

            Console.WriteLine("\n[OK] Garage initialise avec succes !");
            Console.WriteLine($"     - {monGarage.Moteurs.Count} moteurs disponibles");
            Console.WriteLine($"     - {monGarage.Options.Count} options disponibles");
            Console.WriteLine($"     - {monGarage.Vehicules.Count} vehicules en stock");
            
            Console.WriteLine("\nAppuyez sur une touche pour acceder au menu...");
            Console.ReadKey();

            // === Lancement du menu interactif ===
            Menu menu = new Menu(monGarage);
            menu.Start();
        }
    }
}
