using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject reference;
    private Vector3 distance;
	// Use this for initialization
	void Start () {
        distance = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
        distance = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distance;
        transform.position = player.transform.position + distance;
        transform.LookAt(player.transform.position);

        //referencia para que los controles no se cambien segun la posicion de los ejes

        Vector3 rotatitonCopy = new Vector3(0, transform.eulerAngles.y, 0);
        reference.transform.eulerAngles = rotatitonCopy; 
	}
}
