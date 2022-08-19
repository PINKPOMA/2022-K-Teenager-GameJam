using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainScript : MonoBehaviour
{
    public enum Characteristic
    {
        Marksmanship, // 사격술
        Strong, //근력
        Sharpness, //민첩함    
        Intuition, //생존본능
        Meteorology, //기상학 v
        Navigational, //항해력 v
        Cooking, //요리력
        Commanding, //통솔력 v
    }
    
    public enum Item
    {
        Match, //성냥
        Gun, //총
        Dog, //개  
        Jumper, // 방한복
        Medicine, //약
        Gold, //금화
        Compass, // 나침반
    }
    
    [SerializeField] private int hp;
    [SerializeField] private int mental;

    private bool[] characteristicArray = new []{false, false, false, false, false, false, false, false};
    private bool[] itemArray = new []{false, false, false, false, false, false, false};
    [SerializeField] private Text storyTeller;
    [SerializeField] private Text title;
    [SerializeField] private Text statusText;
    private string storyScript;
    private string profile;
    [SerializeField]private int mainStoryCount;
    [SerializeField]private int mainStoryProgress;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject prologueButton1;
    [SerializeField] private GameObject prologueButton2;
    [SerializeField] private GameObject eventButton;
    [SerializeField] private GameObject retryButton;


    private void Start()
    {
        hp = 3;
        mental = 3;
        mainStoryCount = 0;
       // statusText.text = $"h: {hp} m: {mental}";
    }

    public void Prologue()
    {
        //statusText.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        startButton.SetActive(false);
        storyTeller.gameObject.SetActive(true);
        storyScript =
            "1872년 7월 16일, 당신은 어느 마을의 오두막에서 태어났습니다. " +
            "15살 시절 우연히 탐험 보고서를 얻은 후 읽으며 탐험가의 매력에 빠져 꿈을 키우기 시작했던 당신은 어느새 훌쩍 자라 첫 탐험으로 남극으로 떠났었죠." +
            " 펭귄과 바다표범을 먹은 적도 있었지만, 그건 중요하지 않을겁니다" +
            " 그 후 선장 면허를 취득한 당신은 자기학을 공부하고, 기상학 관련 지식을 배우며 누구와도 비교할 수 없는 만능 선장의 길을 걷게 되었습니다." +
            " 이후 북서항로도 정복한 당신은 남극점을 탐험하기 위하여 ‘프람 호’와 함께 여정을 준비하고 있네요.";
        StartCoroutine("TypingStory", storyScript);
        prologueButton1.SetActive(true);
    }

    public void Prologue1()
    {
        prologueButton1.SetActive(false);
        storyScript =
            "당신은 남극점을 정복하기 위한 모험을 떠나게 됩니다. " +
            "당신의 앞에는 위험이 도사릴지도 모르죠. 하지만, 그런 위험조차 당신의 압도적인 ‘이 능력’ 덕분에 헤쳐나갈 수 있겠죠!";
        StartCoroutine("TypingStory", storyScript);
        
        prologueButton2.SetActive(true);
    }

    public void Prologue2()
    {
        prologueButton2.SetActive(false);
        int characteristicRandomNum = Random.Range(0, 3);
        switch (characteristicRandomNum)
        {
            case 0:
                GetCharacteristic1();
                break;
            case 1:
                GetCharacteristic2();
                break;
            case 3:
                GetCharacteristic3();
                break;
        }
    }

    public void GetCharacteristic1()
    {
        storyScript =
            "당신은 어려서부터 호기심이 많았습니다 그것도 날씨에 관해서요!\n" +
            "아마 남극에서 당신을 뛰어넘을 기상학자는 없을겁니다";
        StartCoroutine("TypingStory", storyScript);
        Debug.Log((int)Characteristic.Meteorology);
        characteristicArray[(int)Characteristic.Meteorology] = true;
        eventButton.SetActive(true);
    }
    public void GetCharacteristic2()
    {
        storyScript =
            "당신은 남극의 중심을 보기위해 정말 많은 노력을 해왔지만 그중에서도 항해실력은 으뜸이었습니다.\n" +
            "당신의 항해 실력이면 남극까진 무사히 도착할것 같군요.";
        StartCoroutine("TypingStory", storyScript);
        Debug.Log((int)Characteristic.Navigational);
        characteristicArray[(int)Characteristic.Navigational] = true;
        eventButton.SetActive(true);
    }
    public void GetCharacteristic3()
    {
        storyScript =
            "당신은 동네에서 놀때에도 모두를 한데 뭉치는데 능숙했죠.\n" +
            "여렸을때부터 갈고닦아온 통솔력의 힘을 보여줄때가 왔습니다!";
        StartCoroutine("TypingStory", storyScript);
        Debug.Log((int)Characteristic.Commanding);
        characteristicArray[(int)Characteristic.Commanding] = true;
        eventButton.SetActive(true);
    }

    public void EventButton()
    {
        mainStoryCount += 1;
        if (hp <= 0)
            HpEnding();
        else if (mental <= 0)
            MentalEnding();
        else if (mainStoryCount > 5 && 1 == Random.Range(0,2))
        {
            switch (mainStoryProgress)
            {
                case 0:
                    MainStory1();
                    break;
                case 1:
                    MainStory2();
                    break;
                case 2:
                    MainStory3();
                    break;
                case 3:
                    MainStory4();
                    break;
                case 4:
                    MainStory5();
                    break;
            }
        }
        else
        {
            int randomNumber = Random.Range(0, 20);

            switch (randomNumber)
            {
                case 0:
                    SubStory1();
                    break;
                case 1:
                    SubStory2();
                    break;
                case 2:
                    SubStory3();
                    break;
                case 3:
                    SubStory4();
                    break;
                case 4:
                    SubStory5();
                    break;
                case 5:
                    SubStory6();
                    break;
                case 6:
                    SubStory7();
                    break;
                case 7:
                    SubStory8();
                    break;
                case 8:
                    SubStory9();
                    break;
                case 9:
                    SubStory10();
                    break;
                case 10:
                    SubStory11();
                    break;
                case 11:
                    SubStory12();
                    break;
                case 12:
                    SubStory13();
                    break;
                case 13:
                    SubStory14();
                    break;
                case 14:
                    SubStory15();
                    break;
                case 15:
                    SubStory16();
                    break;
                case 16:
                    SubStory17();
                    break;
                case 17:
                    SubStory18();
                    break;
                case 18:
                    SubStory19();
                    break;
                case 19:
                    SubStory20();
                    break;
            }
        }
    }


    public void SubStory1()
    {
        
    }
    public void SubStory2()
    {
        
    }
    public void SubStory3()
    {
        
    }
    public void SubStory4()
    {
        
    }
    public void SubStory5()
    {
        
    }
    public void SubStory6()
    {
        
    }
    public void SubStory7()
    {
        
    }
    public void SubStory8()
    {
        
    }
    public void SubStory9()
    {
        
    }
    public void SubStory10()
    {
        
    }
    public void SubStory11()
    {
        
    }
    public void SubStory12()
    {
        
    }
    public void SubStory13()
    {
        
    }
    public void SubStory14()
    {
        
    }
    public void SubStory15()
    {
        
    }
    public void SubStory16()
    {
        
    }
    public void SubStory17()
    {
        
    }
    public void SubStory18()
    {
        
    }
    public void SubStory19()
    {
        
    }
    public void SubStory20()
    {
        
    }



    public void MainStory1()
    {
        storyScript =
            "메인 스토리 1 내용";
        StartCoroutine("TypingStory", storyScript);
        eventButton.SetActive(true);
    }
    
    public void MainStory2()
    {
        storyScript =
            "메인 스토리 2 내용";
        StartCoroutine("TypingStory", storyScript);
        eventButton.SetActive(true);
    }
    
    public void MainStory3()
    {
        storyScript =
            "메인 스토리 3 내용";
        StartCoroutine("TypingStory", storyScript);
        eventButton.SetActive(true);
    }
    
    public void MainStory4()
    {
        storyScript =
            "메인 스토리 4 내용";
        StartCoroutine("TypingStory", storyScript);
        eventButton.SetActive(true);
    }
    
    public void MainStory5()
    {
        storyScript =
            "아마 엔딩?";
        StartCoroutine("TypingStory", storyScript);
        retryButton.SetActive(true);
    }
    
    public void MentalEnding()
    {
        storyScript =
            "당신은 남극의 찬바람마저 극도로 두려워젔고 결국 다음을 기약하며 남극에서 떠납니다..";
        StartCoroutine("TypingStory", storyScript);
        retryButton.SetActive(true);
    }
    public void HpEnding()
    {
        storyScript =
            "당신은 차디찬 남극의 날씨를 견디기엔 역부족이었고 결국 다음을 기약하며 남극에서 떠납니다..";
        StartCoroutine("TypingStory", storyScript);
        retryButton.SetActive(true);
    }

    public void HappyEnding()
    {
        storyScript =
            "당신은 남극과의 사투 끝에 무사히 남극점을 찾았습니다 이제 남은일은 깃발을 꽂고 집으로 돌아가는것밖에 남지 않았군요..";
        StartCoroutine("TypingStory", storyScript);
        retryButton.SetActive(true); 
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator TypingStory( string story)
    {
        for (int i = 0; i < story.Length; i++)
        {
            if (Input.GetMouseButton(0))
            {
                storyTeller.text = story;
                break;
            }
            storyTeller.text = story.Substring(0, i + 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
