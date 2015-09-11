using UnityEngine;
using System.Collections;

public class animater_ctr : MonoBehaviour {

	private bool attack = false;
	private bool jump = false;
	private bool k_attack = true;

	private bool des = false;

	private float time = 0.0f;
	public float interval = 1.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator>().SetBool("attack",attack);
		GetComponent<Animator> ().SetBool ("jump", jump);
		GetComponent<Animator> ().SetBool ("dead", des);
		if (time > interval) {
			k_attack = true;
		}else{
			time += Time.deltaTime;
		}
		if (des == true) {
			
		}

		if (Input.GetKeyDown (KeyCode.Z) | Input.GetMouseButtonDown(0) && k_attack == true){
			attack = true;
			StartCoroutine("Attack");
			k_attack = false;
			time = 0.0f;
		}
		if (Input.GetKeyDown (KeyCode.Space) | Input.GetKeyDown(KeyCode.C)) {
			jump = true;
			StartCoroutine ("Jump");
		}
	}
	IEnumerator Attack() {
		yield return new WaitForSeconds(0.4f);
		attack = false;
	}
	IEnumerator Jump()	{
		yield return new WaitForSeconds (0.4f);
		jump = false;
	}

}
