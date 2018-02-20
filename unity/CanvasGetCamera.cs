using UnityEngine;

namespace Mine.unity
{
	public class CanvasGetCamera : MonoBehaviour {

		// Use this for initialization
		void Start ()
		{
			GetComponent<Canvas>().worldCamera = Camera.main;
		}
	
	}
}
