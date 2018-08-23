using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

		public float walkSpeed = 1; // player left right walk speed'

		Animator animator;

		//some flags to check when certain animations are playing
		bool isRunning = false;

		//animation states - the values in the animator conditions
		const int Idle = 0;
		const int Running = 1;

		string _currentDirection = "right";
		int _currentAnimationState = Idle;

		// Use this for initialization
		void Start()
		{
			//define the animator attached to the player
			animator = this.GetComponent<Animator>();
		}

		// FixedUpdate is used insead of Update to better handle the physics based jump
		void FixedUpdate()
	{
		//Check for keyboard input
		if (Input.GetKey ("right")) {
			changeDirection ("right");
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
			changeState (Running);

		} else if (Input.GetKey ("left")) {
			changeDirection ("left");
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
			changeState (Running);

		} else {
			changeState (Idle);
		}
			
		//check if strafe animation is playing
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Player Run"))
			isRunning = true;
		else
			isRunning = false;
	}

	void Update()
	{
		if (Input.GetKeyDown ("right"))
		{
			//Animation.play("Player Run");
		}
	}



		//--------------------------------------
		// Change the players animation state
		//--------------------------------------
		void changeState(int state){

			if (_currentAnimationState == state)
				return;

			switch (state) {

			case Idle:
				animator.SetInteger ("state", Idle);
				break;

			case Running:
				animator.SetInteger ("state", Running);
				break;

			}

			_currentAnimationState = state;
		}

		//--------------------------------------
		// Flip player sprite for left/right walking
		//--------------------------------------
		void changeDirection(string direction)
		{

			if (_currentDirection != direction)
			{
				if (direction == "right")
				{
					transform.Rotate (0, -180, 0);
					_currentDirection = "right";
				}
				else if (direction == "left")
				{
					transform.Rotate (0, 180, 0);
					_currentDirection = "left";
				}
			}

		}

	}