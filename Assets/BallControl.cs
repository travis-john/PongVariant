using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 vel;
	private GameObject p1;
	private GameObject p2;
	public float speed = 5f;
	public AudioClip beep;
	float hitFactor(Vector2 ballPos, Vector2 racketPos,
		float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void GoBall(){
		float rand = Random.Range(0.0f, 2.0f);
		if(rand < 1.0f){
			rb2d.AddForce(new Vector2(20.0f, -15.0f));
		} else {
			rb2d.AddForce(new Vector2(-20.0f, -15.0f));
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("GoBall", 2.0f);
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = beep;
	}

	void ResetPaddles(){

		p1 = GameObject.Find ("Player01");
		p1.transform.localScale = new Vector3 (.5f, 1.5f, 1f);
		p2 = GameObject.Find ("Player02");
		p2.transform.localScale = new Vector3 (.5f, 1.5f, 1f);

	}	

	void ResetBall(){
		vel.y = 0;
		vel.x = 0;
		rb2d.velocity = vel;
		gameObject.transform.position = new Vector2(0, 0);
	}

	void RestartGame(){
		ResetBall();
		ResetPaddles ();
		Invoke("GoBall", 1.0f);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		GetComponent<AudioSource> ().Play ();

		if (coll.gameObject.name == "Player01") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
				coll.transform.position,
				coll.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(1, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * speed;
			coll.gameObject.transform.localScale -= new Vector3(0, .1f, 0);
		}

		if (coll.gameObject.name == "Player02") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
				coll.transform.position,
				coll.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * speed;
			coll.gameObject.transform.localScale -= new Vector3 (0, .1f, 0);
		}

		speed += .2f;
	}

	void Update() {
		
	
	}
}
