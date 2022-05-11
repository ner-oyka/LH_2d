using EventBusSystem;
using Game.Items;
using System.Collections.Generic;

namespace Game.Events
{
    public interface IPlayerInventory : IGlobalSubscriber
    {
        void OnOpenInventory(in List<BaseItem> items);
        void OnCloseInventory();
    }
}
