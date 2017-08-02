using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlickMove : MonoBehaviour {

    public float speed = 100;
    public float touchRadius;
    public float minSwipeDistance;
    public LayerMask layerMask;
    public bool stopOnRelease = false;

    private Rigidbody2D rbToFlick;
    private Vector2 startSwipePoint;
    private Vector2 currentSwipePoint;
    private bool swipeInProgress = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (stopOnRelease && !swipeInProgress && rbToFlick)
            rbToFlick.velocity = Vector2.zero;

        if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {
            if (!Input.mousePresent) {
                for (int i = 0; i < Input.touchCount; ++i) {
                    if (Input.GetTouch(i).phase == TouchPhase.Began) {
                        swipeInProgress = true;
                        startSwipePoint = Input.GetTouch(i).position;
                        currentSwipePoint = startSwipePoint;
                        rbToFlick = null;
                    }
                    if (swipeInProgress) {
                        currentSwipePoint = Input.GetTouch(i).position;
                        if(!rbToFlick)
                            rbToFlick = GetFirstRigidBody2DAlongScreenLine(startSwipePoint, currentSwipePoint, Camera.main);

                        if (Vector2.Distance(startSwipePoint, currentSwipePoint) > minSwipeDistance && rbToFlick) {
                            rbToFlick.velocity = Vector2.zero;
                            rbToFlick.AddForce((Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position) - rbToFlick.transform.position).normalized * speed * Time.deltaTime);
                        }
                        if (Input.GetTouch(i).phase == TouchPhase.Ended) {
                            swipeInProgress = false;
                        }
                    }
                }
            }
            else {
                if (Input.GetMouseButtonDown(0)) {
                    swipeInProgress = true;
                    startSwipePoint = Input.mousePosition;
                    currentSwipePoint = startSwipePoint;
                    rbToFlick = null;
                }
                if (swipeInProgress) {
                    currentSwipePoint = Input.mousePosition;
                    if (!rbToFlick)
                        rbToFlick = GetFirstRigidBody2DAlongScreenLine(startSwipePoint, currentSwipePoint, Camera.main);

                    if (Vector2.Distance(startSwipePoint, currentSwipePoint) > minSwipeDistance && rbToFlick) {
                        rbToFlick.velocity = Vector2.zero;
                        rbToFlick.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - rbToFlick.transform.position).normalized * speed * Time.deltaTime);
                    }
                    if (Input.GetMouseButtonUp(0)) {
                        swipeInProgress = false;
                    }
                }
            }
        }
    }

    Rigidbody2D GetRigidBody2DUnderScreenPoint(Vector3 screenPoint, Camera camera) {
        RaycastHit2D hit = Physics2D.CircleCast(camera.ScreenToWorldPoint(screenPoint), touchRadius, Vector2.zero);
        return hit.rigidbody;
    }
    Rigidbody2D GetFirstRigidBody2DAlongScreenLine(Vector3 startPoint, Vector3 endPoint, Camera camera) {
        Vector2 worldStart = camera.ScreenToWorldPoint(startPoint);
        Vector2 worldDirection = camera.ScreenToWorldPoint(endPoint) - camera.ScreenToWorldPoint(startPoint);
        RaycastHit2D hit = Physics2D.CircleCast(worldStart, touchRadius, worldDirection, worldDirection.magnitude, layerMask.value);
        Debug.DrawLine(camera.ScreenToWorldPoint(startPoint), camera.ScreenToWorldPoint(endPoint),Color.red,5f,false);
        return hit.rigidbody;
    }
}
