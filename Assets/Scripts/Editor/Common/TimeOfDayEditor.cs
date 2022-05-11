using UnityEditor;

namespace Game.Common.Editor
{
    [CustomEditor(typeof(TimeOfDay))]
    public class TimeOfDayEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TimeOfDay timeOfDay = (TimeOfDay)target;
            timeOfDay.UpdateTime();
        }
    }

}