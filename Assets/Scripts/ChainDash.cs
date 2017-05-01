using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChainDash : MonoBehaviour {

    public Rigidbody2D rigidbodyToDash;
    public float dashForceMultiplier;
    private Queue<Vector2> dashPoints = new Queue<Vector2>();

    public int maxDashPoints = 3;
    public float dashCooldown = 0.5f;
    private float dashTimer = 0f;

    // Use this for initialization
    void Start () {
        if (rigidbodyToDash == null) {
            rigidbodyToDash = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update() {
        dashTimer += Time.deltaTime;
        QueueNextDashPoint();
        if(dashPoints.Count > 0 && dashPoints.Count < maxDashPoints && dashTimer > dashCooldown) {
            this.rigidbodyToDash.velocity = Vector2.zero;
            Dash(dashPoints.Dequeue());
            dashTimer = 0;
        }
    }

    bool QueueNextDashPoint() {
        if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {
            if (Input.GetMouseButtonDown(0)) {
                Vector2 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                dashPoints.Enqueue(touchPoint);
                return true;
            }
        }
        return false;
    }

    void Dash(Vector2 to) {
        Vector2 dashForceVector = dashForceMultiplier * (to - (Vector2)rigidbodyToDash.transform.position).normalized;
        rigidbodyToDash.AddForce(dashForceVector);
    }
}
