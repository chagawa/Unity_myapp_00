using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	//これ応用すれば武器チェの実装できるんじゃね？
	public bool tes = false;
	public bool abc = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			tes = true;
			abc = false;
//			Debug.Log ("tes = " + tes);
		}
		if (Input.GetMouseButton(0) && tes == true) {
//			Debug.Log ("aaaa");	
		}
		if (Input.GetKey (KeyCode.W)) {
			tes = false;
			abc = true;
//			Debug.Log ("abc = " + abc);
		}
		if (Input.GetMouseButton(0) && abc == true) {
//			Debug.Log ("bbbbb");
		}
	}
}