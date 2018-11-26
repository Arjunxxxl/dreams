using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public GameObject loadingscreen;
	public Slider slider;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sd(){
		LoadLevel("level1harrypotterjungle");
	}

	public void quit(){
		Application.Quit ();
	}




	public void LoadLevel(string name){
		StartCoroutine (level (name));
	}

	IEnumerator level(string name){
		AsyncOperation op = SceneManager.LoadSceneAsync (name);
		loadingscreen.SetActive (true);
		while(!op.isDone)
		{
			float progress = Mathf.Clamp01 (op.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}

}
