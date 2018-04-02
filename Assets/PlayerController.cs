using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Script creado a partir de un tutorial de Youtube del canal How Tuts

    private Rigidbody player;
    private float speed = 10f;
    private float maxSpeed = 20f;
    private bool isGround = true;
    public GameObject reference;
    private float jumpHeight = 7000f;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUp = Input.GetAxis("Jump");

        if(player.velocity.magnitude > maxSpeed){
            player.velocity = player.velocity.normalized * maxSpeed;
        }

        player.AddForce(moveVertical * reference.transform.forward * speed);
        player.AddForce(moveHorizontal * reference.transform.right * speed);

        if (Input.GetAxis("Jump")==1 && isGround)
        {
            player.AddForce(moveUp * reference.transform.up * jumpHeight);
            //player.AddForce(0, jumpHeight, 0);
            isGround = false;
        }

    }
    void OnCollisionEnter (Collision collision)
    {
        Debug.Log("choque collider");
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            Debug.Log("IsGround");
        }
        else
            isGround = false;
    }
}
