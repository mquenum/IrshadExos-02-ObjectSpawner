using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Tells Unity to use this Editor class with the GameManager component.
[CustomEditor(typeof(GameManager))]
// inherits Editor and not MonoBehaviour since it is an editor script
public class ObjectSpawnerEditor : Editor
{
    // create enum (for "enumeration") with option to show in editor
    public enum ObjectCategory
    {
        Primitives, Prefab
    }

    // The field that will determine what variables to display in the Inspector
    public ObjectCategory objectCategory;

    // The function that makes the custom editor work
    public override void OnInspectorGUI()
    {
        // Display the enum popup in the inspector
        objectCategory = (ObjectCategory)EditorGUILayout.EnumPopup("Object to Spawn", objectCategory);
        // Create a space to separate this enum popup from the other variables 
        EditorGUILayout.Space();

        switch (objectCategory)
        {
            case ObjectCategory.Primitives:
                DisplayAllPrimitivesInfo();
                break;
            case ObjectCategory.Prefab:
                DisplayPrefabInfo();
                break;
        }

        // Save all changes made on the Inspector
        serializedObject.ApplyModifiedProperties();
    }

    //When the objectCategory enum is at anything but "Prefab"
    void DisplayAllPrimitivesInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cube"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_sphere"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_capsule"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cylinder"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_plane"));
    }
    void DisplayCubeInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cube"));
    }

    void DisplaySphereInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_sphere"));
    }

    void DisplayCapsuleInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_capsule"));
    }

    void DisplayCylinderInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cylinder"));
    }

    void DisplayPlaneInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_plane"));
    }

    void DisplayPrefabInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_prefab"));
    }
}
