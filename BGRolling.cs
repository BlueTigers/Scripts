using UnityEngine;
using System.Collections;

public class BGRolling : MonoBehaviour {

    public GameObject BG;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        BG = GameObject.Find("Plane");
	}
	
	// Update is called once per frame
	void Update ()
    {
        BG.transform.Translate(0, 0, -speed * Time.deltaTime);
        if(BG.transform.position.y >= 21)
        {
            BG.transform.position = new Vector3(0f, 1f, 0f);
        }
	}
}
