using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class wandshooting : MonoBehaviour {

	public float damage = 10.0f;
	public float range = 100.0f;
	public GameObject muzzleFlash;
	public GameObject floorimpact;
	public GameObject eimpact;
	public GameObject bridge;

	public AudioClip ac;
	private AudioSource audiosouce;

	private float fireRate = 10.0f;
	private float nextfire = 0.0f;

	private float health = 100.0f;

	public Image damageImage;
	private float flashSpeed = 5.0f;
	private Color flashColour = new Color (1f, 0f, 0f, 0.4f);
	bool damaged;

	public Camera fpsCam;
	// Use this for initialization
	void Start () {
		audiosouce = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextfire) {
			nextfire = Time.time + (1.0f/fireRate);
			Shoot ();
			StartCoroutine(playparticlesystem ());
		}
		Flashcolor ();
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			//damage function
			GameObject hitpoint = hit.transform.gameObject;
			audiosouce.clip = ac;
			if (hitpoint.tag == "floor1") {
				GameObject expo = Instantiate (floorimpact, hit.point, Quaternion.LookRotation (hit.normal));
				audiosouce.Play ();
				Destroy (expo, 1.0f);
			}
			else if (hitpoint.tag == "level1bridge") {
				GameObject expo = Instantiate (bridge, hit.point, Quaternion.LookRotation (hit.normal));
				Destroy (expo, 1.0f);
				audiosouce.Play ();
			}else if (hitpoint.tag == "enemy") {
				GameObject eexpo = Instantiate (eimpact, hit.point, Quaternion.LookRotation (hit.normal));
				Destroy (eexpo, 1.0f);
				audiosouce.Play ();
				wizardmain wm = hitpoint.transform.gameObject.GetComponent<wizardmain> ();
				wm.EnemyTakeDamage (damage);
			}
		}
	}

	IEnumerator playparticlesystem()
	{
		muzzleFlash.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		muzzleFlash.SetActive (false);
	}

	public void TakeDmg(float val){
		health -= val;
		Debug.Log (health);
		damaged = true;
	}

	void Flashcolor()
	{
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
	}

}
