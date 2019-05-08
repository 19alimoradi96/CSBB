using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Vector3 mouseDownPos;
    private Transform ballTransform;
    public Transform ball;
    public Camera cam;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            // Debug.Log(Input.mousePosition);
            // mouseDownPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp (0)) {
            // Debug.Log(Input.mousePosition);
            Vector3 shoot = cam.ScreenToWorldPoint (Input.mousePosition);
            shoot.z = 0;
            Debug.Log (shoot);
            ball.GetComponent<Rigidbody2D> ().AddForce (shoot * 150.0f);
            // ball.GetComponent<Rigidbody2D> ().
        }
    }
    void OnCollisionEnter2D (Collision2D cldr) {
        if(cldr.gameObject.tag == "Brick"){
            Debug.Log ("brick enter");
            Brick brick = cldr.gameObject.GetComponent<Brick>();
            brick.setStrength(brick.getStrength()-1);
        }
    }
    private void OnCollisionExit2D (Collision2D cldr) {
        // Debug.Log ("collision exit");
    }
}