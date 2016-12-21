using UnityEngine;
using System.Collections;

public class PlayerScripts : MonoBehaviour {

    public GameObject player;
	public GameObject foodNumlabel;
    public GameObject Enemy;
    public GameObject food;
    public GameObject enemyRespawn;

    public float speed;

    public int hp;
    public int foodNum;

    public bool gameoverTrue;

	// Use this for initialization
	void Start ()
    {
        hp = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
        foodNumlabel.GetComponent<UILabel> ().text = "EatFood: " + foodNum.ToString ();
	    if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed*Time.deltaTime, 0, 0);
            if (player.transform.position.x >= 2.56f)
            {
                player.transform.position = new Vector3(2.56f, -2.14f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed*Time.deltaTime, 0, 0);
            if(player.transform.position.x <= -2.56f)
            {
                player.transform.position = new Vector3(-2.56f, -2.14f, 0f);
            }
        }
    }
    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Food")
        {
            foodNum += 1;
            Destroy(Col.gameObject);
        }
    }
}
