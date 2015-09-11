using UnityEngine;
using System.Collections;

public class Enemy_Destroy : MonoBehaviour {

	public GameObject enemy;
	public Vector3 Enemy_spawn;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Destroy") {
			float x = Random.Range (0, 40);
			Enemy_spawn = new Vector3 (transform.position.x + 50, 2, 0);
			GameObject.Instantiate (enemy,Enemy_spawn, enemy.transform.rotation);
			Destroy (gameObject);
		}
	}
}
