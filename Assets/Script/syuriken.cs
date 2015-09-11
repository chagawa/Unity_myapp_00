using UnityEngine;
using System.Collections;

public class syuriken : MonoBehaviour {

	public float destroytime;
	private float time;
	public float s_power;
	public float spinspeed;
	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (Vector3.right * speed, ForceMode.Impulse);
		transform.Rotate (90,0,0);
		//Time.timeScale = 0;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//transform.Rotate (Vector3.right * spinspeed * Time.deltaTime);
		if (destroytime <= 0) {
			Destroy (gameObject);
		} else {
			destroytime -= Time.deltaTime;
		}
		transform.Rotate( 0,-20, 0);
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "enemy") {
			col.gameObject.SendMessage ("EnemyDamege",s_power);
			Destroy (gameObject);
		}
	}
}
