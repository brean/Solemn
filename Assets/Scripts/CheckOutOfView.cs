using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckOutOfView : MonoBehaviour {
    private Transform camTransform;
	
	// Update is called once per frame
	void Update () {
        camTransform = Camera.main.transform;
        if (camTransform.position.x - GameMain.screenWidth*.5 >= this.transform.position.x - 0.25)
        {

            // this will reload the level
            GameMain.OnPlayerDied();
        }
        if (this.transform.position.y < -(GameMain.screenHeight/2))
        {
            // this will reload the level
            GameMain.OnPlayerDied();
        }
    }
}
