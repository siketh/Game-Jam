﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	//public Light spotlight;
	public float movementSpeed = 2f;
	public List<GameObject> adjacentAgents = new List<GameObject>();
	public Animation animate;

	void Start() {
		//GameObject sprite = transform.FindChild("PlayerSprite").gameObject;
		//animate = sprite.animation;
	}

	void Update () 
	{
		bool moved = false;
		if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (0f, 0f, -2.5f);
				
		}
		if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (0f, 0f, 2.5f);

		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += -transform.up * Time.deltaTime * movementSpeed;
			moved = true;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= -transform.up * Time.deltaTime * movementSpeed;
			moved = true;
		}
	}

	void OnTriggerEnter2D( Collider2D col )
	{
		if (col.gameObject.tag == "agent") 
		{
			adjacentAgents.Add(col.gameObject);
		}

	}

	void OnTriggerExit2D( Collider2D col )
	{
		if (col.gameObject.tag == "agent") 
		{
			adjacentAgents.Remove(col.gameObject);

		}
	}
}
