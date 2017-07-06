using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public GameObject player;
    public GameObject sprite;
    public int rangeX;
    public int rangeY;
    public int stepX;
    public int stepY;

    // Use this for initialization
    void Start () {
        for(int n= -rangeX; n <= rangeX; n+= stepX) {
            for (int m = -rangeY; m <= rangeY; m+=stepY) {
                Debug.Log(n);
                var backgroundTile = Instantiate(sprite, new Vector3(n,m,0), Quaternion.identity, transform);
                backgroundTile.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID( "background" );
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector2 ClampToNbyNGrid(int n, Vector2 v) {
        return new Vector2(v.x % n, v.y % n);
    }
}
