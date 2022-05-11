using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{
    public class WeaponController : MonoBehaviour
    {
        private Common.Inventory inventory;

        private Items.Weapon currentWeapon;

        private void Start()
        {
            inventory = GetComponent<Common.Inventory>();
        }

        public void StartShoot()
        {
            Items.BaseItem item = inventory.GetSelectedItem();
            currentWeapon = item as Items.Weapon;
            if (currentWeapon != null)
            {
                currentWeapon.StartShoot(Player.PlayerInputManager.instance.MouseWorldPosition);
            }
        }

        public void StopShoot()
        {
            currentWeapon.StopShoot();
        }

        public void UpdateShoot()
        {
            currentWeapon.SetTarget(Player.PlayerInputManager.instance.MouseWorldPosition);
            currentWeapon.UpdateWeapon();
        }
    }

}