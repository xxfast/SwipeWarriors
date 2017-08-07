using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth = 10;
	public int currentHealth;
	public bool showHealth = true;
	public float healthBarLength = 1;

	public bool isDead { get { return (currentHealth <= 0); } }

	public int CurrentHealth { get { return currentHealth; } }

	void Start () {
		currentHealth = maxHealth;
	}
	
	void Update () {
		if (currentHealth <= 0) {
			Destroy (this.gameObject);
		}
    }

	public void DealDamage(int amount){
		currentHealth -= amount;
	}

	void OnRenderObject() {
		if(showHealth){
			DrawQuad (new Rect(gameObject.transform.position,new Vector2(1,1)), Color.green);
		}
	}

	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
