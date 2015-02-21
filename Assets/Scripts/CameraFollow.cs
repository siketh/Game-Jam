using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float smoothTime = 0.3f;
	
	private Vector3 velocity = Vector3.zero;
	
	void Update () 
	{
		float posX = target.position.x;
		float posY = target.position.y;
		float posZ = -1;

		Vector3 newPos = new Vector3(posX, posY, posZ);

		transform.position = Vector3.SmoothDamp (transform.position, newPos, ref velocity, smoothTime);

	}
}