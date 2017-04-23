using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WaveProfile))]
[CanEditMultipleObjects]
public class WaveProfileEditor : Editor 
{
	SerializedProperty myTarget;

	void OnEnable()
	{
		myTarget = serializedObject.FindProperty("waveProfile");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(myTarget,true);
		serializedObject.ApplyModifiedProperties();
	}
}