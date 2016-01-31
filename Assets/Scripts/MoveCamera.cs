using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    private bool active = true;
    private Vector3 position;
    private Vector3 bgPosition;

    // stop camera from moving
    public void StopMove()
    {
        active = false;
    }
 
    void Start () {
        Application.targetFrameRate = 60;
    }
	
	void Update () {
        if (!active)
        {
            return;
        }
        // move camera every frame
        this.position = this.transform.position;

        // move 5 pixel per second
        this.position.x += 0.05f;

        this.transform.position = this.position;
        // move background
        this.bgPosition = GameObject.Find("Background").transform.position;
        this.bgPosition.Set(this.position.x, this.bgPosition.y, this.bgPosition.z);
        GameObject.Find("Background").transform.position = this.bgPosition;
        // move Moon
        this.bgPosition = GameObject.Find("Moon").transform.position;
        this.bgPosition.Set(this.bgPosition.x-0.0005f, this.bgPosition.y, this.bgPosition.z);
        GameObject.Find("Moon").transform.position = this.bgPosition;

    }
}
