using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowTarget))]
public class FollowAnchorBehavior : MonoBehaviour {

	public bool shouldMove = true;
	public float trailDistance = 5.0f;
	public GameObject anchorPrefab;

	private GameObject anchor;

	void Start () {
		if (anchorPrefab) anchor = Instantiate (anchorPrefab);
	}
	
	void Update () {
		if (shouldMove && (anchorPrefab != null)) {
			if (Input.GetMouseButton(0)) {
				anchor.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				anchor.transform.position = new Vector3 (anchor.transform.position.x, anchor.transform.position.y, 0);
				this.gameObject.GetComponent<FollowTarget> ().target = anchor;
			}
		}
	}
}
