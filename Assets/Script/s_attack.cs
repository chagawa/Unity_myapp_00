using UnityEngine;
using System.Collections;

public class s_attack : MonoBehaviour {

	public GameObject syuriken;
	public GameObject Launcher;
	public GameObject himitudama;
	//public float time = 0.0f;
	//private float timeinterval = 1.8f;

	private float time = 0.0f;
	public float interval;
	private bool attack = true;
	private bool himituatack = false;
	private bool himitukougeki = false;
	private float himitutaime = 0.0f;
	private float himituinterval = 5.0f;
	private bool syurikenattack = true;
	private float zandan =0.0f;


	void Start () {

	}
	

	void Update () {
		if (time > interval) {
			attack = true;
		} else {
			time += Time.deltaTime;
		}

		if (Input.GetMouseButtonDown (1) | Input.GetKeyDown (KeyCode.X) && zandan > 0) {
			GameObject.Instantiate (himitudama, transform.position, transform.rotation);
			Debug.Log (zandan);
			zandan -= 1;
			if (attack == true && syurikenattack == true &&  zandan == 0) {
				GameObject kodomo = (GameObject)Instantiate (syuriken, transform.position, transform.rotation);
				//kodomo.transform.parent = Launcher.transform;
//			Instantiate (syuriken, transform.position, transform.rotation);
				attack = false;
				time = 0;
			}
		}

		if (himitutaime > himituinterval) {
			himitukougeki = true;
		} else {
			himitutaime += Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			himituatack = false;
			syurikenattack = true;
			Debug.Log ("syurikenattack =" + syurikenattack);
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			himituatack = true;
			syurikenattack = false;
			Debug.Log("himituatack = " + himituatack);
		}
		if (Input.GetMouseButtonDown (1) && himituatack == true && himitukougeki == true) {
			GameObject.Instantiate (himitudama, transform.position, transform.rotation);
			himitukougeki = false;
			himitutaime = 0;
		}
	}
	void OnTriggerStay(Collider stay){
		if (stay.tag == "aitemu") {
			zandan = 5.0f;
			Debug.Log (zandan);
		}
	} 
}
