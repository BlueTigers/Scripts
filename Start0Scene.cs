using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start0Scene : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
