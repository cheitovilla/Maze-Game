using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float force;
    public Text textTime;
    public Button btnRestart;
    private float timeValue;
    private bool gameOver;


	// Use this for initialization
	void Start () {
        timeValue = 30;
        btnRestart.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        if (gameOver != true)
        {

       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vector = new Vector3(h, 0.5f, v);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(vector * force * Time.deltaTime);

        timeValue -= Time.deltaTime;
        if (timeValue <= 0f)
        {
            timeValue = 0.0f;
            gameOver = true;
            btnRestart.gameObject.SetActive(true);
        }
        textTime.text = "tiempo: " + timeValue.ToString("F2");
        }
    }

	public void OnTriggerEnter(Collider other)
	{
		if (other.name == "Enter") 
		{
            //si esta en escena1 cambia a escea 2, sino viceserva
			if (Application.loadedLevelName == "Scene1")
			{
                SceneManager.LoadScene("Scene2");
			}
			else {
				SceneManager.LoadScene("Scene1");
			}
		}
	}

    public void RestarLevel()
    {
        //codigo obsoleto pero funciona
        Application.LoadLevel(Application.loadedLevelName);
    }
}
