using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStaminaLevel : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Stamina stamina;
    [SerializeField]
    private GameObject instantiatedPath;

    // Settings
    [Header("Settings:")]
    public Color StaminaColor;
    public Color PathColor;
    public float Alpha = 1.0f;

    // Variables
    [Header("Base Variables:")]
    [SerializeField]
    private float fillAmount;
    private int maxStamina;
    private int currentStamina;
    [SerializeField]
    private Gradient gradient;

    // Use this for initialization
    void Start () {
        stamina = GameObject.Find("Player").gameObject.GetComponent<Stamina>() as Stamina;
        maxStamina = stamina.MaxStamina;
        currentStamina = stamina.CurrentStamina;
    }
	
	// Update is called once per frame
	void Update () {
        if (stamina.CurrentStamina != currentStamina)
        {
            currentStamina = stamina.CurrentStamina;
            fillAmount = 1.0f * ((float)currentStamina / (float)maxStamina);
            instantiatedPath = GameObject.Find("Player").gameObject.GetComponent<PathMovement>().InstantiatedPath;
            if (instantiatedPath != null)
            SetGradient();
        }
    }

    /// <summary>
    /// Sets gradient of path.
    /// </summary>a
    private void SetGradient()
    {
        //LineRenderer lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Sprites-Default"));
        gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(StaminaColor, 0.0f), new GradientColorKey(StaminaColor, fillAmount), new GradientColorKey(PathColor, fillAmount), new GradientColorKey(PathColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(Alpha, 1.0f), new GradientAlphaKey(Alpha, 1.0f) }
            );
        //lineRenderer.colorGradient = gradient;
        this.gameObject.GetComponent<LineRenderer>().colorGradient = gradient;
    }
}
