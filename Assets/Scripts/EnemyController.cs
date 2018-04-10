using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private CharacterController enemy;
    private float movementSpeed = 7f;
    private GameObject player;
    private float life;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<CharacterController>();
        if (this.tag == "EnemyTank")
            life = 200f;
        if (this.tag == "EnemyDPS")
            life = 100f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = (player.transform.position - transform.position).normalized;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= movementSpeed;

        //moveDirection.y -= gravity * Time.deltaTime;
        enemy.Move(moveDirection * Time.deltaTime);

        if (life <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PlayerWeapon")
        {
            Debug.Log("Enemy hitted");
            // Player Weapon Damege = 10
            life -= 10f;
        }
    }
}
