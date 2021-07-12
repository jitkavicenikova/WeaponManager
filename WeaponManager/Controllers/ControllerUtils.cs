using System;
using System.Collections.Generic;
using System.Linq;
using WeaponManager.Models;

namespace WeaponManager.Controllers
{
    public static class ControllerUtils
    {
        public static List<ColdWeapon> FilterAndOrder(List<ColdWeapon> weapons, string sortOrder, string searchName, int? price)
        {
            if (!String.IsNullOrEmpty(searchName))
            {
                weapons = weapons.Where(s => s.Name.Contains(searchName)).ToList();
            }
            if (price != null)
            {
                weapons = weapons.Where(w => w.Price >= price).ToList();
            }

            return sortOrder switch
            {
                "Name" => weapons.OrderBy(s => s.Name).ToList(),
                "name_desc" => weapons.OrderByDescending(s => s.Name).ToList(),
                "weight_desc" => weapons.OrderByDescending(s => s.Weight).ToList(),
                "Weight" => weapons.OrderBy(s => s.Weight).ToList(),
                "blade_desc" => weapons.OrderByDescending(s => s.BladeLength).ToList(),
                "BladeLength" => weapons.OrderBy(s => s.BladeLength).ToList(),
                "type_desc" => weapons.OrderByDescending(s => s.Type).ToList(),
                "Type" => weapons.OrderBy(s => s.Type).ToList(),
                "price_desc" => weapons.OrderByDescending(s => s.Price).ToList(),
                "Price" => weapons.OrderBy(s => s.Price).ToList(),
                _ => weapons,
            };
        }

        public static List<Pistol> FilterAndOrder(List<Pistol> weapons, string sortOrder, string searchName, int? price)
        {
            if (!String.IsNullOrEmpty(searchName))
            {
                weapons = weapons.Where(s => s.Name.Contains(searchName)).ToList();
            }
            if (price != null)
            {
                weapons = weapons.Where(w => w.Price >= price).ToList();
            }

            return sortOrder switch
            {
                "Name" => weapons.OrderBy(s => s.Name).ToList(),
                "name_desc" => weapons.OrderByDescending(s => s.Name).ToList(),
                "weight_desc" => weapons.OrderByDescending(s => s.Weight).ToList(),
                "Weight" => weapons.OrderBy(s => s.Weight).ToList(),
                "muzzle_desc" => weapons.OrderByDescending(s => s.MuzzleVelocity).ToList(),
                "MuzzleVelocity" => weapons.OrderBy(s => s.MuzzleVelocity).ToList(),
                "magazine_desc" => weapons.OrderByDescending(s => s.MagazineCapacity).ToList(),
                "MagazineCapacity" => weapons.OrderBy(s => s.MagazineCapacity).ToList(),
                "type_desc" => weapons.OrderByDescending(s => s.PistolType).ToList(),
                "PistolType" => weapons.OrderBy(s => s.PistolType).ToList(),
                "range_desc" => weapons.OrderByDescending(s => s.PistolRange).ToList(),
                "PistolRange" => weapons.OrderBy(s => s.PistolRange).ToList(),
                "price_desc" => weapons.OrderByDescending(s => s.Price).ToList(),
                "Price" => weapons.OrderBy(s => s.Price).ToList(),
                _ => weapons,
            };
        }

        public static List<Rifle> FilterAndOrder(List<Rifle> weapons, string sortOrder, string searchName, int? price)
        {
            if (!String.IsNullOrEmpty(searchName))
            {
                weapons = weapons.Where(s => s.Name.Contains(searchName)).ToList();
            }
            if (price != null)
            {
                weapons = weapons.Where(w => w.Price >= price).ToList();
            }

            return sortOrder switch
            {
                "Name" => weapons.OrderBy(s => s.Name).ToList(),
                "name_desc" => weapons.OrderByDescending(s => s.Name).ToList(),
                "muzzle_desc" => weapons.OrderByDescending(s => s.MuzzleVelocity).ToList(),
                "MuzzleVelocity" => weapons.OrderBy(s => s.MuzzleVelocity).ToList(),
                "magazine_desc" => weapons.OrderByDescending(s => s.MagazineCapacity).ToList(),
                "MagazineCapacity" => weapons.OrderBy(s => s.MagazineCapacity).ToList(),
                "caliber_desc" => weapons.OrderByDescending(s => s.Caliber).ToList(),
                "Caliber" => weapons.OrderBy(s => s.Caliber).ToList(),
                "type_desc" => weapons.OrderByDescending(s => s.RifleType).ToList(),
                "RifleType" => weapons.OrderBy(s => s.RifleType).ToList(),
                "length_desc" => weapons.OrderByDescending(s => s.RifleLength).ToList(),
                "RifleLength" => weapons.OrderBy(s => s.RifleLength).ToList(),
                "price_desc" => weapons.OrderByDescending(s => s.Price).ToList(),
                "Price" => weapons.OrderBy(s => s.Price).ToList(),
                _ => weapons,
            };
        }
    }
}
