using System;
using System.Collections.Generic;
using System.Linq;
using TopengineerPlugin.Models;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Core
{
    /// <summary>
    /// Manages catalogs of bolts, profiles, and materials according to GOST standards
    /// </summary>
    public class CatalogManager
    {
        private Logger _logger;
        private List<Bolt> _boltsCatalog;
        private List<Profile> _profilesCatalog;
        private List<Material> _materialsCatalog;

        public CatalogManager()
        {
            _logger = new Logger("CatalogManager");
            _boltsCatalog = new List<Bolt>();
            _profilesCatalog = new List<Profile>();
            _materialsCatalog = new List<Material>();

            InitializeDefaultCatalogs();
        }

        /// <summary>
        /// Initialize default GOST catalogs
        /// </summary>
        private void InitializeDefaultCatalogs()
        {
            try
            {
                _logger.Log("Initializing default GOST catalogs");
                InitializeBoltsCatalog();
                InitializeProfilesCatalog();
                InitializeMaterialsCatalog();
                _logger.Log("Default catalogs initialized successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error initializing catalogs: {ex.Message}");
            }
        }

        private void InitializeBoltsCatalog()
        {
            // ГОСТ 7798 - Болты с шестигранной головкой
            _boltsCatalog.Add(new Bolt
            {
                Id = 1,
                Diameter = 6,
                Length = 20,
                Pitch = 1.0,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "5.8",
                IsHighStrength = false,
                MassPerPiece = 4.5
            });

            _boltsCatalog.Add(new Bolt
            {
                Id = 2,
                Diameter = 8,
                Length = 25,
                Pitch = 1.25,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "5.8",
                IsHighStrength = false,
                MassPerPiece = 9.2
            });

            _boltsCatalog.Add(new Bolt
            {
                Id = 3,
                Diameter = 10,
                Length = 30,
                Pitch = 1.5,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "8.8",
                IsHighStrength = false,
                MassPerPiece = 15.6
            });

            _boltsCatalog.Add(new Bolt
            {
                Id = 4,
                Diameter = 12,
                Length = 40,
                Pitch = 1.75,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "8.8",
                IsHighStrength = false,
                MassPerPiece = 27.2
            });

            _boltsCatalog.Add(new Bolt
            {
                Id = 5,
                Diameter = 16,
                Length = 50,
                Pitch = 2.0,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "10.9",
                IsHighStrength = true,
                MassPerPiece = 61.8
            });

            _logger.Log($"Bolts catalog initialized with {_boltsCatalog.Count} items");
        }

        private void InitializeProfilesCatalog()
        {
            // ГОСТ 8239 - Двутавры
            _profilesCatalog.Add(new Profile
            {
                Id = 1,
                Type = Profile.ProfileType.IBeam,
                GOSTDesignation = "I20B1",
                EnglishDesignation = "I20B1",
                Height = 200,
                Width = 90,
                FlangeThickness = 8.4,
                WebThickness = 5.2,
                MassPerMeter = 21.9,
                IsRolled = true,
                GOSTStandard = "8239-89"
            });

            _profilesCatalog.Add(new Profile
            {
                Id = 2,
                Type = Profile.ProfileType.IBeam,
                GOSTDesignation = "I25B1",
                EnglishDesignation = "I25B1",
                Height = 250,
                Width = 110,
                FlangeThickness = 10.0,
                WebThickness = 6.2,
                MassPerMeter = 32.0,
                IsRolled = true,
                GOSTStandard = "8239-89"
            });

            // ГОСТ 8240 - Швеллеры
            _profilesCatalog.Add(new Profile
            {
                Id = 3,
                Type = Profile.ProfileType.Channel,
                GOSTDesignation = "C20B1",
                EnglishDesignation = "C20B1",
                Height = 200,
                Width = 70,
                FlangeThickness = 8.4,
                WebThickness = 5.0,
                MassPerMeter = 18.4,
                IsRolled = true,
                GOSTStandard = "8240-89"
            });

            // ГОСТ 8509 - Уголки
            _profilesCatalog.Add(new Profile
            {
                Id = 4,
                Type = Profile.ProfileType.Angle,
                GOSTDesignation = "L50×50×4",
                EnglishDesignation = "L50x50x4",
                Height = 50,
                Width = 50,
                FlangeThickness = 4.0,
                WebThickness = 4.0,
                MassPerMeter = 3.07,
                IsRolled = true,
                GOSTStandard = "8509-93"
            });

            _logger.Log($"Profiles catalog initialized with {_profilesCatalog.Count} items");
        }

        private void InitializeMaterialsCatalog()
        {
            _materialsCatalog.Add(new Material
            {
                Id = 1,
                Type = Material.MaterialType.Steel,
                GOSTDesignation = "Сталь 3",
                EnglishDesignation = "Steel 3",
                GOSTStandard = "535-88",
                Density = 7850,
                YieldStrength = 235,
                TensileStrength = 360,
                ElasticityModulus = 210,
                ColorCode = "#555555"
            });

            _materialsCatalog.Add(new Material
            {
                Id = 2,
                Type = Material.MaterialType.Steel,
                GOSTDesignation = "Сталь 09Г2С",
                EnglishDesignation = "Steel 09G2S",
                GOSTStandard = "19281-89",
                Density = 7850,
                YieldStrength = 330,
                TensileStrength = 490,
                ElasticityModulus = 210,
                ColorCode = "#666666"
            });

            _materialsCatalog.Add(new Material
            {
                Id = 3,
                Type = Material.MaterialType.Steel,
                GOSTDesignation = "Сталь 15ХСНД",
                EnglishDesignation = "Steel 15KHSND",
                GOSTStandard = "4543-71",
                Density = 7850,
                YieldStrength = 490,
                TensileStrength = 620,
                ElasticityModulus = 210,
                ColorCode = "#444444"
            });

            _logger.Log($"Materials catalog initialized with {_materialsCatalog.Count} items");
        }

        /// <summary>
        /// Get bolt by diameter and length
        /// </summary>
        public Bolt GetBolt(double diameter, double length)
        {
            return _boltsCatalog.FirstOrDefault(b => 
                Math.Abs(b.Diameter - diameter) < 0.1 && 
                Math.Abs(b.Length - length) < 0.1);
        }

        /// <summary>
        /// Find valid bolt length
        /// </summary>
        public double FindValidBoltLength(double diameter, double requestedLength)
        {
            var bolt = _boltsCatalog.FirstOrDefault(b => Math.Abs(b.Diameter - diameter) < 0.1);
            if (bolt == null)
                return requestedLength;

            return bolt.GetNearestValidLength();
        }

        /// <summary>
        /// Get profile by designation
        /// </summary>
        public Profile GetProfile(string designation)
        {
            return _profilesCatalog.FirstOrDefault(p => p.GOSTDesignation == designation);
        }

        /// <summary>
        /// Search profiles by type
        /// </summary>
        public List<Profile> SearchProfiles(Profile.ProfileType type)
        {
            return _profilesCatalog.Where(p => p.Type == type).ToList();
        }

        /// <summary>
        /// Get material by designation
        /// </summary>
        public Material GetMaterial(string designation)
        {
            return _materialsCatalog.FirstOrDefault(m => m.GOSTDesignation == designation);
        }

        /// <summary>
        /// Add custom bolt to catalog
        /// </summary>
        public void AddCustomBolt(Bolt bolt)
        {
            bolt.Id = _boltsCatalog.Count + 1;
            _boltsCatalog.Add(bolt);
            _logger.Log($"Added custom bolt: {bolt.GetDisplayName()}");
        }

        /// <summary>
        /// Add custom profile to catalog
        /// </summary>
        public void AddCustomProfile(Profile profile)
        {
            profile.Id = _profilesCatalog.Count + 1;
            _profilesCatalog.Add(profile);
            _logger.Log($"Added custom profile: {profile.GetDisplayName()}");
        }

        /// <summary>
        /// Get all bolts
        /// </summary>
        public List<Bolt> GetAllBolts()
        {
            return new List<Bolt>(_boltsCatalog);
        }

        /// <summary>
        /// Get all profiles
        /// </summary>
        public List<Profile> GetAllProfiles()
        {
            return new List<Profile>(_profilesCatalog);
        }

        /// <summary>
        /// Get all materials
        /// </summary>
        public List<Material> GetAllMaterials()
        {
            return new List<Material>(_materialsCatalog);
        }
    }
}
