using UnityEngine;
using System.Collections;

public class CreateRules : MonoBehaviour {

	private string displayText;
	public TextMesh testMesh;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		display();
	}
	
	void display()
	{
		displayText = "Try to catch me little girl.";//get display text
		testMesh = GetComponent<TextMesh>();
		testMesh.text = displayText;
		if (Time.time - startTime >= 2) {
			displayText = "Or death awaits you! ";//get display text
			testMesh = GetComponent<TextMesh>();
			testMesh.text = displayText;
		}
		if (Time.time - startTime >= 4) {
			displayText = "Hit the bat 30 times \n in the given time frame";//get display text
			testMesh = GetComponent<TextMesh>();
			testMesh.text = displayText;
		}
		if (Time.time - startTime >= 6) {
			displayText = "to succeed ";
			testMesh = GetComponent<TextMesh>();
			testMesh.text = displayText;
		}
		if (Time.time - startTime >= 7) {
			displayText = " ";
			testMesh = GetComponent<TextMesh>();
			testMesh.text = displayText;
		}
	}
}