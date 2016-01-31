using UnityEngine;
using System.Collections;

public class PositionChange : MonoBehaviour {
	float x;
	float y;
	Vector2 pos;
	// Use this for initialization
	public void Start () {
		x = Random.Range(100,Screen.width-200);
		y = Random.Range(100,Screen.height-200);

		pos = new Vector2(x, y);
		transform.position = pos;
	}
}
