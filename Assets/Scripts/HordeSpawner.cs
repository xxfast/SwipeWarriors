using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HordeSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject hordesTargeting; 

	[Header("Horde Settings")]
	/// <summary>
	/// Determines time between waves.
	/// </summary>
	public float timeBetweenWaves = 5;

	[Header("Wave Descriptions")]
	[Tooltip("Wave descriptions describing each of the waves")]
	/// <summary>
	/// Wave descriptions describing each of the waves
	/// </summary>
	public WaveProfileList waveProfiles = new WaveProfileList();

	/// <summary>
	/// The current wave number.
	/// </summary>
	private int currentWaveNumber = 0;

	private List<EnemySpawner> waves = new List<EnemySpawner>();
	private float time;

	void Start(){
		time = timeBetweenWaves;
	}

	void Update () {
		if ((waves.Count == 0) || waves [currentWaveNumber-1].hasEnded ()) {
			time -= Time.deltaTime;
			if (time <= 0) {
				time = timeBetweenWaves;
				CommenseHorde ();
			}
		}
	}

	/// <summary>
	/// Commenses a horde of invaders.
	/// </summary>
	void CommenseHorde () {
		if (waveProfiles.waves != null && waveProfiles.waves.Count > 0) { 
			waves.Add (gameObject.AddComponent (typeof(EnemySpawner)) as EnemySpawner);
			WaveProfile currentProfile = waveProfiles.waves [currentWaveNumber];
			waves [currentWaveNumber].enabled = true;
			waves [currentWaveNumber].attachProfile (currentProfile);
			waves [currentWaveNumber].target = hordesTargeting;
			waves [currentWaveNumber].id = currentWaveNumber;
			currentWaveNumber++;
		} else {
			this.enabled = false;
		}
	}

}

