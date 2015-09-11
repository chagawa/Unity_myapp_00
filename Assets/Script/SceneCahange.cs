using UnityEngine;
using System.Collections;

public class SceneCahange : MonoBehaviour {

	public string GS;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		Application.LoadLevel (GS);
	}
}
