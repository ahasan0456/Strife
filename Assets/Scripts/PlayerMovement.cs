﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed;
	static Animator anim;
	public float walkAnimationSpeed;
	public float rotationSpeed;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		anim.speed = walkAnimationSpeed;
	}
	void Update()
	{
		float rotate = Input.GetAxis ("Mouse X") * rotationSpeed;
		transform.Rotate (0, rotate, 0);
	}
	// FixedUpdate is called several times per frame
	void FixedUpdate ()
	{
		float speed = playerSpeed;
		float aSpeed = walkAnimationSpeed;
		if (Input.GetAxis ("Fire3") > 0)
		{
			speed = playerSpeed * 2;
			aSpeed = walkAnimationSpeed * 2;
			anim.speed = aSpeed;
		}
		else
		{
			speed = playerSpeed;
			aSpeed = walkAnimationSpeed;
			anim.speed = aSpeed;
		}
		float moveSideways = Input.GetAxis ("Horizontal")*Time.deltaTime*speed;
		float moveVertical = Input.GetAxis ("Vertical")*Time.deltaTime*speed;
        transform.Translate(moveSideways, 0, moveVertical);

		if (moveVertical > 0)
		{
			anim.SetBool ("isWalkingBack", false);
			anim.SetBool ("isWalking", true);
		}
		else if (moveVertical < 0)
		{
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isWalkingBack", true);
		}
		else if (Mathf.Abs (moveSideways) > 0)
		{
			anim.SetBool ("isWalkingBack", false);
			anim.SetBool ("isWalking", true);
		}
		else
		{
			anim.SetBool ("isWalking",false);
			anim.SetBool ("isWalkingBack",false);
		}
	}
}