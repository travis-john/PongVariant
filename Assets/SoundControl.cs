using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

	public AudioClip beep;

	// Use this for initialization
	void Start () {

		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = beep;

	}

	void OnCollisionEnter() {
	
		GetComponent<AudioSource> ().Play ();
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
