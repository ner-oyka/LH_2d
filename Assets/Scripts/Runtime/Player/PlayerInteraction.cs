using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Items;
using NodeCanvas.StateMachines;

namespace Game.Player
{
    public class PlayerInteraction : MonoBehaviour, IPlayerInteraction
    {
        private Common.Inventory inventory;
        private FSMOwner m_playerFSM;

        private void Start()
        {
            inventory = GetComponent<Common.Inventory>();
            m_playerFSM = GetComponent<FSMOwner>();
        }

        public void QuickSelectItem(uint index)
        {

        }

        public void StartUseMain()
        {
            BaseItem item = inventory.GetSelectedItem();

            switch (item.Type)
            {
                case ItemTypes.Weapon:
                    m_playerFSM.SendEvent("OnStartShoot");
                    break;
            }
        }
        public void StopUseMain()
        {
            BaseItem item = inventory.GetSelectedItem();

            switch (item.Type)
            {
                case ItemTypes.Weapon:
                    m_playerFSM.SendEvent("OnStopShoot");
                    break;
            }
        }

        public void StartUseSecond()
        {
            BaseItem item = inventory.GetSelectedItem();

            switch (item.Type)
            {
                case ItemTypes.Weapon:
                    m_playerFSM.SendEvent("OnStartAiming");
                    break;
            }
        }

        public void StopUseSecond()
        {
            BaseItem item = inventory.GetSelectedItem();

            switch (item.Type)
            {
                case ItemTypes.Weapon:
                    m_playerFSM.SendEvent("OnStopAiming");
                    break;
            }
        }

        public void UseSelectedItem()
        {
            BaseItem item = inventory.GetSelectedItem();

            switch (item.Type)
            {
                case ItemTypes.Weapon:
                    BaseItem lightItem = inventory.FindLigtItemInShortcutItems();
                    if (lightItem != null)
                    {
                        lightItem.transform.gameObject.SetActive(!lightItem.transform.gameObject.activeSelf);
                    }
                    break;
            }
        }
    }

}