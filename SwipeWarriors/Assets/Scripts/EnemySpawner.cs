using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float spawnDistance = 10;
	public float spanwFrequency = 3.0f;

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
		//var myIntruder = new Intruder (scene).targets (myKingdom).killer (myWarrior).translate (x, y);
		Object prefab = Resources.Load("enemy", typeof(GameObject));
		GameObject enemy = Instantiate(prefab, new Vector3(x,y,0), new Quaternion(0,0,0,0)) as GameObject;
		enemy.GetComponent<FollowTarget> ().target = this.gameObject;
	}
}
