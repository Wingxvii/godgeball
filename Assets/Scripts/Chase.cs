using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Transform target;
	public GameObject self;
	public GameObject cam;
	public float speed;
	public float knockback;
	public Attack playerattacks;
	public float attackReach;
	public float vthreshold;
	public int ballnumber;


	private void Start()
	{
		self = this.gameObject;
		target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
		cam = GameObject.FindGameObjectWithTag("camera");
		playerattacks = GameObject.FindGameObjectWithTag("player").GetComponent<Attack>();

		//tell player that this ball is active
		ballnumber = ++playerattacks.numBalls;
	}

	// Update is called once per frame
	void Update () {
		Vector3 path = target.position - self.GetComponent<Transform>().position;
		float pathMag = new Vector2(path.x, path.z).magnitude;

		path = path.normalized;

		if (pathMag <= attackReach) {
			playerattacks.InRange(ballnumber);
		} else{
			playerattacks.OutRange(ballnumber);

		}

		//adds knockback for single hit
		if (playerattacks.singleActive && pathMag <= attackReach && playerattacks.loadedBall == ballnumber)
		{
			self.GetComponent<Rigidbody>().AddForce(cam.GetComponent<Transform>().forward * knockback);
		}

		//adds knockback for force attack
		if (playerattacks.forceActive && pathMag <= attackReach)
		{
			self.GetComponent<Rigidbody>().AddForce(cam.GetComponent<Transform>().forward * knockback);
		}


		//add speed if needed
		if (self.GetComponent<Rigidbody>().velocity.magnitude <= vthreshold) {
			self.GetComponent<Rigidbody>().AddForce(path*speed);
		}

	}

}
