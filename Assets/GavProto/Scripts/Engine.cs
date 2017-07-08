using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.EventSystems;  public class Engine : MonoBehaviour {      public Rigidbody2D hull_Rigidbody2D;     public ParticleSystem thruster_ParticleSystem;     public Fuel fuel;     public float fuelBurnRate;     public float rotationSpeed;     public float enginePower;     public float engineBoost;     public float engineBoostRate;      private Vector3 lastForce = Vector3.zero;     private float initalThrusterLifetime;  	// Use this for initialization 	void Start () {         initalThrusterLifetime = thruster_ParticleSystem.startLifetime; 	}  	// Update is called once per frame 	void Update () {         Engines();         thruster_ParticleSystem.startLifetime = engineBoost * initalThrusterLifetime;     }      void Engines() {         if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {             MoveToPointUsingMouse();             //TurnWithTouch();             //TurnWithKeys();             //MoveWithKeys();             //MoveWithTouch();         }     }      void MoveToPointUsingMouse() {         if (Input.GetMouseButton(0)) {              Vector3 nextPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));             if ((fuel && fuel.fuelLevel > 0) || !fuel) {                 hull_Rigidbody2D.AddForce((nextPoint - hull_Rigidbody2D.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);                 engineBoost += engineBoostRate * Time.deltaTime;             }             else if (fuel && fuel.fuelLevel <= 0) {                 engineBoost = 1;             }             var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull_Rigidbody2D.transform.position);             hull_Rigidbody2D.transform.rotation = Quaternion.Slerp(hull_Rigidbody2D.transform.rotation, q0, Time.deltaTime * rotationSpeed);             if (fuel) {                 fuel.BurnFuel(fuelBurnRate * Time.deltaTime);             }         }         else {             engineBoost = 1;         }     }     void TurnWithKeys() {
        if(Input.GetAxis("Horizontal") > 0) {
            Turn(hull_Rigidbody2D.transform.right);
        }
        if (Input.GetAxis("Horizontal") < 0) {
            Turn(-hull_Rigidbody2D.transform.right);
        }
    }      void MoveWithKeys() {
        if (Input.GetAxis("Vertical") > 0 || (Input.GetButton("Left" ) && Input.GetButton("Right")) ) {
            Vector3 nextPoint = hull_Rigidbody2D.transform.position + hull_Rigidbody2D.transform.up;// Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));             if ((fuel && fuel.fuelLevel > 0) || !fuel) {                 hull_Rigidbody2D.AddForce((nextPoint - hull_Rigidbody2D.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);                 engineBoost += engineBoostRate * Time.deltaTime;             }             else if (fuel && fuel.fuelLevel <= 0) {                 engineBoost = 1;             }             var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull_Rigidbody2D.transform.position);             hull_Rigidbody2D.transform.rotation = Quaternion.Slerp(hull_Rigidbody2D.transform.rotation, q0, Time.deltaTime * rotationSpeed);             if (fuel) {                 fuel.BurnFuel(fuelBurnRate * Time.deltaTime);             }
        }
        else {             engineBoost = 1;         }
    }      void TurnWithTouch() {         foreach (var touch in Input.touches) {             Vector3 touchPointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z));             if (touch.position.x > Screen.width / 2 && Input.touches.Length == 1) {                 Turn(hull_Rigidbody2D.transform.right);             }
            if (touch.position.x < Screen.width / 2 && Input.touches.Length == 1) {                 Turn(-hull_Rigidbody2D.transform.right);             }         }     }

    void MoveWithTouch() {         foreach (var touch in Input.touches) {             Vector3 touchPointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z));             if (Input.touches.Length == 2) {
                Vector3 nextPoint = hull_Rigidbody2D.transform.position + hull_Rigidbody2D.transform.up;// Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));                 if ((fuel && fuel.fuelLevel > 0) || !fuel) {
                        hull_Rigidbody2D.AddForce((nextPoint - hull_Rigidbody2D.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);
                        engineBoost += engineBoostRate * Time.deltaTime;
                    }
                    else if (fuel && fuel.fuelLevel <= 0) {
                        engineBoost = 1;
                    }
                    var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull_Rigidbody2D.transform.position);
                    hull_Rigidbody2D.transform.rotation = Quaternion.Slerp(hull_Rigidbody2D.transform.rotation, q0, Time.deltaTime * rotationSpeed);
                    if (fuel) {
                        fuel.BurnFuel(fuelBurnRate * Time.deltaTime);
                    }
                }
            else {
                engineBoost = 1;
            }         }     }      void Turn(Vector3 direction) {         var q0 = Quaternion.LookRotation(Vector3.forward, direction);         hull_Rigidbody2D.transform.rotation = Quaternion.Slerp(hull_Rigidbody2D.transform.rotation, q0, Time.deltaTime * rotationSpeed);     } } 