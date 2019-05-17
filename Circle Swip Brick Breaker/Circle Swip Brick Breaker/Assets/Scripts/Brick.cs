using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int strength;
	public SpriteRenderer sr;
	private int row, col;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int getStrength(){
		return strength;
	}
	public void setStrength(int strength){
		this.strength = strength;
		int redDecreament = (GameInit.level / 256) * 4;
		int step = 255/(GameInit.level%256);
		// sr.color.g = (sr.color.g+step)%255;
    	Debug.Log ("step: " + step);
		sr.color = new Color32(System.Convert.ToByte(255-redDecreament), System.Convert.ToByte((sr.color.g*127+step)%128), System.Convert.ToByte(sr.color.b*255), 255);
	}
	public int getRow(){
		return row;
	}
	public int getCol(){
		return col;
	}
	public void setRowCol(int row, int col){
		this.row = row;
		this.col = col;
	}
	public void decreaseBricks(GameInit gi){
		gi.setBrickPrExs(row, col, false);
		if(gi.numberOfBricks <= 0){
			gi.numberOfBricks = 0;
			return;
		}
		gi.numberOfBricks--;
	}
	//OnCollisionEnter2D, Collision2D
	//OnTriggerEnter2D, Collider2D
	void OnCollisionEnter2D  (Collision2D cldr) {
        if(cldr.gameObject.tag == "Ball"){
            // Debug.Log ("ball enter");
            if(strength <= 1){
				GameInit gi = Camera.main.GetComponent<GameInit>();
                decreaseBricks(gi);
                if(gi.numberOfBricks == 0){
                    gi.resetLevel();
                }
                Destroy(gameObject);
                return;
            }
            setStrength(strength-1);
			// Rigidbody2D rb = cldr.gameObject.GetComponent<Rigidbody2D>();
			// rb.velocity = -rb.velocity;
            return;
        }
        // if(cldr.gameObject.name == "trap_circle"){
        //     Debug.Log ("trap_circle");
        //     ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		// 	ball.transform.position = Vector3.zero;
        // }
    }
}
