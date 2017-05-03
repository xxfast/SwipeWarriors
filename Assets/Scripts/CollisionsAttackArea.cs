using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsAttackArea : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Stamina stamina;

    // Settings
    [Header("Settings:")]
    public int AttackStrenth;

    // Use this for initialization
    void Start () {
        stamina = GameObject.Find("Player").gameObject.GetComponent<Stamina>() as Stamina;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Attack Enemy on Collision
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Health>().DealDamage(AttackStrenth);
            stamina.Attack();
        }
    }
}
