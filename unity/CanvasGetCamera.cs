using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGetCamera : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GetComponent<Canvas>().worldCamera = Camera.main;
	}
	
}
