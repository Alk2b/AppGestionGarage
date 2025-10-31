# Garage Management Application

## Overview
Application de gestion de garage développée en C# (.NET 9.0) dans le cadre d'un TP avancé de Programmation Orientée Objet. Le projet met en œuvre des concepts avancés tels que l'héritage, les classes abstraites, les interfaces (`IComparable`), la gestion d'exceptions personnalisées et la sérialisation JSON avec polymorphisme.

## Fonctionnalités
- **Gestion complète de véhicules** : Voitures, Camions et Motos avec calcul automatique des taxes
- **Catalogue de moteurs** : Gestion des types de moteurs (Diesel, Essence, Hybride, Électrique)
- **Système d'options** : Ajout/Suppression d'options aux véhicules (Climatisation, GPS, ABS, etc.)
- **Menu interactif** : 13 options avec validation des entrées et gestion d'erreurs
- **Tri intelligent** : Tri des véhicules par prix total via `IComparable<Vehicule>`
- **Persistance JSON** : Sauvegarde/Chargement avec support du polymorphisme (`[JsonDerivedType]`)
- **Exceptions personnalisées** : `MenuException`, `VehiculeNotFoundException`, `OptionNotFoundException`, `MoteurNotFoundException`

## Architecture du projet
```
GarageManagementApp/
├── Program.cs
├── Enums/
│   ├── Marque.cs
│   └── TypeMoteur.cs
├── Models/
│   ├── Option.cs
│   ├── Moteur.cs
│   ├── Vehicule.cs
│   ├── Voiture.cs
│   ├── Camion.cs
│   ├── Moto.cs
│   └── Garage.cs
├── Services/
│   └── Menu.cs
├── Exceptions/
│   ├── MenuException.cs
│   ├── VehiculeNotFoundException.cs
│   ├── OptionNotFoundException.cs
│   └── MoteurNotFoundException.cs
├── garage_test.json
├── garage_vide.json
└── GarageManagementApp.csproj
```

## Concepts POO avancés implémentés

### 1. Classes abstraites et héritage
```csharp
public abstract class Vehicule : IComparable<Vehicule>
{
    public abstract decimal CalculerTaxe();
    public decimal PrixTotal => PrixHT + Options.Sum(o => o.Prix) + CalculerTaxe();
}
```

### 2. Interface IComparable pour le tri
```csharp
public int CompareTo(Vehicule? other) => this.PrixTotal.CompareTo(other.PrixTotal);
```

### 3. Polymorphisme JSON avec System.Text.Json
```csharp
[JsonDerivedType(typeof(Voiture), "voiture")]
[JsonDerivedType(typeof(Camion), "camion")]
[JsonDerivedType(typeof(Moto), "moto")]
public abstract class Vehicule { ... }
```

### 4. ID auto-incrémentés
```csharp
private static int _increment = 0;
public int Id { get; private set; }
public Option(string nom, decimal prix) { Id = ++_increment; ... }
```

## Installation et utilisation

### Prérequis
- .NET 9.0 SDK
- Git

### Installation
```bash
git clone git@github.com:Alk2b/AppGestionGarage.git
cd AppGestionGarage
dotnet restore
dotnet build
```

### Lancement
```bash
dotnet run
```

### Test avec fichiers JSON
```bash
# Charger le garage de test (3 véhicules pré-configurés)
Menu : 11 → Nom : garage_test

# Charger un garage vide
Menu : 11 → Nom : garage_vide

# Sauvegarder vos modifications
Menu : 12 → Nom : ma_sauvegarde
```

## Menu principal

```
1.  Afficher les véhicules (avec option de tri)
2.  Ajouter un véhicule (Voiture/Camion/Moto)
3.  Supprimer un véhicule
4.  Sélectionner un véhicule (détails)
5.  Afficher les options d'un véhicule
6.  Ajouter des options à un véhicule
7.  Supprimer des options d'un véhicule
8.  Afficher les options (catalogue)
9.  Afficher les marques
10. Afficher les types de moteurs
11. Charger le garage (depuis JSON)
12. Sauvegarder le garage (vers JSON)
13. Quitter l'application
```

## Historique des commits

| Commit | Description |
|--------|-------------|
| 3ced9e5 | Initial commit: Project setup |
| ecc646e | Add core data models (Enums + Option, Moteur) |
| c18027e | Implement abstract Vehicule + children |
| 0239783 | Implement Garage class |
| e1f1074 | Fix Math.Floor namespace issue |
| 04c86fd | Add Menu structure + exception handling |
| 99060c9 | Implement display methods in Menu |
| f6a368e | Implement add/delete methods in Menu |
| e83fb6c | Add JSON serialization to Garage class |
| 86bda9b | Implement load/save menu options |

## Auteur
**Alk2b** - [GitHub](https://github.com/Alk2b/AppGestionGarage)

## Licence
Ce projet est développé dans le cadre d'un TP académique en C# .NET intermédiaire.