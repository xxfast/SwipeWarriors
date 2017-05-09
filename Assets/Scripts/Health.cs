using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	// Use this for initialization
	public int maxHealth = 10;

    [SerializeField]
    private int currentHealth;

	private Vector2 initalScale;

    [SerializeField]
    private bool alive;
    [SerializeField]
    private bool hit;
   

	public bool isDead { get { return !alive; } }
    public bool isHit
    {
        get { return hit; }
        set { hit = value; }
    }

	void Start () {
		currentHealth = maxHealth;
        alive = true;
        hit = false;
		initalScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		ResizeWithHealth ();
		if (currentHealth <= 0) {
			alive = false;
			Destroy (this.gameObject);
		}
    }

	void ResizeWithHealth(){
		float ratio = (float)currentHealth / (float)maxHealth;
		var newScale = new Vector2(initalScale.x * ratio, initalScale.y * ratio);
		this.gameObject.transform.localScale = newScale;
	}

	public void DealDamage(int amount){
		currentHealth -= amount;
        hit = true;
	}
}
