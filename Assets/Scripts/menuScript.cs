using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Button startText;
    public int loadScene = GameMain.LEVEL_1;

    // Use this for initialization
    void Awake () {
        startText = startText.GetComponent<Button>();
	}
	
	public void StartLevel(){
        // Load first level
        SceneManager.LoadScene(loadScene);
	}
}
