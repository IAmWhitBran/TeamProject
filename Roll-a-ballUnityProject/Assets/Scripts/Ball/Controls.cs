using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public bool isMirror;
	public float currentSpeed;
	public float maxSpeed;
	private float distToGround;
	public AudioClip[] collisonSounds;


	// Use this for initialization
	void Start () 
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		distToGround = GetComponent<Collider>().bounds.extents.y;
		maxSpeed = 75f;
		//collisonSounds = new AudioClip[]{};
	}

	// Update is called once per frame
	void Update () 
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

//		if (!IsGrounded ())
//						Debug.Log ("in air");

        #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        /* 
         * Check for player keyboard input and move ball accordingly
         */
<<<<<<< HEAD
		if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && IsGrounded())
		{
        	if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				GetComponent<Rigidbody>().AddForce(Vector3.forward * 10.0f);
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				GetComponent<Rigidbody>().AddForce(Vector3.back * 10.0f);
			}
			if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
			{
				GetComponent<Rigidbody>().AddForce(Vector3.left * 10.0f);
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				GetComponent<Rigidbody>().AddForce(Vector3.right * 10.0f);
			}
=======
		switch (isMirror)
		{
			case false:
				if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && IsGrounded())
				{
					if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.forward * 10.0f);
					}
					if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.back * 10.0f);
					}
					if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.left * 10.0f);
					}
					if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.right * 10.0f);
					}
				}
				break;
			case true:
				if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && IsGrounded())
				{
					if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.forward * -10.0f);
					}
					if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.back * -10.0f);
					}
					if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.left * -10.0f);
					}
					if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
					{
						GetComponent<Rigidbody>().AddForce(Vector3.right * -10.0f);
					}
				}
				break;
>>>>>>> a076e646d6e0e641506f470c99812018d4eda82f
		}
        #endif

        #if UNITY_ANDROID
        /*
         * Move ball based on accelerometer values
         */
        Vector3 movement = new Vector3(Input.acceleration.x, 0f, Input.acceleration.y); //-y

		switch (isMirror)
		{
			case false:
				if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && IsGrounded())
				{
		        	GetComponent<Rigidbody>().AddForce(movement * 50f);
				}
				break;
			case true:
				if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && IsGrounded())
				{
					GetComponent<Rigidbody>().AddForce(movement * -50f);
				}
				break;
		}
        #endif
	}

	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	//added by adam
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup")
		{
			this.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;
			other.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		Ray colRay = new Ray();
		colRay.origin = transform.position;
		colRay.direction = other.contacts[0].point - this.transform.position;

		// dont want to colide with objects we are rollling on
		if (colRay.direction.y>-.1)
		{
<<<<<<< HEAD
			//Debug.Log("The object is not above.");

			// these shouldnt trigger collisions either
			if (/*other.gameObject.name != "FloorTL" &&
			    other.gameObject.name != "FloorBL" &&
			    other.gameObject.name != "FloorTR" &&
			    other.gameObject.name != "FloorBR" &&*/
			    other.gameObject.name != "CubeSlope")
			{
				//Debug.Log(other.gameObject.name);
				this.GetComponent<AudioSource>().Play();
				#if UNITY_ANDROID
				Handheld.Vibrate ();
				#endif
			}
=======
			this.GetComponent<AudioSource>().clip = collisonSounds[Random.Range(0,3)];
			this.GetComponent<AudioSource>().Play();
			#if UNITY_ANDROID
			Handheld.Vibrate ();
			#endif
>>>>>>> a076e646d6e0e641506f470c99812018d4eda82f
		}
	}
}
