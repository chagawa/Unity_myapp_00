using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public score_manejer Score;
	public GameObject Enemy;
	public Vector3 Enemy_spawn;
	public GameObject ExplosionMobile;

	private bool efect_hantei = true;
	private float life = 1;
	private float score = 10.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			float random = Random.Range (25, 75);
			Enemy_spawn = new Vector3 (transform.position.x + random, 2, 0);
			GameObject.Instantiate (Enemy,Enemy_spawn, Enemy.transform.rotation);
			Destroy (gameObject);
		}
	}

	void EnemyDamege(float damege){
		life -= damege;
		if (life <= 0) {
			float random = Random.Range (25, 75);
			Enemy_spawn = new Vector3 (transform.position.x + random, 2, 0);
			GameObject.Instantiate (Enemy,Enemy_spawn, Enemy.transform.rotation);
			Score.AddScore (score);
			if (efect_hantei == true) {
				GameObject.Instantiate (ExplosionMobile, transform.position, transform.rotation);
				efect_hantei = false;
			}
			Destroy (gameObject);
		}
	}
}
	