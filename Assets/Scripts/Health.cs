using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	// Use this for initialization
	public int maxHealth = 10;
	private int currentHealth;

    public float dropProbability; // number between 0.0 and 1.0

    public Object drops;

	private Vector2 initalScale;

	void Start () {
		currentHealth = maxHealth;
		initalScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		ResizeWithHealth ();
        if (currentHealth <= 0)
            Death();
    }

	void ResizeWithHealth(){
		float ratio = (float)currentHealth / (float)maxHealth;
		var newScale = new Vector2(initalScale.x * ratio, initalScale.y * ratio);
		this.gameObject.transform.localScale = newScale;
	}

	public void DealDamage(int amount){
		currentHealth -= amount;
	}

    void Death()
    {
        bool drop = Random.value <= dropProbability;
        
        if(drop)
        {
            GameObject pickup = Instantiate(drops, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        }
            
        Destroy(this.gameObject);
    }
}
