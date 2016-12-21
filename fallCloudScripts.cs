using UnityEngine;
using System.Collections;

public class fallCloudScripts : MonoBehaviour {

    public GameObject[] cloud;

    public int cloudnum;

    public float gentime;
    public float cooltime;

	// Use this for initialization
	void Start ()
    {
        cooltime = Random.Range(0.5f, 1.5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        cloudnum = Random.Range(0, 3);
        gentime -= Time.deltaTime;
	    if(gentime <= 0)
        {
            Instantiate(cloud[cloudnum],transform.position,transform.rotation);
            cooltime = Random.Range(0.5f, 1.5f); 
        }
	}
}
