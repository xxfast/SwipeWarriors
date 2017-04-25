using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WaveProfile))]
[CanEditMultipleObjects]
public class WaveProfileEditor : Editor 
{
	SerializedProperty MyTarget;

	void OnEnable()
	{
        MyTarget = serializedObject.FindProperty("WaveProfile");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(MyTarget, true);
		serializedObject.ApplyModifiedProperties();
	}
}