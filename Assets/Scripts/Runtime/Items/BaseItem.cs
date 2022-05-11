using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    public enum ItemTypes
    {
        None,
        Weapon,
        Light
    }

    public class BaseItem : MonoBehaviour
    {
        public ItemTypes Type;

        [Min(1)]
        public uint widthCells = 1;
        [Min(1)]
        public uint heightCells = 1;
    }
}
