using UnityEngine;
using System.Collections;

public class CrateBuilder : MonoBehaviour {
	public GameObject CratePrefab;
	public int numCrates;

	public float minBackgroundBound;
	public float maxBackgroundBound;
	private float xCoord;
	private float yCoord;

	// Use this for initialization
	void Start () 
	{
		//list of game objects that are crates
		for(int i=0; i<numCrates; i++)
		{
			xCoord = Random.Range(minBackgroundBound, maxBackgroundBound);
			yCoord = Random.Range(minBackgroundBound, maxBackgroundBound);

			Vector3 MapPlace = new Vector3(xCoord,yCoord,0);

			GameObject Crate = (GameObject)Instantiate (CratePrefab, MapPlace, Quaternion.identity);

			//go.transform.localScale = new Vector3 (MapWidth, MapHeight, MapZ);
			Crate.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
