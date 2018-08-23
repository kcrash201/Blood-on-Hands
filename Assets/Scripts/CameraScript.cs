using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	var cam : GameObject;

	void Start() {

		cam = GameObject.Find("Main Camera");

	}

	void Update() {
		var movement = Vector3.zero;

		if ((Input.GetKey("a")) && (cam.transform.x > -10) && (cam.transform.x < 10))
		{
			movement.x--;
		}

		if ((Input.GetKey("d")) && (cam.transform.x > -10) && (cam.transform.x < 10))
		{
			movement.x++;
		}

		transform.Translate(movement * speed * Time.deltaTime, Space.Self);

	}
}

