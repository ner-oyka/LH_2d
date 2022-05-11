using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using EventBusSystem;
using Game.Events;
using Game.Common.UI;

namespace Game.UI
{
    public class PlayerInventoryCanvas : BaseInventoryCanvas, IPlayerInventory
    {
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }      

        public void OnOpenInventory(in List<BaseItem> items)
        {
            if (InventoryCanvas)
            {
                InventoryCanvas.SetActive(true);
                RefreshItems(items);
            }

        }

        public void OnCloseInventory()
        {
            InventoryCanvas.SetActive(false);
        }
    }
}