using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public GameObject self;
	public GameObject cam;

	private float _rotx;
	private float _rotY;
	public float mouseSensitivity = 50f;
	public float yAxisAngleClamp = 75f;

	public float jumpHeight;

	public bool canJump;

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update() {

		float mX = Input.GetAxis("Mouse X");
		float mY = Input.GetAxis("Mouse Y");

		_rotx += -mY * mouseSensitivity * Time.deltaTime;
		_rotY += mX * mouseSensitivity * Time.deltaTime;

		_rotx = Mathf.Clamp(_rotx, -yAxisAngleClamp, yAxisAngleClamp);

		//handle rotation for square
		Quaternion localRot = Quaternion.Euler(0f, _rotY, 0f);
		self.transform.rotation = localRot;

		//handle rotation for camera
		localRot = Quaternion.Euler(_rotx, _rotY, 0.0f);
		cam.transform.rotation = localRot;


		//player functions
		//jump
		if (Input.GetKeyDown(KeyCode.Space)&& canJump) {
			self.GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpHeight,0));
		}


	}
	private void FixedUpdate()
		{
		//player movement
			if (Input.GetKey("w"))
			{
			self.transform.position += new Vector3(self.transform.forward.x, 0, self.transform.forward.z) * moveSpeed;
			}
			if (Input.GetKey("a"))
			{
			self.transform.position += new Vector3(self.transform.right.x, 0, self.transform.right.z) * -moveSpeed;
			}
			if (Input.GetKey("d"))
			{
			self.transform.position += new Vector3(self.transform.right.x, 0, self.transform.right.z) * moveSpeed;
			}
			if (Input.GetKey("s"))
			{
			self.transform.position += new Vector3(self.transform.forward.x, 0, self.transform.forward.z) * -moveSpeed;
			}
		}

	private void OnCollisionEnter(Collision collision)
	{
		self.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if (collision.gameObject.tag == "ground")
		{
			canJump = true;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "ground")
		{
			canJump = false;

		}
	}
	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == "ground") {
			canJump = true;

		}

	}
}
