using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public Transform cam;
	public float distanceVariable = 1.0f;
	public float heightDefault = 2.0f;
	public float widthDefault = 1.0f;

	const float TO_RADS = 3.141592654f / 180.0f;

	// Update is called once per frame
	void Update () {

		//find offset distance
		float offset = Mathf.Sin(cam.localRotation.x);

		//apply offset
		cam.localPosition = new Vector3(cam.localPosition.x, heightDefault + offset*(distanceVariable/2), -(distanceVariable/2.0f) + (Mathf.Abs(offset) * distanceVariable) - widthDefault);

		//bind above ground
		if (cam.position.y <= 0.5f) {
			cam.position = new Vector3(cam.position.x, 0.5f, cam.position.z);
		}
	}
}

