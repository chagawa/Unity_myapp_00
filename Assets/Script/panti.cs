using UnityEngine;
using System.Collections;

public class panti : MonoBehaviour {

	public float destroytime;
	private float time;
	public float attack;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (destroytime <= 0) {
			Destroy (gameObject);
		} else {
			destroytime -= Time.deltaTime;
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "enemy") {
			col.gameObject.SendMessage("EnemyDamege",attack);
		}
	}
}
