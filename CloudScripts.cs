using UnityEngine;
using System.Collections;

public class CloudScripts : MonoBehaviour {

    public float speed;
    public float randomposX;

    public int randomCloud;

    public GameObject player;
    public GameObject[] cloud;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        randomCloud = Random.Range(0, 3);
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
        if(gameObject.transform.position.y > 6.4f)
        {
            randomposX = Random.Range(-3.05f,3.05f);
            transform.position = new Vector3(randomposX, -24f, -0.5f);
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FallPlayer")
        {
            player.GetComponent<fallPlayerScripts>().hp -= 1;
            randomposX = Random.Range(-3.05f, 3.05f);
            Instantiate(cloud[randomCloud], new Vector3(randomposX, -24f, -0.5f),transform.rotation);
            Destroy(gameObject);
        }
    }
}
