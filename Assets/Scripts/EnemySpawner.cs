using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int id;
	public float spawnDistance = 10;
	public float spanwFrequency = 3.0f; 
	public float spawnFor = 10.0f;
	public List<Object> whatToSpawn = new List<Object> ();
	private float respawnTime;
	private float waveTime;

	public GameObject target;

	public EnemySpawner(WaveProfile toAttach){
		attachProfile (toAttach);
	}

	void Start () {
		respawnTime = spanwFrequency;
		waveTime = spawnFor;
	}
	
	void Update () {
		respawnTime -= Time.deltaTime;
		waveTime -= Time.deltaTime;
		if (respawnTime < 0 && whatToSpawn!= null && whatToSpawn.Count > 0) {
			Spawn ();
			respawnTime = spanwFrequency;
		}
		if (waveTime <= 0) {
			this.enabled = false;
		}
	}

	/// <summary>
	/// Spawn a single enemy instance.
	/// </summary>
	void Spawn(){
		var angle = Random.Range(0f,1.0f) * Mathf.PI * 2;
		var radius = spawnDistance;
		var x = Mathf.Cos (angle) * radius + this.transform.position.x;
		var y = Mathf.Sin (angle) * radius +  this.transform.position.y;
		int index = Random.Range (0, whatToSpawn.Count - 1);
		Debug.Log ("Range = "+ index);
		Object prefab = whatToSpawn[index];
		if (prefab) {
			GameObject enemy = Instantiate (prefab, new Vector3 (x, y, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
			enemy.GetComponent<FollowTarget> ().target = target;
		}
	}

	/// <summary>
	/// Attachs a wave profile to the current enemy spawner.
	/// </summary>
	/// <param name="toAttach">To attach.</param>
	public void attachProfile(WaveProfile toAttach){
		spawnDistance = toAttach.spawnDistance;
		spanwFrequency = toAttach.spanwFrequency;
		spawnFor = toAttach.spawnFor;
		whatToSpawn = toAttach.whatToSpawn;
	}

	/// <summary>
	/// Returns true if the spawning was ended.
	/// </summary>
	/// <returns><c>true</c>, if ended was, <c>false</c> otherwise.</returns>
	public bool hasEnded(){
		return !this.enabled;
	}

}
