using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductiveBehavior : MonoBehaviour {

	public List<GameObject> toReproduce; 
	public int frequency;
	public GameObject targetOfTheReproduced;

	private float time;

	void Start () {
		time = frequency;
	}

	void Update () {
		time -= Time.deltaTime;
		if (time<=0) {
			Reproduce ();
			time = frequency;
		}
	}

	void Reproduce(){
		if (toReproduce != null && toReproduce.Count>0) {
			int index = Random.Range (0, toReproduce.Count - 1);
			Object prefab = toReproduce[index];
			if (prefab) {
				GameObject enemy = Instantiate (prefab, this.gameObject.transform.position, this.gameObject.transform.localRotation) as GameObject;
				enemy.GetComponent<FollowTarget> ().target = targetOfTheReproduced;
			}
		}
	}


}
