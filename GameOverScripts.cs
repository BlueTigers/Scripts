using UnityEngine;
using System.Collections;

public class GameOverScripts : MonoBehaviour {


    public GameObject GameOver;

    public float speed;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameOver.transform.Translate(0f, -speed*Time.deltaTime, 0f);
        if(GameOver.transform.localPosition.y <= -17)
        {
            GameOver.transform.localPosition = new Vector3(3f, -17f, 0);
        }       
	}
}
