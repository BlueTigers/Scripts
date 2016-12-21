using UnityEngine;
using System.Collections;

public class PoopGameManager : MonoBehaviour {

    public GameObject player; // 플레이어
    public GameObject GameOver; // 게임오버
    public GameObject enemyRespawn; // 적의 리스폰
    public GameObject HomeBtn; // Home 버튼

    public float stuffnum; // 포만감 게이지 값
    public float cleannum; // 청결 게이지 값
    public float happynum; // 행복 게이지 값
    public float genTime; // 젠타임 <- 일정 시간 지나면 경험치랑 행복도를 증가시키는 역할
    public float coolTime; // 쿨타임
    
    public int foodnumManager; // 자기가 먹은 음식의 갯수
    public int plusexp; // 이 게임에서 더해진 경험치 값
    public int reverseexp; // 몰라
    public int scene1FoodManager; // 씬 1에 저장되어있는 음식의 갯수
    public int FoodManager; // 씬1에 저장되어있는 음식 + 자기가 게임에서 먹은 음식의 갯수
    public int scene1nowFoodnum; // 현재 있는 음식

    public bool PlayerDead; // 플레이어가 죽었을 때 감지하는 불 값

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player"); // 플레이어를 찾아줘서 대입
        enemyRespawn = GameObject.Find("EnemyRespawn"); // 적의 리스폰을 찾아줘서 대입
        plusexp = PlayerPrefs.GetInt("GAMEEXP"); // plusexp 에 ㅍㅍ에 저장되어있는 "GAMEEXP" 를 불러온다.

        genTime = 5f; // 젠타임을 5로 설정해준다.

        stuffnum = PlayerPrefs.GetFloat("STUFFNUM"); // stuffnum 에 ㅍㅍ에 저장되어있는 "STUFFNUM" 를 불러온다.
        cleannum = PlayerPrefs.GetFloat("CLEANNUM"); // cleannum 에 ㅍㅍ에 저장되어있는 "CLEANNUM" 를 불러온다.
        happynum = PlayerPrefs.GetFloat("HAPPYNUM"); // happynum 에 ㅍㅍ에 저장되어있는 "HAPPYNUM" 를 불러온다.
        reverseexp = PlayerPrefs.GetInt("MAINEXP"); // reverseexp 에 ㅍㅍ에 저장되어있는 "MAINEXP" 를 불러온다.
	}
	
	// Update is called once per frame
	void Update ()
    {

        stuffnum -= Time.deltaTime*0.025f; // stuffnum Time.deltaTime을 뺀다.
        cleannum -= Time.deltaTime*0.010f; // cleannum Time.deltaTime을 뺀다.
        happynum -= Time.deltaTime*0.010f; // happynum Time.deltaTime을 뺀다.

        if (happynum >= 100) // 만약 happynum이 100보다 커지면
        {
            happynum = 100; // happynum을 100으로 바꿔준다.
        }

        PlayerPrefs.SetFloat("STUFFNUM",stuffnum); // stuffnum을 "STUFFNUM"에 ㅍㅍ 저장
        PlayerPrefs.SetFloat("CLEANNUM",cleannum); // cleannum을 "CLEANNUM"에 ㅍㅍ 저장
        PlayerPrefs.SetFloat("HAPPYNUM",happynum); // happynum을 "HAPPYNUM"에 ㅍㅍ 저장

        scene1nowFoodnum = PlayerPrefs.GetInt("FOODSCENEGAMEMANAGER"); // FOODSCENEGAMEMANAGER 를 불러와 scene1nowFoodnum에 대입
        foodnumManager = player.GetComponent<PlayerScripts>().foodNum; //푸드넘매니저는 player에 foodnum이다

	    if(player.GetComponent<PlayerScripts>().hp <= 0) // 만약 플레이어의 hp가 0보다 작거나같아질때
        {
            GameOver.SetActive(true); // 게임오버가 켜진다.
            player.SetActive(false); // 플레이어를 끈다.
            enemyRespawn.SetActive(false); // 적의 리스포너를 끈다.
            PlayerDead = true;
            if(GameOver.transform.localPosition.y <= 435) // 만약 게임오버의 로컬포지션의 y가 435보다 같거나작아질때
            {
                FoodManager = foodnumManager + scene1FoodManager + scene1nowFoodnum;//푸드넘매니저를 신1푸드매니저에 더해준다.
                HomeBtn.SetActive(true); // 홈버튼을 활성화시킨다.
                PlayerPrefs.SetInt("FOODSCENEMANAGER", FoodManager); // 플팹을 셋팅해준다.
                Debug.Log(FoodManager);
            }
        }
        if(PlayerDead == false)
        {
            genTime -= Time.deltaTime; // genTime에 Time.deltaTime을 뺀다.
            if (genTime < coolTime) // 젠타임이 쿨타임보다 작아질때
            {
                plusexp += 5; // plusexp를 5을 더해준다.
                happynum += 1; // happynum을 1을 더해준다.
                PlayerPrefs.SetInt("GAMEEXP", plusexp); // plusexp를 "GAMEEXP"에 ㅍㅍ 저장
                genTime = 5; // 젠타임을 5로 다시 설정해준다.
            }
        }
	}

    public void Home() // Home버튼을 누르면
    {
        Application.LoadLevel(1); // Scene 1으로 돌아간다.
    }
}
