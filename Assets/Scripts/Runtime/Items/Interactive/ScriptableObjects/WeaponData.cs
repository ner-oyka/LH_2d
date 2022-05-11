using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    [CreateAssetMenu(fileName = "weapon", menuName = "Game/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        [Header("Base data")]
        public uint AmmunitionType;

        public float Damage;

        public float BaseScattering = 0.1f; //final scattering = base scattering / (scattering skill[1..100] / 100)

        [Range(0.5f, 10)] 
        public float ReloadTime;

        [Range(0.01f, 25)] 
        public float FireRate;

        [Header("Id prefabs group")]
        public DB.TracerData TracersData;
        public uint FireTypeId;
        public uint HitEffectTypeId;
        public uint DecalTypeId;

        [Header("Inventory data")]
        public string Id;
        public Sprite Icon;
        public string Name;
        public string Description;
    }
}
