using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class asetting : MonoBehaviour {

	public AudioMixer am;

	Resolution[] resolutions;

	public TMP_Dropdown resodrop;

	// Use this for initialization
	void Start () {
		resolutions = Screen.resolutions;
		resodrop.ClearOptions ();

		int currentreso = 0;

		List<string> rs = new List<string> ();
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + "x" + resolutions [i].height;
			rs.Add (option);
			if (resolutions [i].width == Screen.currentResolution.width && resolutions [i].height == Screen.currentResolution.height) {
				currentreso = i;
			}
		}

		resodrop.AddOptions (rs);
		resodrop.value = currentreso;
		resodrop.RefreshShownValue ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVolume(float volume)
	{
		am.SetFloat ("vol", volume);
	}

	public void quality(int level){
		QualitySettings.SetQualityLevel (level);
	}

	public void fullscreen(bool fs){
		Screen.fullScreen = fs;
	}

	public void setresolution(int ri){
		Resolution r = resolutions [ri];
		Screen.SetResolution (r.width, r.height, Screen.fullScreen);
	}


}
