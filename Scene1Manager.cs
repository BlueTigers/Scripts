using UnityEngine;
using System.Collections;

public class Scene1Manager : MonoBehaviour {

    public GameObject stuffbar;
    public GameObject cleanbar;
    public GameObject happybar;
    public GameObject gameover;
    public GameObject foodNumLabel;
    public GameObject happypicture;
    public GameObject normalpicture;
    public GameObject dirtypicture;
    public GameObject Player;
    public GameObject RebornLabel;

    public float stuffNum;
    public float cleanNum;
    public float happyNum;


    public int foodexp;
    public int foodsaveexp;
    public int showerexp;
    public int showersaveexp;
    public int gamesaveexp;
    public int gamesaveexp2;
    public int maxexp;
    public int plusexp;
    public int mainexp;

    public int rebornNumber;

    public int CoinNumber;

    public int PoopGameManagerFood;
    public int allfoodnum;
    public int foodNumber;
    public int nowFoodnum; // 현재 푸드의 갯수

    public bool stuff;
    public bool clean;
    public bool happy;

	// Use this for initialization
	void Start ()
    {

        stuffNum = PlayerPrefs.GetFloat("STUFFNUM");
        cleanNum = PlayerPrefs.GetFloat("CLEANNUM");
        happyNum = PlayerPrefs.GetFloat("HAPPYNUM");

        PlayerPrefs.GetInt("FOODEXP");
        PlayerPrefs.GetInt("SHOWEREXP");

        stuffbar = GameObject.Find("stuffgaugeback");
        happybar = GameObject.Find("cleangaugeback");
        cleanbar = GameObject.Find("Happygaugeback");
    }
	
	// Update is called once per frame
	void Update ()
    {
        rebornNumber = PlayerPrefs.GetInt("REBORN");
        rebornNumber += 1;
        RebornLabel.GetComponent<UILabel>().text =  "Reborn : " + rebornNumber.ToString();

        PlayerPrefs.SetInt("PLUSEXP", plusexp);

        foodsaveexp = PlayerPrefs.GetInt("FOODEXP");
        showersaveexp = PlayerPrefs.GetInt("SHOWEREXP");
        gamesaveexp = PlayerPrefs.GetInt("GAMEEXP");
        gamesaveexp2 = PlayerPrefs.GetInt("GAMEEXP2");


        mainexp = foodsaveexp + showersaveexp + gamesaveexp + gamesaveexp2;

        PlayerPrefs.SetInt("MAINEXP", mainexp);

        if(allfoodnum > 99)
        {
            allfoodnum = 99;
        }

        PoopGameManagerFood = PlayerPrefs.GetInt("FOODSCENEMANAGER");
        allfoodnum = PoopGameManagerFood;
        foodNumLabel.GetComponent<UILabel>().text = allfoodnum.ToString();
        PlayerPrefs.SetInt("FOODSCENEGAMEMANAGER", allfoodnum);

        stuffNum -= Time.deltaTime * 0.025f;
        cleanNum -= Time.deltaTime * 0.010f;
        happyNum -= Time.deltaTime * 0.010f;

        PlayerPrefs.SetFloat("STUFFNUM", stuffNum );
        PlayerPrefs.SetFloat("CLEANNUM", cleanNum );
        PlayerPrefs.SetFloat("HAPPYNUM", happyNum );


        if (happyNum >= 80)
        {
            happypicture.SetActive(true);
            normalpicture.SetActive(false);
            dirtypicture.SetActive(false);
        }
        else
        {
            normalpicture.SetActive(true);
            happypicture.SetActive(false);
            dirtypicture.SetActive(false);
        }
        if (happyNum >= 80 && cleanNum <= 50)
        {
            happypicture.SetActive(false);
            normalpicture.SetActive(false);
            dirtypicture.SetActive(true);
        }
        if(cleanNum > 50 && happyNum < 80)
        {
            dirtypicture.SetActive(false);
            happypicture.SetActive(false);
            normalpicture.SetActive(true);
        }
        if(cleanNum <= 50)
        {
            normalpicture.SetActive(false);
            happypicture.SetActive(false);
            dirtypicture.SetActive(true);
        }

        if(stuffNum >= 100)
        {
            stuffNum = 100;
        }
        if(cleanNum >= 100)
        {
            cleanNum = 100;
        }
        if(happyNum >= 100)
        {
            happyNum = 100;
        }


        if (stuffNum <= 0)
        {
            stuffNum = 0;
            stuff = true;
        }
        else
        {
            stuff = false;
        }

        if (cleanNum <= 0)
        {
            cleanNum = 0;
            clean = true;
        }
        else
        {
            clean = false;
        }

        if (happyNum <= 0)
        {
            happyNum = 0;
            happy = true;
        }
        else
        {
            happy = false;
        }

        if(stuff == true && happy == true || stuff == true && clean == true || happy == true && clean == true)
        {
            Invoke("GameOver", 30f);
        }


        float stuffMax = stuffNum * 0.01f;
        float cleanMax = cleanNum * 0.01f;
        float happyMax = happyNum * 0.01f;

        stuffbar.GetComponent<UIProgressBar>().value = stuffMax;
        cleanbar.GetComponent<UIProgressBar>().value = cleanMax;
        happybar.GetComponent<UIProgressBar>().value = happyMax;
    }

    void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Eatrice()
    {
        stuffNum += 20;
        foodexp = foodsaveexp + 50;
        PlayerPrefs.SetInt("FOODEXP", foodexp);
    }

    public void shower()
    {
        cleanNum += 20;
        showerexp = showersaveexp + 30;
        PlayerPrefs.SetInt("SHOWEREXP", showerexp);
    }

    public void minigame()
    {
        Application.LoadLevel(3);
    }
}
