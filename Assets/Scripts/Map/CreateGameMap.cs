using UnityEngine;
using System.Collections;

public class CreateGameMap : MonoBehaviour {
	public GameObject MapPrefab;
	public int MapWidth = 10;
	public int MapHeight = 10;
	public int MapZ = 10;

	public GameObject FirePrefab;
	
	// Use this for initialization
	void Start () {
		Vector3 mapPlace = Vector3.zero;
		mapPlace.z = 5;
		var go = (GameObject)Instantiate (MapPrefab, mapPlace, Quaternion.LookRotation (new Vector3 (0, 1, 0)));

		go.transform.localScale = new Vector3 (MapWidth, MapHeight, MapZ);
		go.transform.parent = this.transform;




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
