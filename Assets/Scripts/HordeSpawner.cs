using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HordeSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject hordesTargeting; 
	public float timeBetweenWaves = 5;
	public WaveProfileList waveProfiles = new WaveProfileList();
	private int currentWaveNumber = 0;

	private List<EnemySpawner> waves = new List<EnemySpawner>();
	public float time;

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

