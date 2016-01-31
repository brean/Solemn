using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameMain.OnPlayerDied();
        }
    }
}
