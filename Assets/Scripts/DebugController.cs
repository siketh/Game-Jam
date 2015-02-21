using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DebugController : MonoBehaviour {

	public Text position;
	public Text heading;
	public Text adjacentAgents;
	public Text pieSlice;
	public Text wallSensors;
	public PlayerController playerController;
	public WallSensor wallSensor;
	public int numUp = 0;
	public int numLeft = 0;
	public int numRight = 0;
	public int numDown = 0;

	void Start() {
		playerController = gameObject.GetComponent<PlayerController> ();
		wallSensor = gameObject.GetComponent<WallSensor> ();
	}

	// Update is called once per frame
	void updatePlayerPosition() {
		string degrees = transform.eulerAngles.z.ToString ("F2");
		string x = transform.position.x.ToString ("F2");
		string y = transform.position.y.ToString ("F2");
		position.text = "Position: (" + x + ", " + y + ")";
		heading.text = "Heading: " + degrees + "°";	
	}

	void updatePieSliceSensor() {
		string text = "Up: " + numUp + "/5\n";
		text += "Left: " + numLeft + "/5\n";
		text += "Right: " + numRight + "/5\n";
		text += "Down: " + numDown + "/5\n";
		pieSlice.text = text;
	}

	void updateAdjacentSensor() {
		adjacentAgents.text = "";
		numUp = 0;
		numRight = 0;
		numLeft = 0;
		numDown = 0;
		foreach (GameObject g in playerController.adjacentAgents) {
			adjacentAgents.text += "Distance: ";
			adjacentAgents.text += Vector3.Distance(transform.position, g.transform.position).ToString("F2");
			Vector3 targetDir = g.transform.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, targetDir);
			float determinant = transform.up.x * targetDir.y - transform.up.y * targetDir.x;
			float angle = Mathf.Atan2(determinant, dotProduct) * Mathf.Rad2Deg;
			if(angle < 0) {
				angle = 180f + (180f + angle);
			}
			adjacentAgents.text += ", Heading: " + angle.ToString("F2") + "°\n";
			if(angle < 45 && angle > 0 || angle > 315 && angle < 360)
				numUp += 1;
			else if(angle > 30 && angle < 120)
				numLeft += 1;
			else if(angle > 120 && angle < 210)
				numDown += 1;
			else
				numRight += 1;
		}
		updatePieSliceSensor ();
	}

	void updateWallSensor() {
		string text = "Rangefinders:\n";
		text += "Left: " + wallSensor.distanceLeft.ToString ("F2") + "\n";
		text += "Straight: " + wallSensor.distanceForward.ToString ("F2") + "\n";
		text += "Right: " + wallSensor.distanceRight.ToString ("F2") + "\n";
		wallSensors.text = text;
	}

	void Update () {
		updatePlayerPosition ();
		updateAdjacentSensor ();
		updateWallSensor ();
	}
}
