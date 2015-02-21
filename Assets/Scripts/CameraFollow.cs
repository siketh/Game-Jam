using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	
	void Update () 
	{
		float posX = target.position.x;
		float posY = target.position.y;
		float posZ = -1;

		Vector3 newPos = new Vector3(posX, posY, posZ);

		transform.position = newPos;
	}
}