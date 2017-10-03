using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBallScript : MonoBehaviour {

	public Transform followPoint;

	void Update ()
	{
		transform.position = new Vector3 (followPoint.transform.position.x, followPoint.transform.position.y, followPoint.transform.position.z);
	}
}