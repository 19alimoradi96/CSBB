using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int strength;
	private Color color;
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
		int step = 255/GameInit.level;
		color.g = (color.g+step)%255;
	}
}
