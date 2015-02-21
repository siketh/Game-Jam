using UnityEngine;
using System.Collections;

public class WallSensor : MonoBehaviour {
	
	public float range;
	public float distanceForward;
	public float distanceRight;
	public float distanceLeft;
	private Vector2 rightVector;
	private Vector2 leftVector;
	private RaycastHit2D forwardSensor;
	private RaycastHit2D rightSensor;
	private RaycastHit2D leftSensor;

	//private Quaternion leftAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
	
	// Update is called once per frame
	void Update () {

		rightVector = new Vector2((transform.up.x * Mathf.Cos(-45 * Mathf.Deg2Rad)) - 
		                          (transform.up.y * Mathf.Sin(-45 * Mathf.Deg2Rad)), 
		                          (transform.up.x * Mathf.Sin(-45 * Mathf.Deg2Rad)) + 
		                          (transform.up.y * Mathf.Cos(-45 * Mathf.Deg2Rad)));

		leftVector = new Vector2((transform.up.x * Mathf.Cos(45 * Mathf.Deg2Rad)) - 
		                         (transform.up.y * Mathf.Sin(45 * Mathf.Deg2Rad)), 
		                         (transform.up.x * Mathf.Sin(45 * Mathf.Deg2Rad)) + 
		                         (transform.up.y * Mathf.Cos(45 * Mathf.Deg2Rad)));

		forwardSensor = Physics2D.Raycast (transform.position,
		                                   transform.up, 
		                                   range, 
		                                   1 << LayerMask.NameToLayer("Walls"));

		rightSensor = Physics2D.Raycast (transform.position,
		                                 rightVector,
		                                 range, 
		                                 1 << LayerMask.NameToLayer("Walls"));

		leftSensor = Physics2D.Raycast (transform.position,
		                                leftVector,
		                                range, 
		                                1 << LayerMask.NameToLayer("Walls"));

		if (forwardSensor.collider != null) {
			distanceForward = Vector2.Distance(forwardSensor.point, transform.position);
			Debug.DrawRay (transform.position, transform.up * distanceForward, Color.red);
		} else {
			distanceForward = 1.00f;
			Debug.DrawRay (transform.position, transform.up * range, Color.red);
		}

		if(rightSensor.collider != null)
		{
			distanceRight = Vector2.Distance(rightSensor.point, transform.position);
			Debug.DrawRay (transform.position, rightVector * distanceRight, Color.red);
		} else {
			distanceRight = 1.00f;
			Debug.DrawRay (transform.position, rightVector * range, Color.red);
		}

		if(leftSensor.collider != null)
		{
			distanceLeft = Vector2.Distance(leftSensor.point, transform.position);
			Debug.DrawRay (transform.position, leftVector * distanceLeft, Color.red);
		} else {
			distanceLeft = 1.00f;
			Debug.DrawRay (transform.position, leftVector * range, Color.red);
		}

	}
}
