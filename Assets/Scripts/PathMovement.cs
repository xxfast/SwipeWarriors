using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathMovement : MonoBehaviour {

    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private GameObject objectToMove;
    [SerializeField]
    private GameObject pathPrefab;
    private GameObject instantiatedPath;
    [SerializeField]
    private GameObject attackArea;

    [SerializeField]
    private Stamina stamina;

    // Path Definition
    private List<Vector3> path;

    // Path Settings
    [Header("Path Settings:")]
    public float Speed;
    public float AttackDelay;
    public float MinimumPathPointDistance;
    public bool DynamicTimeDilation;

    // Misc
    private int nextPointIndex;
    private bool pathComplete;
    private float time;

    public GameObject InstantiatedPath { get { return instantiatedPath; } }

    // Use this for initialization
    void Start () {
        if (objectToMove == null)
            objectToMove = this.gameObject;

        pathPrefab = transform.Find("Path").gameObject;
        attackArea = transform.Find("AttackArea").gameObject;
        stamina = this.gameObject.GetComponent<Stamina>();

        path = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
        // Update Path (input)
        UpdatePath();

        // Reset Path (on condition)

        // Move to next point on path
        MoveToNextPointOnPath();
	}

    /// <summary>
    /// Updates Path.
    /// </summary>
    private void UpdatePath()
    {
        if (!EventSystem.current.IsPointerOverGameObject() &&
            EventSystem.current.currentSelectedGameObject == null
            )
        {
            if (Input.GetMouseButton(0))
            {
                if(DynamicTimeDilation) // Message Game Director to set time dilation
                    GameObject.Find("DirectorGame").SendMessage("ToggleDilation");
                else
                    GameObject.Find("DirectorGame").SendMessage("DilateTime");

                if (pathComplete)
                {
                    ResetPath();
                    pathComplete = false;
                }
                if (path.Count == 0)
                {
                    path.Add(objectToMove.transform.position);
                    nextPointIndex = 0;
                }
                if (instantiatedPath == null)
                    instantiatedPath = Instantiate(pathPrefab);
                Vector3 nextPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                if (Vector3.Distance(nextPoint, path[path.Count - 1]) > MinimumPathPointDistance)
                    path.Add(nextPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (DynamicTimeDilation) // Message Game Director to restore time dilation
                    GameObject.Find("DirectorGame").SendMessage("ToggleDilation");
                else
                    GameObject.Find("DirectorGame").SendMessage("RestoreTime");

                Vector3 lastPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                path.Add(lastPoint);
                pathComplete = true;
            }
        }
        if (instantiatedPath != null)
        {
            instantiatedPath.GetComponent<LineRenderer>().positionCount = path.Count;
            instantiatedPath.GetComponent<LineRenderer>().SetPositions(path.ToArray());
        }
    }

    /// <summary>
    /// Moves to next point on path;
    /// </summary>
    public void MoveToNextPointOnPath()
    {
        // check for point to move to;
        if (nextPointIndex < 0)
        {
            time = AttackDelay;
            attackArea.SetActive(false);
            stamina.Recover();
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
            time = AttackDelay;
            attackArea.SetActive(false);
            stamina.Recover();
            return;
        }

        // move
        if (stamina.Move())
        {
            time -= Time.deltaTime;

            // start attacking if attack delay has passed.
            if (time <= 0.0)
                attackArea.SetActive(true);

            var maxDistanceDelta = Time.deltaTime * Speed;

            // thingToMove.transform.LookAt(nextPoint);
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, nextPoint, maxDistanceDelta);

            //Debug.Log(Vector3.Distance(thingToMove.transform.position, nextPoint) + " " + maxDistanceDelta);
            if (Vector3.Distance(objectToMove.transform.position, nextPoint) < maxDistanceDelta)
            {
                if (nextPointIndex > 0)
                {
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
            ResetPath();
        }
    }

    /// <summary>
    /// Reset Path;
    /// </summary>
    public void ResetPath()
    {
        path = new List<Vector3>();
        Destroy(instantiatedPath);
        stamina.StopMoving();
        nextPointIndex = -1;
    }
}
