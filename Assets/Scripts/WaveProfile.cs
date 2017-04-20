using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wave profile describes how a particular wave of enemies needed to be spawned.
/// </summary>
[System.Serializable]
public class WaveProfile : System.Object {
	[Tooltip("List of prefabs to spawn in")]
	public List<Object> whatToSpawn;
	[Tooltip("Distance where the enemies will be spawned from")]
	public float spawnDistance;
	[Tooltip("Frequency of the enemy spawns in seconds")]
	public float spanwFrequency; 
	[Tooltip("Duration of the enemy spawns in seconds")]
	public float spawnFor;
}
