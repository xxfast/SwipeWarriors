using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaDisplayLevel : MonoBehaviour {

    public StaminaBar staminaBar;

    private float fillAmount;

    public Image content;

    private int maxStamina;
    private int currentStamina;

	// Use this for initialization
	void Start () {
        maxStamina = staminaBar.maxStamina;
        currentStamina = staminaBar.stamina;
	}
	
	// Update is called once per frame
	void Update () {
        if(staminaBar.stamina != currentStamina) // Stamina has changed update.
        {
            currentStamina = staminaBar.stamina;

            fillAmount = 1.0f * ((float)currentStamina / (float)maxStamina);

            content.fillAmount = fillAmount;
        }
	}
}
