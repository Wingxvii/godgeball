using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public GameObject self;
	public GameObject cam;
	public PlayerMovement move;

	public float lightAttackPower;

	public bool forceActive;
	public int forceCooldown;

	public bool singleActive;
	public int singleCooldown;

	public int numBalls = 0;
	public List<int> activeballs;
	public int loadedBall;

	

	// Update is called once per frame
	void Update () {
		forceCooldown--;
		singleCooldown--;

		
		if (forceCooldown >= 10)
		{
			forceActive = true;
		}
		else {
			forceActive = false;
		}
		if (singleCooldown >= 10)
		{
			singleActive = true;
		}
		else
		{
			singleActive = false;
		}



		//force push
		if (Input.GetKeyDown(KeyCode.Mouse1) && forceCooldown <= 0)
		{
			forceCooldown = 30;
		}

		//single throw
		if (Input.GetKeyDown(KeyCode.Mouse0) && singleCooldown <= 0 && activeballs.Count > 0)
		{
			loadedBall = activeballs[0];
			activeballs.RemoveAt(0);
			activeballs.TrimExcess();

			singleCooldown = 30;
		}


	}

	public void InRange(int ballN) {
		if (!activeballs.Contains(ballN))
		{
			activeballs.Add(ballN);
		}
	}
	public void OutRange(int ballN)
	{
		if (activeballs.Contains(ballN))
		{
			activeballs.Remove(ballN);
			activeballs.TrimExcess();
		}
	}

}
