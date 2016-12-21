using UnityEngine;
using System.Collections;

public class FoodScripts : MonoBehaviour {

    public GameObject player;

    public int foodNum;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        speed = Random.Range(3.5f, 7f);
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
