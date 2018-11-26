using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class bloomchange : MonoBehaviour {

	public PostProcessingProfile pp;
	public GameObject o;
	float v = 1.0f;
	// Use this for initialization
	void Start () {
		BloomModel.Settings bloomsetting = pp.bloom.settings;
		bloomsetting.bloom.intensity = 2;
		bloomsetting.bloom.threshold =  .9f;
		pp.bloom.settings = bloomsetting;
	}
	
	// Update is called once per frame
	void Update () {
		if (o.active) {
			if (Input.GetKeyDown (KeyCode.E)) {
				changebloom ();
			}
		}
	}


	void changebloom()
	{	
			BloomModel.Settings bloomsetting = pp.bloom.settings;
			bloomsetting.bloom.intensity = Mathf.Lerp (2.0f, 50.0f, 1.0f);
			bloomsetting.bloom.threshold = Mathf.Lerp (0.9f, 0.0f, 1.0f);
			pp.bloom.settings = bloomsetting;
		}


}
