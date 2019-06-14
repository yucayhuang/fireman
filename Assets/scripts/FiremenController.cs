using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremenController : MonoBehaviour {

	public FiremenInfo playerInfo;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInfo != null) {
			// player's position
			//Vector3 oldPos = transform.position;
			//this.transform.position = Mathf.Lerp(oldPos, playerInfo.pos, Time.deltaTime);
			Vector3 move = playerInfo.pos - transform.position;
			float speed = Vector3.Distance (playerInfo.pos, transform.position);
			
			this.transform.position += move * Time.deltaTime;

			//Vector3 toPos = Vector3.Lerp (transform.position, playerInfo.pos, Time.deltaTime);
			this.transform.LookAt (playerInfo.pos);

			// player's state
			FiremenStateEnum state = playerInfo.state;
			switch (state) {
				case FiremenStateEnum.Alive:
					animator.SetFloat ("Speed", speed);
					break;
				case FiremenStateEnum.Dead:
					
					break;
			}
		} else {
			Destroy (gameObject);
		}
	}

	//get angle
	private float GetAngle(Vector3 a, Vector3 b) {  
		Vector3 srcRot = new Vector3 (0, 90, 0);
		Quaternion srcQua = Quaternion.Euler (srcRot);
		Vector3 direction = b - a;
		Vector3 velocity = Quaternion.Inverse (srcQua) * direction;
		return Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
	}  
}
