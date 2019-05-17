using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public static int trapped = 0;
	GameInit gi;
	void Start () {
        gi = Camera.main.GetComponent<GameInit>();
	}
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D cldr) {
        if(cldr.gameObject.tag == "Ball"){
			// Ball ball = cldr.gameObject.GetComponent<Ball>();
			// if(ball.state == ball.states.init){
			// 	Debug.Log ("ball exit from trap");
			// 	cldr.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			// 	cldr.gameObject.transform.position = Vector3.zero;
			// }
        }
    }
	void OnTriggerEnter2D(Collider2D cldr){
		if(cldr.gameObject.tag == "Ball"){
			Ball ball = cldr.gameObject.GetComponent<Ball>();
			if(ball.state == Ball.states.inside){
				// Debug.Log ("ball exit from trap");
				ball.state = Ball.states.outside;
				gi.ballsState = GameInit.BallsState.outside;
			}else {
				// Debug.Log ("ball enter to trap");
				cldr.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				cldr.gameObject.transform.position = Vector3.zero;
				ball.state = Ball.states.inside;
				trapped++;
				if(gi.getBallCount() != 0 && trapped >= gi.getBallCount()){
					gi.resetLevel();
				}
			}
        }
	}
}