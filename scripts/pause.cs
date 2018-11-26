using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
	public static bool res = false;
	public GameObject pause1;
	public bool gpause = false;
	public GameObject loadingscreen;
	public Slider slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (res) {
				Resume();
			} else {
				pause0 ();
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Time.timeScale = 1f;
			Scene c = SceneManager.GetActiveScene();
			string name = c.name;
			LoadLevel (name);
		}
	}

	public void Resume(){
		pause1.SetActive (false);
		Time.timeScale = 1.0f;
		res = false;
		gpause = false;
	}
	public void pause0(){
		pause1.SetActive (true);
		Time.timeScale = 0f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		res = true;
		gpause = true;
	}

	public void menu()
	{
		LoadLevel ("menu");
	}

	public void quit()
	{
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
