using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour {


	public GameObject letterH; 
	public GameObject letterO; 

	public float letterWidth = 0.5f;
	public float letterHeight = 0.5f;

	public string levelFile = "Level1.txt"; 

	// Use this for initialization
	void Start () {

		string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);

		string[] levelLines = levelString.Split('\n'); 
		int width = 0; 

		for (int row = 0; row < levelLines.Length; row++) {
			string currentLine = levelLines [row]; 
			width = currentLine.Length; 
			for (int col = 0; col < currentLine.Length; col++) {
				char currentChar = currentLine [col]; 
				if (currentChar == 'h') {
					GameObject H_Letter = Instantiate (letterH); 
					H_Letter.transform.parent = transform; 
					H_Letter.transform.position = new Vector3 (col * letterWidth, -row * letterHeight, 0);
				} else if (currentChar == 'o') {
					GameObject O_Letter = Instantiate (letterO); 
					O_Letter.transform.parent = transform; 
					O_Letter.transform.position = new Vector3 (col * letterWidth, -row * letterHeight, 0); 
				}
			}
		
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
