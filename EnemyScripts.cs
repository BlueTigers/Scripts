using UnityEngine;
using System.Collections;

public class EnemyScripts : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        speed = Random.Range(3.5f, 7f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(0, -speed*Time.deltaTime, 0);
	}
    void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player")
       {
            player.GetComponent<PlayerScripts>().hp -= 1;
            Destroy(gameObject);
       }
       if(col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
