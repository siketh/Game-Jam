﻿using UnityEngine;
using System.Collections;

public class CreateLevel : MonoBehaviour {
	public int rows;
	public int cols;
	public Transform [][] map;
	// Use this for initialization
	void Start () {
		for (int i=0; i<rows; i++) {
			for(int j=0; j<cols;j++){
				Instantiate();
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
