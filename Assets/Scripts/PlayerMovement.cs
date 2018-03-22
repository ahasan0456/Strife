using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed;
	static Animator anim;
	static Rigidbody rb;
	public float walkAnimationSpeed;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		anim.speed = walkAnimationSpeed;
		rb = GetComponent<Rigidbody> ();
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
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical")*Time.deltaTime*speed;

		Transform.Rotate (0, moveHorizontal, 0);
		rb.MovePosition (new Vector3(0,0,moveVertical));

		if (moveVertical > 0)
		{
			anim.SetBool ("isWalkingBack",false);
			anim.SetBool ("isWalking", true);
		}
		else if (moveVertical < 0)
		{
			anim.SetBool ("isWalking",false);
			anim.SetBool ("isWalkingBack", true);
		}
		else
		{
			anim.SetBool ("isWalking",false);
			anim.SetBool ("isWalkingBack",false);
		}
	}
}