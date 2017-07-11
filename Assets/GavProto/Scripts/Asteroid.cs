using System;
using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Asteroid : DestructableEntity {      public int level;     public float minExplosionForce;     public float maxExplosionForce;     public float splitDistance;
    public float maxSpawnAngleDeviationFactor;

    //public GameObject[] objectsToSplitInto;
    //public float[] probabilitiesToSplitIntoObjects;
    public GameObject objectToSplitInto;     public int minPiecesCount;     public int maxPiecesCount;      // Use this for initialization     new void Start () {         base.Start(); 	} 	 	// Update is called once per frame 	new void Update () {
        base.Update();
    }      public void Split(Vector2 normal) {         if(objectToSplitInto) SplitIntoObjects(normal, objectToSplitInto, minPiecesCount, maxPiecesCount);     }      void SplitIntoObjects(Vector2 normal, GameObject obj, int minPiecesCount, int maxPiecesCount) {         var piecesCount = UnityEngine.Random.Range(minPiecesCount, maxPiecesCount+1);         var initialDirection = Quaternion.Euler(0, 0, 90) * normal;         for (int i=0; i < piecesCount; i++) {
            var angleDeviation = UnityEngine.Random.Range(-1f, 1f)* maxSpawnAngleDeviationFactor;
            var nextDirection = Quaternion.Euler(0, 0, (i+ angleDeviation) * 360/piecesCount) * initialDirection;
            var spawnedObj = Instantiate(obj, transform.position + nextDirection * splitDistance, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)), transform.parent);
            var force = nextDirection * UnityEngine.Random.Range(minExplosionForce, maxExplosionForce) * spawnedObj.GetComponent<Rigidbody2D>().mass;
            spawnedObj.GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime);
        }     }
    void OnCollisionEnter2D(Collision2D collision) {
        if (!IsSpawnProtected()) {
            if (collision.gameObject.GetComponent<Asteroid>()) {
                float energy = collision.relativeVelocity.sqrMagnitude * collision.otherRigidbody.mass/2;
                TakeDamage(energy);
            } else if(collision.gameObject.GetComponent<Projectile>()){
                TakeDamage(collision.gameObject.GetComponent<Projectile>().damage);
            }
           
            if (currentHealth <= 0) {
                Split(collision.contacts[0].normal);
                Destruct();
            }
        }
    }
} 