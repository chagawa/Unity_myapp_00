using UnityEngine;
using System.Collections;

public class P_attack : MonoBehaviour {

	public GameObject panti;
	private float time = 0.0f;
	private float interval = 1.2f;
	private bool attack = true;
	public GameObject Launcher;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (time > interval) {
			attack = true;
		}else{
			time += Time.deltaTime;
		}
		if (Input.GetMouseButtonDown (0) | Input.GetKeyDown(KeyCode.Z) && attack == true) {
			GameObject kodomo =(GameObject) Instantiate (panti, transform.position, transform.rotation);
			kodomo.transform.parent = Launcher.transform;
			attack = false;
			time = 0.0f;
		}
	}
}
