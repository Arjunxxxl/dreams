using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textblinking : MonoBehaviour {

	public TMP_Text restart;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		restart.color = Color.Lerp(Color.gray,Color.white,Mathf.PingPong(Time.time*1,1.0f ));
	}
}
