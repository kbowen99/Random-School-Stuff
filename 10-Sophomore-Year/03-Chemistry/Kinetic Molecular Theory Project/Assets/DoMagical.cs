using UnityEngine;
using System.Collections;

public class DoMagical : MonoBehaviour {
	//declare all variables and objects
	Rigidbody2D Rigid;
	GUIUpdate GUIU;
	bool CollisionHit = true;
	float TempX = 0f;
	float TempY = 0f;
	
	// Use this for initialization
	void Start () {
		//instantiate all objects
		Rigid = GetComponent<Rigidbody2D> ();
		GUIU = GameObject.FindObjectOfType (typeof(GUIUpdate)) as GUIUpdate;
		//give the molecules a starting speed (looks nicer)
		UpdateSpeed (2f);
	}
	
	// Update is called once per frame
	void Update () {
		//Gives molecule 'Velocity' unitl collision 
		if (CollisionHit == false) {
			Debug.Log("Adding Force");
			Rigid.AddForce (transform.up * TempY);
			Rigid.AddForce (transform.right * TempX);
		}
		//Key Menu
		if (Input.GetKey (KeyCode.Alpha1)) {
			NoVelocity ();
			UpdateSpeed (0);
			GUIU.NewText("Solids \n A solid has densely packed particles that are arranged in a regular sequence. Solid particles do not move, but vibrate in a fixed position");
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			NoVelocity ();
			UpdateSpeed (2);
			GUIU.NewText("Liquids \n A liquid's particles are much looser allowing for nearly free movement and collisions with other particles"); 
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			NoVelocity ();
			UpdateSpeed (4);
			GUIU.NewText("Gasses \n A gas' particles allow for free movement within each other");
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		//update once collided with
		CollisionHit = true;
		Debug.Log (other.gameObject.tag.ToString ());
	}

	float RandomPolarity(float num) {
		//Randomized Positive/Negative number polarizer
		if (Random.Range (0, 2) < 1) {
			return num;
		} else {
			return (-(num));
		}
	}

	public void UpdateSpeed(float NewSpeed) {
		//update 'Temp' Velocity values (initially known as speed)
		NewSpeed = (NewSpeed / 1000) * 2;
		TempX = RandomPolarity (NewSpeed);
		TempY = RandomPolarity (NewSpeed);
		//re-check for collision
		CollisionHit = false;
	}

	public void NoVelocity() {
		//stop object from moving, remove all velocity, allow object to move
		Rigid.isKinematic = true;
		Rigid.velocity = Vector3.zero;
		Rigid.isKinematic = false;
	}
}
