using UnityEngine;
using System.Collections;

public class fireToggle : MonoBehaviour {


	// Use this for initialization
	void Start () {
		setFireOn (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setFireOn(bool haveON){
	if (!haveON) {
			(this.gameObject.GetComponentInChildren<Light> () as Light).enabled = false;//.renderer.enabled = false;
			(this.gameObject.GetComponentInChildren<Light2D> () as Light2D).enabled = false;
		} else {
			(this.gameObject.GetComponentInChildren<Light> () as Light).enabled = true;
			(this.gameObject.GetComponentInChildren<Light2D> () as Light2D).enabled = true;
		}
	}
}
