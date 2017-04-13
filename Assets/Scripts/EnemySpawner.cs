using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float spawnDistance = 10;
	public float spanwFrequency = 3.0f;
	public List<Object> whatToSpawn = new List<Object> ();
	private float time;


	void Start () {
		time = spanwFrequency;
	}
	
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			Spawn ();
			time = spanwFrequency;
		}
	}

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
			enemy.GetComponent<FollowTarget> ().target = this.gameObject;
		}
	}
}
