using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Script creado a partir de un tutorial de Youtube del canal How Tuts

    private CharacterController player;
    private float speed = 10f;
    private float jumpSpeed = 8.0f;
    private float gravity = 10f;
    private float life = 1000f;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (player.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        player.Move(moveDirection * Time.deltaTime);

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "EnemyWeapon")
        {
            // Enemy Weapon Damege = 10
            life -= 10f;
        }
    }

}
