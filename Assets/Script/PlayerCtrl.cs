using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public int life = 3; 
	public float JumpPower = 10.0f;
	public float moveSpeed = 10f;
	public GameObject HP_3;
	public GameObject HP_2;
	public GameObject HP_1;
	public GameObject BodyPivot;
	public GameObject Explosion;
	public GameObject Damage;
	public GameObject SyogekiDamage;
	public GameObject Efect;
	public GameObject SyogekiEfect;
	public score_manejer Score;

	private bool Explosion_Decision = true;
	private bool GroundDecision = false;
	private bool deshantei = true;
	private bool damage1 = true;
	private bool damage2 = true;
	private float time = 0f;
	private float destime = 2.0f;
	private float score = 20.0f;
	private Rigidbody p_rb;

	private bool attack = false;
	private bool jump = false;
	private bool des = false;
	private bool panti_attack = true;
	private bool syuriken_attack = true;


	private float panti_time = 0.0f;
	public float interval = 1.2f;
	private float syuriken_time = 0.0f;
	public float syuriken_interval = 1.8f;

	public AudioClip SyurikenAudio;
	public AudioClip PantiAudio;
	public AudioClip JumpAudio;
	public AudioClip DeathAudio;
	public AudioClip Hit1Audio;
	public AudioClip Hit2Audio;
	private AudioSource Syuriken_Audio;
	private AudioSource Panti_Audio;
	private AudioSource Jump_Audio;
	private AudioSource Death_Audio;
	private AudioSource Hit1_Audio;
	private AudioSource Hit2_Audio;
	private bool Audio = true;
	private bool hitAudio = true;


	void Start () {
//		Debug.Log (Random.Range (1, 10));
		p_rb = GetComponent<Rigidbody> ();
		Syuriken_Audio = gameObject.GetComponent<AudioSource> ();
		Panti_Audio = gameObject.GetComponent<AudioSource> ();
		Death_Audio = gameObject.GetComponent<AudioSource> ();
		Hit1_Audio = gameObject.GetComponent<AudioSource> ();
		Hit2_Audio = gameObject.GetComponent<AudioSource> ();
		Jump_Audio = gameObject.GetComponent<AudioSource> ();
		}
	

	void Update () {

		GetComponent<Animator>().SetBool("attack",attack);
		GetComponent<Animator> ().SetBool ("jump", jump);
		GetComponent<Animator> ().SetBool ("des", des);
		if (panti_time > interval) {
			panti_attack = true;
		}else{
			panti_time += Time.deltaTime;
		}
		if (des == true) {

		}

		if (Input.GetKeyDown (KeyCode.Z) | Input.GetMouseButtonDown(0) && panti_attack == true){
			attack = true;
			StartCoroutine("Attack");
			if (Audio == true && panti_attack == true) {
				Panti_Audio.PlayOneShot (PantiAudio);
				panti_attack = false;
				panti_time = 0.0f;
			}

		}

		if (syuriken_time > syuriken_interval) {
			syuriken_attack = true;
		}else{
			syuriken_time += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.X) | Input.GetMouseButtonDown (1) && syuriken_attack == true) {
			if (Audio == true && syuriken_attack == true) {
				Syuriken_Audio.PlayOneShot (SyurikenAudio);
				syuriken_attack = false;
				syuriken_time = 0.0f;
			}
		}

		if (deshantei == true) {
			transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		}
		if (life <= 0) {
			time += Time.deltaTime;
			deshantei = false;
			des = true;
			StartCoroutine ("Des");
			if (Audio == true) {
				Death_Audio.PlayOneShot (DeathAudio);
				Audio = false;
			}
			p_rb.constraints = RigidbodyConstraints.FreezeAll;
		} 
		if (time >= destime) {
			Application.LoadLevel ("GO");
		}

		if (Input.GetKey (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Space) | Input.GetKeyDown(KeyCode.C) && GroundDecision == true) {
			jump = true;
			StartCoroutine ("Jump");
			p_rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
			if (Audio == true) {
				Jump_Audio.PlayOneShot (JumpAudio);
			}
		}
		if (life == 2) {
			Destroy (HP_3);
			if (damage1 == true) {
				GameObject syogeki = (GameObject) Instantiate (SyogekiDamage, transform.position, transform.rotation);
				syogeki.transform.parent = SyogekiEfect.transform;
				Hit1_Audio.PlayOneShot (Hit1Audio);
				damage1 = false;
			}
		} else if (life == 1) {
			Destroy (HP_3);
			Destroy (HP_2);
			if (damage2 == true) {
				GameObject ko =(GameObject) Instantiate (Damage, transform.position, transform.rotation);
				ko.transform.parent = Efect.transform;
				Hit2_Audio.PlayOneShot (Hit2Audio);
				damage2 = false;
			}
		} else if(life <= 0){
			Destroy (HP_3);
			Destroy (HP_2);
			Destroy (HP_1);
		} 
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Rock") {
			life -= 2;
		}
		if (other.tag == "Rock_score") {
			Score.AddScore (score);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "enemy") {
			life -= 1;
		}
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "Ground") {
			GroundDecision = true;
		}
	}
	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			GroundDecision = false;
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
	IEnumerator Des()	{
		yield return new WaitForSeconds (1f);
		Destroy (BodyPivot);
		if (Explosion_Decision == true) {
			GameObject.Instantiate (Explosion, transform.position, transform.rotation);
			Explosion_Decision = false;
		}
	}
}
