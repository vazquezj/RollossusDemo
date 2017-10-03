using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float forwardSpeed;
	public float rightSpeed;
	public float jumpSpeed;
	public float rollingSpeed;
	public Rigidbody playerRigidbody;
	bool onGround = true;

	void Update ()
	{
		float forward = Input.GetAxis ("Vertical") * forwardSpeed;
		float right = Input.GetAxis ("Horizontal") * rightSpeed;
		forward *= Time.deltaTime;
		right *= Time.deltaTime;
		Vector3 movement = new Vector3 (right, 0, forward);
		playerRigidbody.AddForce (movement * rollingSpeed);

		RaycastHit hit;
		Vector3 physicsCenter = this.transform.position + this.GetComponent<CapsuleCollider> ().center;

		//Debug.DrawRay (physicsCenter, Vector3.down*0.6f, Color.red, 1.0f);
		if (Physics.Raycast (physicsCenter, Vector3.down, out hit, 0.6f))
		{
			if (hit.transform.gameObject.tag != "Player")
			{
				onGround = true;
			}
		}
		else
		{
			onGround = false;
		}
		//Debug.Log (onGround);

		if (Input.GetKeyDown ("space") && onGround)
		{
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed);
		}
	}
}