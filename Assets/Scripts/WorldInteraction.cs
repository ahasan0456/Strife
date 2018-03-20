using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {
	public float speed;
	static Animator anim;
	public float walkAnimationSpeed;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		anim.speed = walkAnimationSpeed;
	}
	
	// FixedUpdate is called several times per frame
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical")*Time.deltaTime*speed;

		transform.Rotate (0, moveHorizontal, 0);
		transform.Translate (0, 0, moveVertical);

		if (moveVertical > 0)
		{
			anim.SetBool ("isWalking", true);
		}
		else if (moveVertical < 0)
		{
			anim.SetBool ("isWalkingBack", true);
		}
		else
		{
			anim.SetBool ("isWalking",false);
		}
	}
}
