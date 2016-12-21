using UnityEngine;
using System.Collections;

public class FallCloudGameOver : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if(gameObject.transform.localPosition.y < 40)
        {
            gameObject.transform.localPosition = new Vector3(7, 40, 0);
        }
	}
}
