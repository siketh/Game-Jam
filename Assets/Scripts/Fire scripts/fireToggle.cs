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
			(this.GetComponent<CircleCollider2D> () as CircleCollider2D).enabled = true;
			

		} else {
			(this.gameObject.GetComponentInChildren<Light> () as Light).enabled = true;
			(this.gameObject.GetComponentInChildren<Light2D> () as Light2D).enabled = true;
			(this.GetComponent<CircleCollider2D> () as CircleCollider2D).enabled = false;
			(this.GetComponent<Animator> () as Animator).enabled = true;
			(this.GetComponent<SpriteRenderer> () as SpriteRenderer).enabled = true;
		}
	}
}
