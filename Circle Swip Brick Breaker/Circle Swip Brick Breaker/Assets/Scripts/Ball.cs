using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Vector3 mouseDownPos;
    private Transform ballTransform;
    public GameObject ball;
    public Camera cam;
    public enum states {
        inside = 0, outside = 1
    };
    public states state;
    // Use this for initialization
    void Start () {
        state = states.inside;
    }
     void OnCollisionEnter2D (Collision2D clsn) {
        if(clsn.gameObject.tag == "Ball"){
            Physics2D.IgnoreCollision(clsn.collider, GetComponent<Collider2D>());
        }
    }   
}