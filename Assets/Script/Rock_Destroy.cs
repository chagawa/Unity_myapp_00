using UnityEngine;
using System.Collections;

public class Rock_Destroy : MonoBehaviour {

	public GameObject rock;
	public Vector3 myPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Destroy") {
			float random = Random.Range (90, 130);
			myPos = new Vector3 (transform.position.x + random, 0, 0);
			GameObject.Instantiate (rock,myPos, rock.transform.rotation);
			Destroy (gameObject);
		}
	}
}
