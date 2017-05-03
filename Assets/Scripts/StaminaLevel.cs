using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaLevel : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Stamina stamina;
    [SerializeField]
    private Image content;

    // Variables
    [Header("Base Variables:")]
    [SerializeField]
    private float fillAmount;
    private int maxStamina;
    private int currentStamina;

    // Use this for initialization
    void Start () {
        // Set Refernces
        content = this.gameObject.GetComponent<Image>() as Image;
        stamina = GameObject.Find("Player").gameObject.GetComponent<Stamina>() as Stamina;
        maxStamina = stamina.MaxStamina;
        currentStamina = stamina.CurrentStamina;
	}
	
	// Update is called once per frame
	void Update () {
		if(stamina.CurrentStamina != currentStamina)
        {
            currentStamina = stamina.CurrentStamina;
            fillAmount = 1.0f * ((float)currentStamina / (float)maxStamina);
            content.fillAmount = fillAmount;
        }
	}
}
