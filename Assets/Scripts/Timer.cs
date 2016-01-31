using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    float timer = 15.0f;

	// Use this for initialization
	void Start () {

	}

    void OnGUI()
    {
        float boxHeight = 30;
        float boxY = Screen.height - boxHeight * 2.5f;
        
        Rect rect = new Rect(
                (Screen.width / 2) - 50,
                boxY,
                50, boxHeight);
        GUI.Box(
            rect, 
            timer.ToString("0")
            );
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
