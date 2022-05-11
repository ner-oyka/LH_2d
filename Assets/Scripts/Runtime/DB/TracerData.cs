using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DB
{
    [CreateAssetMenu(fileName = "TracerData", menuName = "Game/TracerData", order = 1)]
    public class TracerData : ScriptableObject
    {
        public List<GameObject> tracers;
    }

}