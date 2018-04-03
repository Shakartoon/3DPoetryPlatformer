using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ShootingStarSound : MonoBehaviour {


	public KeyCode spaceBar = KeyCode.Space; 
	public AudioSource sparkle; 


	// Use this for initialization
	void Start () {
		sparkle = GetComponent<AudioSource> (); 

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (spaceBar)) { 

			sparkle.Play (); 
		} 
		
	}
}
