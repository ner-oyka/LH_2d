using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common.EditorGUILayout
{
    [CustomEditor(typeof(Trigger))]
    public class TriggerEditor : UnityEditor.Editor
    {
        private GUILayoutOption[] delayFieldOptions;

        private void OnEnable()
        {
            delayFieldOptions = new GUILayoutOption[]
            {
                GUILayout.Width(48),
            };
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Trigger script = (Trigger)target;

            script.UseTimeout = UnityEditor.EditorGUILayout.Toggle("Use Timeout", script.UseTimeout);

            if (script.UseTimeout)
            {
                script.Delay = UnityEditor.EditorGUILayout.FloatField(script.Delay, delayFieldOptions);
            }
        }
    }
}
