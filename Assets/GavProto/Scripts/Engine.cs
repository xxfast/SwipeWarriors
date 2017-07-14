using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.EventSystems;  public class Engine : MonoBehaviour {      public Rigidbody2D hull;     public ParticleSystem thruster;     public Fuel fuel;     public float fuelBurnRate;     public float rotationSpeed;     public float enginePower;     public float engineBoost;     public float engineBoostRate;      private Vector3 lastForce = Vector3.zero;     private float initalThrusterLifetime;  	// Use this for initialization 	void Start () {         initalThrusterLifetime = thruster.startLifetime; 	}  	// Update is called once per frame 	void Update () {         Engines();         thruster.startLifetime = engineBoost * initalThrusterLifetime;     }      void Engines() {         if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {             MoveToPointUsingMouse();             //TurnWithTouch();             //TurnWithKeys();             //MoveWithKeys();             //MoveWithTouch();         }     }

    void VectorThrusters() {
        if (Input.GetAxis("VectorLeft") < 0) {
            
        }
        if (Input.GetAxis("VectorRight") < 0) {
            
        }
    }



    void MoveToPointUsingMouse() {         if (Input.GetMouseButton(0)) {              Vector3 nextPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));             if ((fuel && fuel.fuelLevel > 0) || !fuel) {                 hull.AddForce((nextPoint - hull.transform.position).normalized * enginePower * engineBoost * Time.deltaTime * hull.mass);                 engineBoost += engineBoostRate * Time.deltaTime;             }             else if (fuel && fuel.fuelLevel <= 0) {                 engineBoost = 1;             }             var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull.transform.position);             hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, q0, Time.deltaTime * rotationSpeed);             if (fuel) {                 fuel.BurnFuel(fuelBurnRate * Time.deltaTime);             }         }         else {             engineBoost = 1;         }     }     void TurnWithKeys() {
        if(Input.GetAxis("Horizontal") > 0) {
            Turn(hull.transform.right);
        }
        if (Input.GetAxis("Horizontal") < 0) {
            Turn(-hull.transform.right);
        }
    }      void MoveWithKeys() {
        if (Input.GetAxis("Vertical") > 0 || (Input.GetButton("Left" ) && Input.GetButton("Right")) ) {
            Vector3 nextPoint = hull.transform.position + hull.transform.up;// Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));             if ((fuel && fuel.fuelLevel > 0) || !fuel) {                 hull.AddForce((nextPoint - hull.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);                 engineBoost += engineBoostRate * Time.deltaTime;             }             else if (fuel && fuel.fuelLevel <= 0) {                 engineBoost = 1;             }             var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull.transform.position);             hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, q0, Time.deltaTime * rotationSpeed);             if (fuel) {                 fuel.BurnFuel(fuelBurnRate * Time.deltaTime);             }
        }
        else {             engineBoost = 1;         }
    }      void TurnWithTouch() {         foreach (var touch in Input.touches) {             Vector3 touchPointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z));             if (touch.position.x > Screen.width / 2 && Input.touches.Length == 1) {                 Turn(hull.transform.right);             }
            if (touch.position.x < Screen.width / 2 && Input.touches.Length == 1) {                 Turn(-hull.transform.right);             }         }     }

    void MoveWithTouch() {         foreach (var touch in Input.touches) {             Vector3 touchPointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z));             if (Input.touches.Length == 2) {
                Vector3 nextPoint = hull.transform.position + hull.transform.up;// Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));                 if ((fuel && fuel.fuelLevel > 0) || !fuel) {
                        hull.AddForce((nextPoint - hull.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);
                        engineBoost += engineBoostRate * Time.deltaTime;
                    }
                    else if (fuel && fuel.fuelLevel <= 0) {
                        engineBoost = 1;
                    }
                    var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull.transform.position);
                    hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, q0, Time.deltaTime * rotationSpeed);
                    if (fuel) {
                        fuel.BurnFuel(fuelBurnRate * Time.deltaTime);
                    }
                }
            else {
                engineBoost = 1;
            }         }     }      void Turn(Vector3 direction) {         var q0 = Quaternion.LookRotation(Vector3.forward, direction);         hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, q0, Time.deltaTime * rotationSpeed);     } } 