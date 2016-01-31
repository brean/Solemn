using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickCounter : MonoBehaviour 
{ 

	int counter=0; // lets start with zero 
	/*
	bool start = true;
	int x = Random.Range(0,Screen.width);
	int y = Random.Range(0,Screen.height);


	public void OnGUI() 
	{ 
		if (start) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 25, 200, 50), "Count: " + counter)) { 
				start = false;
				counter ++; 
			} 
		} else if(start != true) {

			if (GUI.Button (new Rect (x, y, 200, 50), "Count: " + counter)) { 
				x = Random.Range(0,Screen.width);
				y = Random.Range(0,Screen.height);
				counter ++;
			}
		}
	}
*/

	public void Count ()
	{
		counter++;
		if (counter >= 10)
        {
            SceneManager.LoadScene(GameMain.nextLevel());
        }
	}
}