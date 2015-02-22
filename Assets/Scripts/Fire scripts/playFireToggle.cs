using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class playFireToggle : MonoBehaviour {

	List<GameObject> allFires;
	public float distanceTurnOn = 1.0f;

	// Use this for initialization
	void Start () {
		allFires = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Fire"));
	}
	
	// Update is called once per frame
	void Update () {

		allFires.Where (x => Vector3.Distance (x.transform.position, transform.position) < distanceTurnOn ).ToList ().ForEach (light => {
			(light.GetComponent<fireToggle>() as fireToggle).setFireOn(true);
		});
	}
}
