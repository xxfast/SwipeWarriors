using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wave profile describes how a particular wave of enemies needed to be spawned.
/// </summary>
[System.Serializable]
public class WaveProfile : System.Object {
	[Tooltip("List of prefabs to spawn in")]
	/// <summary>
	/// List of prefabs gameobjects to spawn.
	/// </summary>
	public List<Object> whatToSpawn;

	[Tooltip("Distance where the enemies will be spawned from")]
	/// <summary>
	/// Distance from the target to spawn the enemies from
	/// </summary>
	public float spawnDistance;

	[Tooltip("Frequency of the enemy spawns in seconds")]
	/// <summary>
	/// Frequency of the enemy spawns in seconds
	/// </summary>
	public float spanwFrequency; 

	[Tooltip("Duration of the enemy spawns in seconds")]
	/// <summary>
	/// Duration of the enemy spawns in seconds
	/// </summary>
	public float spawnFor;
}
