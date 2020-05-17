using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	Vector2 rotation = new Vector2(0, 0);
	public float speed = 3;

	void Update()
	{
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
		transform.eulerAngles = new Vector2(0, rotation.y) * speed;
		Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * speed, 0, 0);
	}
}
