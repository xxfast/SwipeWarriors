using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour {
    //Lots of code copied from ShootingBehavior

    public float shootRange = 4;
    public float shootFrequency = 0.2f;
    public double shootAccuracy = 0.9;
    public float shootVelocity = 100;
    public float rayWidth;

    public GameObject projectilePrefab;
    public GameObject player;
    public GameObject hull;

    private float time;
    private int viewDirectionCount = 16;

    // Use this for initialization
    void Start() {
        time = shootFrequency;
    }

    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        if (time <= 0) {
            Observe();
            time = shootFrequency;
        }
    }

    void Observe() {
        GameObject target = null;
        //transform.up is forwards as the sprite faces up
        var currentDirection = transform.up;
        Debug.DrawLine(transform.position, transform.position + currentDirection.normalized * shootRange);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, rayWidth, currentDirection, shootRange);
        foreach (RaycastHit2D hit in hits) {
            //If its not part of the player object
            if (!new List<Collider2D>(player.GetComponentsInChildren<Collider2D>()).Contains(hit.collider)) {
                //If its a shootable object
                if (hit.collider.GetComponent<Shootable>())
                    target = hit.collider.gameObject;
            }
        }
        if (target) Shoot(target);
    }

    void Shoot(GameObject target) {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().owner = player;
        projectile.transform.right = transform.right;
        projectile.GetComponent<Rigidbody2D>().velocity = shootVelocity * (Vector2)transform.up;
    }
}
