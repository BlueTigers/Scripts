using UnityEngine;
using System.Collections;

public class FallSkyManager : MonoBehaviour {

    public GameObject player;
    public GameObject gameover;
    public GameObject homebtn;

    public int plusexp;

    public float genTime;
    public float coolTime;

    public float happynum;
    public float stuffnum;
    public float cleannum;

    public bool gameovertrue;


	// Use this for initialization
	void Start ()
    {

        genTime = 5;

        plusexp = PlayerPrefs.GetInt("GAMEEXP2");

        stuffnum = PlayerPrefs.GetFloat("STUFFNUM");
        cleannum = PlayerPrefs.GetFloat("CLEANNUM");
        happynum = PlayerPrefs.GetFloat("HAPPYNUM");
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(gameover.transform.localPosition == new Vector3(7,40,0))
        {
            homebtn.SetActive(true);
            PlayerPrefs.SetInt("GAMEEXP2", plusexp);
        }
        if(happynum >= 100)
        {
            happynum = 100;
        }
        PlayerPrefs.SetFloat("STUFFNUM", stuffnum); // stuffnum을 "STUFFNUM"에 ㅍㅍ 저장
        PlayerPrefs.SetFloat("CLEANNUM", cleannum); // cleannum을 "CLEANNUM"에 ㅍㅍ 저장
        PlayerPrefs.SetFloat("HAPPYNUM", happynum); // happynum을 "HAPPYNUM"에 ㅍㅍ 저장

        stuffnum -= Time.deltaTime * 0.025f;
        cleannum -= Time.deltaTime * 0.010f;
        happynum -= Time.deltaTime * 0.010f;
        if(gameovertrue == false)
        {
            genTime -= Time.deltaTime;
            if (genTime < coolTime)
            {
                plusexp += 5;
                happynum += 1;
                genTime = 5;
            }
        }
        if(player.GetComponent<fallPlayerScripts>().hp <= 0)
        {
            player.GetComponent<fallPlayerScripts>().hp = 0;
            player.SetActive(false);
            gameovertrue = true;
            gameover.SetActive(true);
        }
	}

    public void loadScene1()
    {
        Application.LoadLevel(1);
    }
}
