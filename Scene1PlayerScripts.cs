using UnityEngine;
using System.Collections;

public class Scene1PlayerScripts : MonoBehaviour {

    public GameObject pitch;
    public GameObject lemon;
    public GameObject apple;
    public GameObject orange;

    public int exp;
    public int foodsaveExp;
    public int ShowersaveExp;
    public int gameExp;
    public int gameExp2;
    public int Maxexp;

    public int PlayerLevel;

    public int rebornNumber;

    public int ItemNumber;
    public int ItemMaxNumber;

    public int FruitNumber;
    public int FruitNumber2;




	// Use this for initialization
	void Start ()
    {
        Maxexp = 5000;
        ItemNumber = 0;
        FruitNumber = 0;
        FruitNumber = FruitNumber2;
    }
	
	// Update is called once per frame
	void Update ()
    {

        //PlayerPrefs.DeleteAll();
        exp = PlayerPrefs.GetInt("MAINEXP");
        foodsaveExp = PlayerPrefs.GetInt("FOODEXP");
        ShowersaveExp = PlayerPrefs.GetInt("SHOWEREXP");
        gameExp = PlayerPrefs.GetInt("GAMEEXP");
        rebornNumber = PlayerPrefs.GetInt("REBORN");


        if (exp <= 599 && exp >= 0)
        {
            PlayerLevel = 0;
        }
        if(exp <= 1299 && exp >= 600)
        {
            PlayerLevel = 1;
        }
        if(exp <= 2299 && exp >= 1300)
        {
            PlayerLevel = 2;
        }
        if(exp <= 3999 && exp >= 2300)
        {
            PlayerLevel = 3;
        }
        if(exp >= 4000 )
        {
            PlayerLevel = 4;
        }
        if(exp >= 5000)
        {
            foodsaveExp = 0;
            ShowersaveExp = 0;
            gameExp = 0;
            gameExp2 = 0;
            PlayerPrefs.SetInt("FOODEXP", foodsaveExp);
            PlayerPrefs.SetInt("SHOWEREXP", ShowersaveExp);
            PlayerPrefs.SetInt("GAMEEXP", gameExp);
            PlayerPrefs.SetInt("GAMEEXP2", gameExp2);
            rebornNumber += 1;
            PlayerPrefs.SetInt("REBORN", rebornNumber);
            PlayerLevel = 0;
            exp = 0;
            FruitNumber = Random.Range(0, 5);
        }
        switch (PlayerLevel)
        {
            case 0:
                ItemMaxNumber = 3;
                break;
            case 1:
                ItemMaxNumber = 6;
                break;
            case 2:
                ItemMaxNumber = 9;
                break;
            case 3:
                ItemMaxNumber = 12;
                break;
            case 4:
                ItemMaxNumber = 15;
                break;
        }
        /*switch (FruitNumber)
        {
            case 0:
                pitch.SetActive(true);
                lemon.SetActive(false);
                apple.SetActive(false);
                orange.SetActive(false);
                break;
            case 1:
                pitch.SetActive(false);
                lemon.SetActive(true);
                apple.SetActive(false);
                orange.SetActive(false);
                break;
            case 2:
                pitch.SetActive(false);
                lemon.SetActive(false);
                apple.SetActive(true);
                orange.SetActive(false);
                break;
            case 3:
                pitch.SetActive(false);
                lemon.SetActive(false);
                apple.SetActive(false);
                orange.SetActive(true);
                break;
        }*/
	}
}
