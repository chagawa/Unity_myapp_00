using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

	private float zandan =0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && zandan >= 1) {
			zandan -= 1;
			Debug.Log (zandan);
		}
	}
	void OnTriggerStay(Collider stay){
		if (stay.tag == "Player") {
			zandan = 5.0f;
		}
	}
}