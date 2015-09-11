using UnityEngine;
using System.Collections;

public class himitudama : MonoBehaviour {

	public float destroytime = 2f;
	private float time;
	private float h_power = 10.0f;
	public float speed = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (Vector3.right * speed, ForceMode.Impulse);
		transform.Rotate (0,0,270);
		time = 0;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (destroytime <= 0) {
			Destroy (gameObject);
		} else {
			destroytime -= Time.deltaTime;
		}
		transform.Rotate(0,0, 0);
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "enemy") {
			col.gameObject.SendMessage ("EnemyDamege",h_power);
		}
	}
}
