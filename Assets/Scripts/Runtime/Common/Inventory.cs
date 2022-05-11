using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Items;
using EventBusSystem;
using Game.Events;

namespace Game.Common
{
    public class Inventory : MonoBehaviour
    {
        public Transform ItemsTransform;

        public List<BaseItem> Items = new List<BaseItem>();

        [NonReorderable]
        public BaseItem[] ShortcutItems = new BaseItem[4];

        private uint currentItemIndex = 0;

        private void Start()
        {
            RefreshItems();
        }

        public void RefreshItems()
        {
            Items.Clear();
            foreach (Transform item in ItemsTransform)
            {
                Items.Add(item.GetComponent<BaseItem>());
            }
        }

        public BaseItem GetSelectedItem()
        {
            return ItemsTransform.GetChild((int)currentItemIndex).GetComponent<BaseItem>();
        }

        public BaseItem FindLigtItemInShortcutItems()
        {
            for (int i = 0; i < ShortcutItems.Length; i++)
            {
                if (ShortcutItems[i] != null && ShortcutItems[i].Type == ItemTypes.Light)
                {
                    return ShortcutItems[i];
                }
            }
            return null;
        }

        public void OpenInventory()
        {
            EventBus.RaiseEvent<IPlayerInventory>(h => h.OnOpenInventory(Items));
        }

        public void CloseInventory()
        {
            EventBus.RaiseEvent<IPlayerInventory>(h => h.OnCloseInventory());
        }
    }
}