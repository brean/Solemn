using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Button startText;
    
	// Use this for initialization
	void Awake () {
        startText = startText.GetComponent<Button>();
	}
	
	public void StartLevel(){
        SceneManager.LoadScene(GameMain.LEVEL_1);
	}
}
