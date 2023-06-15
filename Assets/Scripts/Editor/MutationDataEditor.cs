using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ssj12062023
{
    [CustomEditor(typeof(MutationData), true)]
    public class MutationDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            MutationData mutationDataSO = (MutationData)target;

            EditorGUILayout.Space();

            if (GUILayout.Button("Generate UID"))
            {
                mutationDataSO.GenerateUID();
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }

            EditorGUILayout.Space();
        }
    }
}