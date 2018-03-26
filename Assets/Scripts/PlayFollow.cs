using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFollow : MonoBehaviour
{
	public Transform PlayerTransform;

	private Vector3 cameraOffset;
	public float RotationSpeed = 5.0f;

	void Start ()
    {
		Cursor.visible = false;
		cameraOffset = transform.position - PlayerTransform.position;
	}
	void Update()
	{
		cameraOffset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * RotationSpeed, Vector3.up)*cameraOffset;
	}
	void LateUpdate ()
    {
		transform.position = PlayerTransform.position + cameraOffset;
		transform.LookAt (PlayerTransform);
	}
}