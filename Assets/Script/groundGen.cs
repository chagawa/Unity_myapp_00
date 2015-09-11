using UnityEngine;
using System.Collections;

public class groundGen : MonoBehaviour {

	public GameObject GROUND;
	private Vector3 myPos;


	void Start () {
		myPos = new Vector3 (transform.position.x + 128, transform.position.y, transform.position.z);
	}
	

	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Instantiate (GROUND, myPos, GROUND.transform.rotation);
		}
		if (other.tag == "Destroy") {
			Destroy (gameObject);
		}
	}
}
