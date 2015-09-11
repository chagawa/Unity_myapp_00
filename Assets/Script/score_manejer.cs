using UnityEngine;
using System.Collections;

public class score_manejer : MonoBehaviour {

	private float score;
	private float socre_puras = 100;
	private float time = 0;

	void Awake(){
		if (Application.loadedLevelName == "GS") {
			DontDestroyOnLoad (this);
		} else {
			Destroy (this);
		}
	}

	void Start () {
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 5) {
//			AddScore (socre_puras);
			time = 0;
		}
	}

	public void AddScore (float addScore) {
		score += addScore;
	}

	void OnGUI () {
		GUI.color = Color.black;
		GUI.Label(new Rect(10,10,100,100),"Score : "+score);
	}
}
