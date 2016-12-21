using UnityEngine;
using System.Collections;

public class fallPlayerScripts : MonoBehaviour {

    public float speed;
    public float hp;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(gameObject.transform.position.z <= -0.5f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }
        if (gameObject.transform.position.z >= -0.5f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = Input.acceleration * speed * Time.fixedDeltaTime;
        gameObject.transform.position = transform.position + velocity;

        if(gameObject.transform.position.x >= 2.61f)
        {
            gameObject.transform.position = new Vector3(2.61f, transform.position.y, transform.position.z);
        }
        if(gameObject.transform.position.x <= -2.61f )
        {
            gameObject.transform.position = new Vector3(-2.61f, transform.position.y, transform.position.z);
        }
        if(gameObject.transform.position.y <= 1.5f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
        if(gameObject.transform.position.y >= 5.75f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, 5.75f, transform.position.z);
        }
    }
}
