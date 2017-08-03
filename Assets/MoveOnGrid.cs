using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnGrid : MonoBehaviour {

	public List<List<Vector2>> grid = new List<List<Vector2>>();

	public int colomns = 3;
	public int rows = 3;
	public float cellWidth = 1f;
	public float cellHeight = 1f;

	public Vector2 origin;

	// Use this for initialization
	void Start () {
		CreateGrid ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateGrid(){
		grid = new List<List<Vector2>>();
		Vector2 startPoint = new Vector2 (origin.x - ((cellWidth * colomns)), origin.y - ((cellHeight*rows)));
		Debug.Log (startPoint.x + " " + startPoint.y);
		for(int r=1;r<=rows;r++){
			List<Vector2> row = new List<Vector2> ();
			grid.Add (row);
			for (int c = 1; c <= colomns; c++) {
				row.Add (new Vector2(startPoint.x + (r * cellWidth), startPoint.y + ( cellHeight * c)));
			}
		}
	}

	void OnDrawGizmosSelected(){
		CreateGrid ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		foreach(List<Vector2> row in grid){
			foreach(Vector2 point in row){
				Gizmos.DrawSphere (point, 0.1f);
				DrawSquareAround (point);
			}
		}
	}

	void DrawSquareAround(Vector2 center){
		Vector2 tl = new Vector2 (center.x - cellWidth/2, center.y - cellHeight/2 );
		Vector2 tr = new Vector2 (center.x + cellWidth/2, center.y - cellHeight/2 );
		Vector2 bl = new Vector2 (center.x - cellWidth/2, center.y + cellHeight/2 );
		Vector2 br = new Vector2 (center.x + cellWidth/2, center.y + cellHeight/2 );
		Gizmos.DrawLine(tl,tr);
		Gizmos.DrawLine(tr,br);
		Gizmos.DrawLine(br,bl);
		Gizmos.DrawLine(bl,tl);
	}
}
