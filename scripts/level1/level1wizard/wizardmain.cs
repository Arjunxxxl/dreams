using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardmain : MonoBehaviour {

	public Transform target;
	private float maxlookdistance = 40.0f;
	private float maxattackdistance = 20.0f;

	private float rotationDamping = 5.0f;
	private float shotInterval = 4.5f;
	private float shotTime = 0.0f;

	private float range = 15.0f;

	public GameObject shootpoint;

	private float dmg = 30.0f;
	private float health = 60.0f;

	Animator anim;

	public GameObject player;
	wandshooting ws;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ws = player.GetComponent<wandshooting> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.position, transform.position);
		if (distance <= maxlookdistance) {
			LookatTarget ();
			if (distance <= maxattackdistance && (Time.time - shotTime) > shotInterval) {
				shoot ();
			}
		}

		if (health < 0 || health == 0) {
			Destroy (gameObject);
		}
			
	}

	void LookatTarget ()
	{
		Vector3 dir = target.position - transform.position;
		dir.y = 0.0f;
		Quaternion rotation0 = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation0, Time.deltaTime * rotationDamping);
	}

	void shoot()
	{
		//Reset the time when we shoot
		shotTime = Time.time;
		anim.SetTrigger ("wizardattack");
		anim.SetTrigger ("wizardnotattack");

		RaycastHit hit;
		if (Physics.Raycast (shootpoint.transform.position, shootpoint.transform.forward, out hit, range)) {
			//damage function
			GameObject hitpoint = hit.transform.gameObject;
			if (hitpoint.tag == "Player") {
				ws.TakeDmg (dmg);
				Debug.Log("hit");
			}
		}
	}

	public void EnemyTakeDamage(float edamage)
	{
		health -= edamage;
	}

}
