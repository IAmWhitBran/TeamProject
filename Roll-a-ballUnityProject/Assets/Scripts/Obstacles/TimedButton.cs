using UnityEngine;
using System.Collections;

public class TimedButton : MonoBehaviour {

	public int duration;
	public GameObject objToAffect;

	private float tick;
	private bool touched = false;
	private GameObject timer;

	// Use this for initialization
	void Start ()
	{
		tick = 0;
		timer = this.gameObject.transform.GetChild (0).gameObject;
		timer.GetComponent<Animator> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (touched)
		{
			tick++;
			if (tick > duration)
			{
				touched = false;
				objToAffect.GetComponent<ObstacleBehavior>().Deactivate();
				timer.GetComponent<Animator>().enabled = false;
				tick = 0;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (!touched) 
			{
				touched = true;
				objToAffect.GetComponent<ObstacleBehavior>().Activate();
				timer.GetComponent<Animator>().enabled = true;
				timer.GetComponent<Animator>().Play("ClockFace");
				timer.GetComponent<Animator>().speed = duration / tick;
			} 
		}
	}
}
