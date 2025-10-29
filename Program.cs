using System;
using GarageManagementApp.Models;
using GarageManagementApp.Enums;

namespace GarageManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("     APPLICATION GESTION GARAGE - VERSION 1.0");
            Console.WriteLine("     Tests de l'Etape 1 : POO Avancee");
            Console.WriteLine("============================================================\n");

            // === ETAPE 1 : Creation des moteurs ===
            Console.WriteLine(">>> Creation des moteurs...");
            Moteur moteurEssence = new Moteur("1.2 PureTech", 110, TypeMoteur.Essence);
            Moteur moteurDiesel = new Moteur("2.0 BlueHDi", 150, TypeMoteur.Diesel);
            Moteur moteurElectrique = new Moteur("Electrique 150kW", 204, TypeMoteur.Electrique);
            Moteur moteurMoto = new Moteur("V-Twin 1200", 95, TypeMoteur.Essence);
            Console.WriteLine($"[OK] {4} moteurs crees.\n");

            // === ETAPE 2 : Creation des options ===
            Console.WriteLine(">>> Creation des options...");
            Option gps = new Option("GPS Integre", 800);
            Option siegesChauffants = new Option("Sieges Chauffants", 450);
            Option toitOuvrant = new Option("Toit Ouvrant Panoramique", 1200);
            Option attelage = new Option("Attelage Remorque", 650);
            Option abs = new Option("ABS Pro", 300);
            Console.WriteLine($"[OK] {5} options creees.\n");

            // === ETAPE 3 : Creation du garage ===
            Console.WriteLine(">>> Creation du garage...");
            Garage monGarage = new Garage("Garage Central Paris");
            Console.WriteLine($"[OK] Garage '{monGarage.Nom}' cree.\n");

            // === ETAPE 4 : Creation et ajout des voitures ===
            Console.WriteLine(">>> Ajout de voitures...");
            Voiture peugeot208 = new Voiture("Peugeot 208 GT", 22000, Marque.Peugeot, moteurEssence, 6, 5, 5, 0.311);
            peugeot208.AjouterOption(gps);
            peugeot208.AjouterOption(siegesChauffants);
            monGarage.AjouterVehicule(peugeot208);

            Voiture audiA4 = new Voiture("Audi A4 Premium", 45000, Marque.Audi, moteurDiesel, 8, 5, 5, 0.480);
            audiA4.AjouterOption(gps);
            audiA4.AjouterOption(siegesChauffants);
            audiA4.AjouterOption(toitOuvrant);
            monGarage.AjouterVehicule(audiA4);

            Voiture renaultZoe = new Voiture("Renault Zoe E-Tech", 35000, Marque.Renault, moteurElectrique, 4, 5, 5, 0.338);
            renaultZoe.AjouterOption(gps);
            monGarage.AjouterVehicule(renaultZoe);
            Console.WriteLine();

            // === ETAPE 5 : Creation et ajout des camions ===
            Console.WriteLine(">>> Ajout de camions...");
            Camion renaultMaster = new Camion("Renault Master Pro", 38000, Marque.Renault, moteurDiesel, 2, 3.5m, 12);
            renaultMaster.AjouterOption(attelage);
            renaultMaster.AjouterOption(abs);
            monGarage.AjouterVehicule(renaultMaster);

            Camion fordTransit = new Camion("Ford Transit XL", 42000, Marque.Ford, moteurDiesel, 3, 4.2m, 15);
            fordTransit.AjouterOption(gps);
            fordTransit.AjouterOption(attelage);
            monGarage.AjouterVehicule(fordTransit);
            Console.WriteLine();

            // === ETAPE 6 : Creation et ajout des motos ===
            Console.WriteLine(">>> Ajout de motos...");
            Moto bmwR1200 = new Moto("BMW R1200 GS", 18000, Marque.BMW, moteurMoto, 1200);
            bmwR1200.AjouterOption(abs);
            monGarage.AjouterVehicule(bmwR1200);

            Moto ducati = new Moto("Ducati Monster 821", 12000, Marque.Ferrari, moteurMoto, 821);
            monGarage.AjouterVehicule(ducati);
            Console.WriteLine();

            // === ETAPE 7 : Affichage initial du garage ===
            Console.WriteLine("\n" + new string('=', 62));
            Console.WriteLine(">>> AFFICHAGE INITIAL DU GARAGE (non trie)");
            Console.WriteLine(new string('=', 62));
            monGarage.Afficher();

            // === ETAPE 8 : Test des filtres ===
            Console.WriteLine("\n>>> Test des filtres par type de vehicule :");
            Console.WriteLine(new string('-', 62));
            monGarage.AfficherVoiture();
            Console.WriteLine();
            monGarage.AfficherCamion();
            Console.WriteLine();
            monGarage.AfficherMoto();

            // === ETAPE 9 : Tri des vehicules ===
            Console.WriteLine("\n" + new string('=', 62));
            Console.WriteLine(">>> TRI DES VEHICULES PAR PRIX TOTAL");
            Console.WriteLine(new string('=', 62));
            monGarage.TrierVehicule();
            Console.WriteLine();

            // === ETAPE 10 : Affichage apres tri ===
            Console.WriteLine(new string('=', 62));
            Console.WriteLine(">>> AFFICHAGE APRES TRI (ordre croissant de prix)");
            Console.WriteLine(new string('=', 62));
            monGarage.Afficher();

            // === FIN ===
            Console.WriteLine("\n============================================================");
            Console.WriteLine("  [OK] Tests de l'Etape 1 termines avec succes !");
            Console.WriteLine("============================================================");
            
            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}
