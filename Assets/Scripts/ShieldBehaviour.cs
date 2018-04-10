using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {

    private float resistance;
    // Use this for initialization
    void Start()
    {
        if (this.tag == "PlayerShield")
            resistance = 200f;
        else if (this.tag == "EnemyShield")
            resistance = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (resistance <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "EnemyWeapon" || collision.collider.tag == "PlayerWeapon")
        {
            Debug.Log("Shield hitted");
            // Enemy Weapon Damege = Player Weapon Damage = 10f
            resistance -= 10f;
        }
    }
}
