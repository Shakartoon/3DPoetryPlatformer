using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class PlayerControllerOnGround : MonoBehaviour {

	public GameObject player;
	public float fallHeight = -10.0f; 

	public float moveSpeed = 3.0f;
	public float jumpHeight = -10.0f; 

	public bool grounded = true; 

	public KeyCode spaceBar = KeyCode.Space; 
	public KeyCode rightKey = KeyCode.RightArrow; 

	public AudioSource sound1; 

	private int score; 
	public Text scoreText;

	void Start () {

		player = GameObject.Find ("PlayerModel2"); 

		sound1 = GetComponent<AudioSource> (); 

		score = 0; 
		SetScoreText ();  

	}

	void Update () {

		float movePlayerToTheRight = Input.GetAxis ("Horizontal"); 
		float movePlayerToTheUp = Input.GetAxis ("Vertical"); 

//		Vector3 PlayerMovement = new Vector3 (movePlayerToTheRight, movePlayerToTheUp); 

		if (Input.GetKey (rightKey)) {
			
			transform.Translate (moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey (spaceBar)) { 

			transform.position += (Vector3.up * jumpHeight * Time.deltaTime); 
		}
			
		if (player.transform.position.y <= fallHeight) {
		
			Debug.Log ("HEY!"); 
			SceneManager.LoadScene ("LOSE_SCENE"); 

		}


		//	transform.Translate (0f, 0f, jumpHeight * Time.deltaTime); 

		//	this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up) * jumpPower;  
		
		//this is a fun one for player movement in the future 
		//transform.Translate (2f, jumpHeight * Input.GetAxis ("Vertical") * Time.deltaTime, 2f); 
	}
		


	void OnCollisionEnter (Collision col) {
		
		if (col.gameObject.tag == "GoodThing") {
			Destroy (col.gameObject); 
			Debug.Log ("Something"); 
			sound1.pitch = (Random.Range (0.1f, .9f)); 
			sound1.Play ();	
			score = score + 1; 
			SetScoreText (); 
		}

		if (col.gameObject.tag == "LastCube") {
			SceneManager.LoadScene ("WIN_SCENE");
			Debug.Log ("THIS WORKED"); 
		} 

	} 

	void SetScoreText() {
		

		scoreText.text = "" + score.ToString (); 

	} 

}
