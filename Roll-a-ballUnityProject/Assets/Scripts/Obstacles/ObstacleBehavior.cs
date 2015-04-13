using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {

	public string type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		switch (type)
		{
		case "Kinematic":
			this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;
			break;
		}
	}

	public void Deactivate()
	{
		switch (type)
		{
		case "Kinematic":
			this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;
			break;
		}
	}
}
