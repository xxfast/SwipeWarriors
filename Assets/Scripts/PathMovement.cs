using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathMovement : MonoBehaviour {

    public GameObject thingToMove;
    private List<Vector3> path = new List<Vector3>();
    public float minPathPointDistance;
    public GameObject pathPrefab;
    private GameObject instantiatedPath;
    public float speed = 1.0f;
    public float attackDelay;

    public StaminaBar staminaBar;
    public GameObject attackArea;

    private int nextPointIndex = -1;
	private bool pathComplete = false;
	public bool isMoving = false;
    private float time;
    
	public GameObject InstantiatedPath { get { return instantiatedPath; } }

	public bool IsMoving { get { return isMoving; }}

    // Use this for initialization
    void Start () {
		if(thingToMove == null) {
            thingToMove = this.gameObject;
        }
	}

    // Update is called once per frame
    void Update() {
        updatePath();
        if (Input.GetMouseButtonDown(2)) {
            resetPath();
        }
        moveToNextPointOnPath();
    }
	
    private void updatePath() {
        if (!EventSystem.current.IsPointerOverGameObject() &&
            EventSystem.current.currentSelectedGameObject == null
            ) {

            if (Input.GetMouseButton(0)) {
                if (pathComplete) {
                    resetPath();
                    pathComplete = false;
                }
                if (path.Count == 0) {
                    path.Add(thingToMove.transform.position);
                    nextPointIndex = 0;
                }
                if (instantiatedPath == null) {
                    instantiatedPath = Instantiate(pathPrefab);
                }
                Vector3 nextPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10));
                if (Vector3.Distance(nextPoint, path[path.Count - 1]) > minPathPointDistance) {
                    path.Add(nextPoint);
                }
            }
            if (Input.GetMouseButtonUp(0)) {
                Vector3 lastPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10));
                path.Add(lastPoint);
                pathComplete = true;
            }
        }
        if (instantiatedPath != null) {
            instantiatedPath.GetComponent<LineRenderer>().positionCount = path.Count;
            instantiatedPath.GetComponent<LineRenderer>().SetPositions(path.ToArray());
        }
    }

	private GameObject getObjectUnderScreenPos(Camera cam, Vector2 screenPos){
		var rayHit = new RaycastHit();
		var ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
		Physics.Raycast(ray, out rayHit);
		Debug.Log(rayHit.collider.gameObject);
		return rayHit.collider.gameObject;
	}

    // Need to factor in the total length of ppath so that
    // 1. there is a cap to path length
    // 2. the movement is uniform speed no matter the path length
    public void moveToNextPointOnPath() {
        // check for point to move to;
        if(nextPointIndex < 0)
        {
            time = attackDelay;
            attackArea.SetActive(false);
            staminaBar.moving = false;
            staminaBar.recover();
            return;
        }

        // get next point
        Vector3 nextPoint;
        try
        {
            nextPoint = path[nextPointIndex];
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            time = attackDelay;
            attackArea.SetActive(false);
            staminaBar.recover();
            staminaBar.moving = false;
			isMoving = false;
            return;
        }

        // move
        if(staminaBar.move())
        {
            time -= Time.deltaTime;
            staminaBar.moving = true;
			isMoving = true;
            // start attacking if attack delay has passed.
            if (time <= 0.0)
                attackArea.SetActive(true);

            var maxDistanceDelta = Time.deltaTime*speed;

            // thingToMove.transform.LookAt(nextPoint);
            thingToMove.transform.position = Vector3.MoveTowards(thingToMove.transform.position, nextPoint, maxDistanceDelta);

            //Debug.Log(Vector3.Distance(thingToMove.transform.position, nextPoint) + " " + maxDistanceDelta);
            if(Vector3.Distance(thingToMove.transform.position, nextPoint) < maxDistanceDelta) {
                if (nextPointIndex > 0) {
                    path.RemoveAt(nextPointIndex - 1);
                    nextPointIndex--;
                }
                nextPointIndex++;
            }
        }
        //TODO: Do somehting if no stamina left
        else
        {
            // remove remainder of path
            resetPath();
        }
    }

    public void resetPath() {
        path = new List<Vector3>();
        Destroy(instantiatedPath);
        nextPointIndex = -1;
    }
}