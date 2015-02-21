using UnityEngine;
using System.Collections;

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
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}
}
