using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 vector = new Vector3 (h, 0.5f, v);

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (vector * force * Time.deltaTime);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.name == "Enter") 
		{
			if (Application.loadedLevelName == "Scene1")
			{
				Application.LoadLevel("Scene2");
			}
			else {
				Application.LoadLevel("Scene1");
			}
		}
	}
}
