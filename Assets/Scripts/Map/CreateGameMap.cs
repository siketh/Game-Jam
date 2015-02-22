using UnityEngine;
using System.Collections;

public class CreateGameMap : MonoBehaviour {
	public GameObject MapPrefab;
	public GameObject FirePrefab;
	public int MapWidth = 240;
	public int MapHeight = 180;
	public int MapZ = 10;


	
	// Use this for initialization
	void Start () {
		Vector3 mapPlace = Vector3.zero;
	
		mapPlace.z = 5;
		var go = (GameObject)Instantiate (MapPrefab, mapPlace, Quaternion.LookRotation (new Vector3 (0, 1, 0)));


		go.transform.localScale = new Vector3 (MapWidth, MapHeight, MapZ);
		go.transform.parent = this.transform;

		MeshFilter mf = go.GetComponent<MeshFilter> ();
		Vector3 planeVector = (mf.mesh.bounds.max - mf.mesh.bounds.min) / 2.0f;

		int num_fires = (int)Random.Range (50, 100);
		Vector3 myVector = Vector3.zero;

		for(int i= 0; i<num_fires; i++){
			float x = Random.Range(-planeVector.x, planeVector.x);
			float y =Random.Range(-MapHeight,MapHeight);
			myVector.x = x;
			myVector.y = y;
			go = (GameObject)Instantiate (FirePrefab, myVector, Quaternion.identity);
			go.transform.parent = this.transform;
		}
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
