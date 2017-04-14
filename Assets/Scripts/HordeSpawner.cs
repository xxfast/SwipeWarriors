using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HordeSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject hordesTargeting; 
	public float timeBetweenWaves;
	public WaveProfileList waveProfiles = new WaveProfileList();
	public int currentWaveNumber = 0;

	private EnemySpawner currentWave;
	private float time;

	void Start () {
		time = timeBetweenWaves;
		if (waveProfiles.waves!=null && waveProfiles.waves.Count>0) { //waveProfiles.list.Count > 0
			WaveProfile currentProfile = waveProfiles.waves[0];
			waveProfiles.waves.RemoveAt (0);
			if (currentWave != null)
				Destroy (currentWave);
			currentWave = gameObject.AddComponent(typeof(EnemySpawner)) as EnemySpawner;
			currentWave.enabled = true;
			currentWave.attachProfile (currentProfile);
		} else {
			this.enabled = false;
		}
	}
	
	void Update () {
		if((currentWave!=null) && currentWave.hasEnded()){
			time -= Time.deltaTime;
			if (time <= 0) {
				Start ();
			}
		}
	}
}

