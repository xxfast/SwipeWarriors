using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStaminaIndicator : MonoBehaviour {

	private GameObject initiatedPath;
	private StaminaBar currentStamina;
	public Color staminaColor = Color.green;

	// Use this for initialization
	void Start () {
		currentStamina = ((StaminaBar)this.gameObject.GetComponent<StaminaBar> ());
	}
	
	// Update is called once per frame
	void Update () {
		PathMovement pm = ((PathMovement)this.gameObject.GetComponent<PathMovement> ());
		initiatedPath = pm.InstantiatedPath;
		if (initiatedPath == null) return;
		LineRenderer lr = initiatedPath.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(staminaColor, 0.0f), new GradientColorKey(Color.red, 0.5f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lr.colorGradient = gradient;
	}
}
