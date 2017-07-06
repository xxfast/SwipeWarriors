using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.EventSystems;  public class Engine : MonoBehaviour {      public Rigidbody2D hull;     public ParticleSystem thruster;     public Fuel fuel;
    public float fuelBurnRate;     public float rotationSpeed;     public float enginePower;     public float engineBoost;     public float engineBoostRate;      private Vector3 lastForce = Vector3.zero;     private float initalThrusterLifetime;  	// Use this for initialization 	void Start () {         initalThrusterLifetime = thruster.startLifetime;     } 	 	// Update is called once per frame 	void Update () {         Bloob();         thruster.startLifetime = engineBoost * initalThrusterLifetime;     }      void Bloob() {         if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {             if (Input.GetMouseButton(0)) {                 Vector3 nextPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));                 if ( (fuel && fuel.fuelLevel > 0) || !fuel) {
                    hull.AddForce((nextPoint - hull.transform.position).normalized * enginePower * engineBoost * Time.deltaTime);
                    engineBoost += engineBoostRate*Time.deltaTime;
                }
                else if (fuel && fuel.fuelLevel <= 0) {
                    engineBoost = 1;
                }
                var q0 = Quaternion.LookRotation(Vector3.forward, nextPoint - hull.transform.position);
                hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, q0, Time.deltaTime * rotationSpeed);                 if (fuel) {
                    fuel.BurnFuel(fuelBurnRate*Time.deltaTime);
                }             }             else {
                engineBoost = 1;
            }         }     }

 } 