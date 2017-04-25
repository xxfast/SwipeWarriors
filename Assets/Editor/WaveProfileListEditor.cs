using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WaveProfileList))]
[CanEditMultipleObjects]
public class WaveProfileListEditor : Editor 
{
	SerializedProperty MyTarget;

	void OnEnable()
	{
        MyTarget = serializedObject.FindProperty("WaveProfiles");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(MyTarget, true);
		serializedObject.ApplyModifiedProperties();
	}
}