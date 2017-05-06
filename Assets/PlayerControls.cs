using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;

	public float speed = 10.0f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D>();

	}

	void OnCollisionEnter2D (Collision2D coll) {

		if (coll.gameObject.name == "Ball"){
			speed += 2f;
		}
	
	}

//	void RestartGame () {
//
//		speed = 10.0f;
//	
//	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(moveUp))
		{
			var vel = rb2d.velocity;
			vel.y = speed;
			rb2d.velocity = vel;
		} else if (Input.GetKey(moveDown))
		{
			var vel = rb2d.velocity;
			vel.y = -1 * speed;
			rb2d.velocity = vel;
		} else if (!Input.anyKey)
		{
			var vel = rb2d.velocity;
			vel.y = 0.0f;
			rb2d.velocity = vel;
		}

		var reset = rb2d.velocity;
		reset.x = 0;
		rb2d.velocity = reset;
	}
}
