using UnityEditor;

namespace Game.Common.Editor
{
    [CustomEditor(typeof(SpawnPoint))]
    public class SpawnPointEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SpawnPoint script = (SpawnPoint)target;

            script.Entry = UnityEditor.EditorGUILayout.Toggle("Entry", script.Entry);

            if (script.Entry)
            {
                SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
                foreach (SpawnPoint spawnPoint in spawnPoints)
                {
                    spawnPoint.Entry = false;
                }
                script.Entry = !script.Entry;
            }
        }
    }
}