using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsible : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		// TODO : Implement collapsable behavior
		if(collision.gameObject.tag.Contains("enemy")){
//			Object prefab = Resources.Load("enemy", typeof(GameObject));
//			GameObject enemy = Instantiate(prefab, this.transform.position, new Quaternion(0,0,0,0)) as GameObject;
//			Vector3 newScale = Vector3.Scale (this.transform.localScale, collision.gameObject.transform.localScale);
//			enemy.transform.localScale.Set (newScale.x*2,newScale.y*2,newScale.z*2);
//			enemy.GetComponent<FollowTarget> ().target = this.gameObject;
//			Destroy (collision.gameObject);
//			Destroy (this.gameObject);
		}
	}
}
