using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WaveProfileList))]
[CanEditMultipleObjects]
public class WaveProfileListEditor : Editor 
{
	SerializedProperty myTarget;

	void OnEnable()
	{
		myTarget = serializedObject.FindProperty("waveProfiles");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(myTarget,true);
		serializedObject.ApplyModifiedProperties();
	}
}