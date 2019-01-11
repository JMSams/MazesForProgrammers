using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Mazes_for_Programmers
{
    [CustomEditor(typeof(Tester))]
    public class TesterEditor : Editor
    {
        bool spritesUnfolded = false;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            spritesUnfolded = EditorGUILayout.Foldout(spritesUnfolded, "Sprites");

            if (spritesUnfolded)
            {
                EditorGUI.indentLevel++;
                #region Sprites
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_none"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_east"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_south"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north_south"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_east_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north_east"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_south_east"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_south_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north_east_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_south_east_west"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_east_north_south"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_west_north_south"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sprites_north_south_east_west"));
                #endregion
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("columnCount"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rowCount"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("delayTime"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}