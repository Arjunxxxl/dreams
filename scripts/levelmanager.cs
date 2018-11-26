using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class levelmanager : MonoBehaviour {

	public GameObject b1,b2;
	public GameObject net;
	public GameObject clown;
	public GameObject peoples;

	public GameObject keys_collected;
	public GameObject keys;
	public GameObject hint;

	public AudioClip keytaken;
	private AudioSource source;

	public GameObject alarm;
	public GameObject wakeup;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (b1.active == true && b2.active == true) {
			net.SetActive (false);
		}

		if (clown.active == false) {
			peoples.SetActive (false);
			hint.SetActive (false);
			alarm.SetActive (true);
			wakeup.SetActive (true);
		}

		if (keys.active == false) {
			keys_collected.SetActive (true);
			source.clip = keytaken;
			source.Play ();
		}
	}
}
