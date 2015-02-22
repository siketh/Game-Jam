using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {
	public enum AIType
		{
		Seek,
		Pursuit
		}

	public float moveSpeed = 1f;
	public float rotationSpeed = 1f;
	public float lookAheadMultiplier = 5f;
	public float maxLookAheadDistance = 5f;

	public AIType AIBehavior = AIType.Seek;

	private Transform target;
	private float range;
	private Vector3 lastPosition;
	private float playerSpeed;


	void Start() 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		lastPosition = target.transform.position;
	}

	Vector3 HeadToTarget(Vector3 vectorTarget)
	{
		Vector2 difVec = vectorTarget - transform.position;
		difVec.Normalize ();
		return difVec;
	}

	void Update () 
	{
		playerSpeed = (target.transform.position - lastPosition).magnitude/Time.deltaTime;

		lastPosition = target.transform.position;

		//stop moving if you're on the target
		if ((target.position - transform.position).magnitude < .2) {
			return;
		}

		Vector3 difVec = new Vector3();

		switch(AIBehavior)
		{
		case AIType.Seek:
			difVec = HeadToTarget(target.position);
			transform.position += difVec * moveSpeed * Time.deltaTime;
			break;
		case AIType.Pursuit:
			float lookAhead = Mathf.Min(playerSpeed*lookAheadMultiplier, maxLookAheadDistance);
			Vector3 futurePoint = target.transform.position + target.transform.up*lookAhead;

			if(Vector3.Dot(futurePoint, target.up) < 0)
			{
				AIBehavior = AIType.Seek;
				break;
			}
			else
			{
				difVec = HeadToTarget(futurePoint);
				transform.position += difVec * moveSpeed * Time.deltaTime;
			}

			break;
		}

		//range = Vector2.Distance (transform.position, target.transform.position);

//		transform.Translate(Vector2.MoveTowards(transform.position, 
//		                                        target.transform.position,
//		                                        1000f) * moveSpeed * Time.deltaTime);

	}
}
