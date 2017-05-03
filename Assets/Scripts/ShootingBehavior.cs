using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour {

	public float shootRange = 4;
	public float shootFrequency = 0.2f;
	public double shootAccuracy = 0.9;
	public float shootVelocity = 100;
	public string shootEverythingTagged = "enemy"; 

	public GameObject bulletPrefab;

	private float time;
	private int viewDirectionCount = 16;

	// Use this for initialization
	void Start () {
		time = shootFrequency;
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(time<=0){
			Observe ();
			time = shootFrequency;
		}
	}

	void Observe(){
		GameObject target = null;
		foreach(Vector2 currentDirection in GetCircleDirections(viewDirectionCount)){
			RaycastHit2D[] hits = Physics2D.RaycastAll(this.gameObject.transform.position,currentDirection,shootRange);
			if (hits.Length > 1) {
				foreach(RaycastHit2D hit in hits){
					if (hit.collider.gameObject != this.gameObject) {
						if(hit.collider.gameObject.tag==shootEverythingTagged)
							target = hit.collider.gameObject;
					}
				}
			}
		}
		if(target) Shoot(target);
	}

	void Shoot(GameObject target){
		GameObject bullet = Instantiate (bulletPrefab, this.gameObject.transform.position, new Quaternion (0, 0, 0, 0)) as GameObject;
		bullet.GetComponent<FollowTarget> ().target = target;
		bullet.GetComponent<FollowTarget> ().followSpeed = shootVelocity;
	}

	Vector2[] GetCircleDirections(int numDirections)
	{
		var pts = new Vector2[numDirections];
		var inc = Mathf.PI * (3 - Mathf.Sqrt(5));
		var off = 2f / numDirections;
		for(int i=0;i<numDirections;i++)
		{
			var y = i * off - 1 + (off / 2);
			var r = Mathf.Sqrt(1 - y * y);
			var phi = i * inc;
			var x = (float)(Mathf.Cos(phi) * r);
			//var z = (float)(Mathf.Sin(phi) * r);
			pts[i] = new Vector2(x, y);
		}
		return pts;
	}
}
