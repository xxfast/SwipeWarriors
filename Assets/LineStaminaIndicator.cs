using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStaminaIndicator : MonoBehaviour {

	private GameObject initiatedPath;
	private StaminaBar currentStaminaBar;
	public Color staminaColor = Color.green;
	public Color pathColor = Color.red;
	private float percentage;

	void Start () {
		currentStaminaBar = ((StaminaBar)this.gameObject.GetComponent<StaminaBar> ());
	}

	void SetUpGradient(){
		LineRenderer lr = initiatedPath.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(staminaColor, 0.0f),new GradientColorKey(staminaColor, percentage),new GradientColorKey(pathColor, percentage),new GradientColorKey(pathColor, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lr.colorGradient = gradient;
	}
	
	void Update () {
		percentage = (float) currentStaminaBar.stamina / (float)currentStaminaBar.maxStamina;
		PathMovement pm = ((PathMovement)this.gameObject.GetComponent<PathMovement> ());
		initiatedPath = pm.InstantiatedPath;
		if (initiatedPath != null) {
			SetUpGradient ();
		}
	}
}
