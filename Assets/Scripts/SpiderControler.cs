using UnityEngine;
using System.Collections;
using System.Linq;

public class SpiderControler : MonoBehaviour {
	public PolygonCollider2D[] colliders;
	public int currentColliderIndex = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetColliderForSprite( int spriteNum )
	{
//		Debug.Log("Set sprite: " + spriteNum);

//		int lastIx = currentColliderIndex;
		currentColliderIndex = spriteNum;

		for (int i=0; i < colliders.Length; i++) {
			colliders[i].enabled = (i == spriteNum);
		}

		Debug.Log(Time.time + " - One is enabled: " + colliders.Any(x=>x.enabled));

//		colliders[currentColliderIndex].enabled = true;
//		colliders[lastIx].enabled = false;
		
	}
}
