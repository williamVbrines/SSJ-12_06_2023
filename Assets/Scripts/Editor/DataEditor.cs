using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ssj12062023
{
    [CustomEditor(typeof(Data), true)]
    public class DataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Data dataSO = (Data)target;

            EditorGUILayout.Space();

            if (GUILayout.Button("Generate UID"))
            {
                dataSO.GenerateUID();
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }

            EditorGUILayout.Space();
        }
    }
}