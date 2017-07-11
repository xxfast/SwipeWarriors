using System.Collections; using System.Collections.Generic; using UnityEngine; using System.Linq;  public class Projectile : MonoBehaviour {      public float damage;     private GameObject owner;     public Collider2D[] colliders;  	// Use this for initialization 	void Start () {


    } 	 	// Update is called once per frame 	void Update () { 		 	}      void OnCollisionEnter2D(Collision2D collision) {         //if (!new List<Collider2D>(owner.GetComponentsInChildren<Collider2D>()).Contains(collision.collider)) {
            Destroy(gameObject);
       // }        }      public void SetOwner(GameObject owner) {         this.owner = owner;     }      public void IgnoreCollisionsWith(GameObject[] objectsIgnored) {
        foreach (var obj in objectsIgnored) {
            var objColliders = obj.GetComponents<Collider2D>();
            var objChildColliders = obj.GetComponentsInChildren<Collider2D>();
            foreach (var col in colliders) {
                foreach (var objCol in objColliders) {
                    Physics2D.IgnoreCollision(objCol, col);
                }
                foreach (var objChildCol in objChildColliders) {
                    Physics2D.IgnoreCollision(objChildCol, col);
                }
            }
        }
    } } 