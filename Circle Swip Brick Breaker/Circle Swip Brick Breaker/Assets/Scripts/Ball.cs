using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Vector3 mouseDownPos;
    private Transform ballTransform;
	public GameObject ball;
    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            Debug.Log(Input.mousePosition);
            mouseDownPos = Input.mousePosition;
        }
		if (Input.GetMouseButtonUp (0)) {
            Debug.Log(Input.mousePosition);
            Vector3 shoot = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(shoot);
            ball.GetComponent<Rigidbody>().AddForce(shoot * 100.0f);
        }
	}
}
