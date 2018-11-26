using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clowndie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		GameObject o = col.gameObject;
		if (o.tag == "water") {
			gameObject.SetActive (false);
		}
			
	}

}
