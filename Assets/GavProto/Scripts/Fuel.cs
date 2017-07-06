using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {
     public float fuelRefillRate;     public float fuelMaxLevel;
    public float fuelLevel;

    private bool isFuelBurning;
    private float fillAmount;
    public Image content;

    // Use this for initialization
    void Start () {
        fuelLevel = fuelMaxLevel;
        //content = gameObject.GetComponent<Image>() as Image;
    }
	
	// Update is called once per frame
	void Update () {
        content.fillAmount = 1.0f * ((float)fuelLevel / (float)fuelMaxLevel);
    }

    void LateUpdate() {
        if(!isFuelBurning)
            RefillFuel(fuelRefillRate * Time.deltaTime);
        isFuelBurning = false;
    }

    public void BurnFuel(float amount) {
        fuelLevel -= amount;
        fuelLevel = Mathf.Clamp(fuelLevel, 0, fuelMaxLevel);
        isFuelBurning = true;
    }
    public void RefillFuel(float amount) {
        fuelLevel += amount;
        fuelLevel = Mathf.Clamp(fuelLevel, 0, fuelMaxLevel);
    }

}
