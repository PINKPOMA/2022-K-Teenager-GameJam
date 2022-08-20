using System;
using System.Collections;
using DG.Tweening;
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
        Meal, //밥
        Gun, //총
        Dog, //개  
        Jumper, // 방한복
        Medicine, //약
        Gold, //금화
        Compass, // 나침반
    }
    
    [SerializeField] private int hp;
    [SerializeField] private int mental;

    private bool[] characteristicArray = {false, false, false, false, false, false, false, false};
    private bool[] itemArray = {false, false, false, false, false, false, false};
    
    [SerializeField] private GameObject[] showHp;
    [SerializeField] private GameObject[] showMental;
    
    [SerializeField] private Text storyTeller;
    [SerializeField] private Text title;
    [SerializeField] private Text statusLogText;
    
    private string storyScript;
    private string profile;
    private string myInv;
    
    [SerializeField]private int mainStoryCount;
    [SerializeField]private int mainStoryProgress;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject prologueButton1;
    [SerializeField] private GameObject prologueButton2;
    [SerializeField] private GameObject eventButton;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject gearButton;
    
    [SerializeField] private GameObject subEvent1_1Button;
    [SerializeField] private GameObject subEvent1_2Button;
    [SerializeField] private GameObject subEvent2_1Button;
    [SerializeField] private GameObject subEvent2_2Button;
    [SerializeField] private GameObject subEvent3_1Button;
    [SerializeField] private GameObject subEvent3_2Button;
    [SerializeField] private GameObject subEvent4Button;
    [SerializeField] private GameObject subEvent5Button;
    [SerializeField] private GameObject subEvent6_1Button;
    [SerializeField] private GameObject subEvent6_2Button;
    [SerializeField] private GameObject subEvent7_1Button;
    [SerializeField] private GameObject subEvent7_2Button;
    [SerializeField] private GameObject subEvent9_1Button;
    [SerializeField] private GameObject subEvent9_2Button;
    [SerializeField] private GameObject subEvent10_1Button;
    [SerializeField] private GameObject subEvent10_2Button;
    
    [SerializeField] private GameObject mainEvent1_1Button;
    [SerializeField] private GameObject mainEvent1_2Button;
    [SerializeField] private GameObject mainEvent2_1Button;
    [SerializeField] private GameObject mainEvent2_2Button;
    [SerializeField] private GameObject mainEvent3_1Button;
    [SerializeField] private GameObject mainEvent3_2Button;
    private void Start()
    {
        hp = 3;
        mental = 3;
        mainStoryCount = 0;
    }

   
    public void Prologue()
    {
        for (int i = 0; i < 3; i++)
        {
            showHp[i].SetActive(true);
            showMental[i].SetActive(true);
        }
        title.gameObject.SetActive(false);
        startButton.SetActive(false);
        storyTeller.gameObject.SetActive(true);
        gearButton.SetActive(true);
        storyScript =
            "1872년 7월 16일, 당신은 어느 마을의 오두막에서 로얄 아문센 이라는 이름을 가지고 태어났습니다. " +
            "15살 시절 우연히 탐험 보고서를 얻은 후 읽으며 탐험가의 매력에 빠져 꿈을 키우기 시작했던 당신은 어느새 훌쩍 자라 첫 탐험으로 남극으로 떠났었죠." +
            " 펭귄과 바다표범을 먹은 적도 있었지만, 그건 중요하지 않을겁니다" +
            " 그 후 선장 면허를 취득한 당신은 자기학을 공부하고, 기상학 관련 지식을 배우며 누구와도 비교할 수 없는 만능 선장의 길을 걷게 되었습니다." +
            " 이후 북서항로도 정복한 당신은 남극점을 탐험하기 위하여 ‘프람 호’와 함께 여정을 준비하고 있네요.";
        StartCoroutine("TypingStory", storyScript);
        prologueButton1.SetActive(true);
    }

    public void Prologue1()
    {
        storyScript =
            "당신은 남극점을 정복하기 위한 모험을 떠나게 됩니다. " +
            "당신의 앞에는 위험이 도사릴지도 모르죠. 하지만, 그런 위험조차 당신의 압도적인 ‘이 능력’ 덕분에 헤쳐나갈 수 있겠죠!";
        StartCoroutine("TypingStory", storyScript);
        
        prologueButton2.SetActive(true);
        prologueButton1.SetActive(false);
    }

    public void Prologue2()
    {
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

    public void gearOpen()
    {
        
    }
    public void GetCharacteristic1()
    {
        storyScript =
            "당신은 어릴적부터 기상학을 열심히 공부했었죠. 뵈르겐 교수님과 슈… 뭔 교수님한테 " +
            "수업을 들었다는 것만 알아두세요. 그만큼 당신이 똑똑하다는겁니다.";
        StartCoroutine("TypingStory", storyScript);
        characteristicArray[(int)Characteristic.Meteorology] = true;
        statusLogText.color = Color.green;
        statusLogText.text = "기상학";
        StopCoroutine("StatusFade");
        StartCoroutine("StatusFade");
        eventButton.SetActive(true);
        prologueButton2.SetActive(false);
    }
    public void GetCharacteristic2()
    {
        storyScript =
            "어릴적부터 뭔가를 세부적으로 잘 파악하던 당신은 이 뛰어난 분석력을 바탕으로 여러가지 공부를 해냈죠. " +
            "일행의 그 누구보다도 뛰어나다고 자부할 만큼 실력이 어마어마합니다.";
        StartCoroutine("TypingStory", storyScript);
        characteristicArray[(int)Characteristic.Navigational] = true;
        statusLogText.color = Color.green;
        statusLogText.text = "분석력";
        StopCoroutine("StatusFade");
        StartCoroutine("StatusFade");
        eventButton.SetActive(true);
        prologueButton2.SetActive(false);
    }
    public void GetCharacteristic3()
    {
        storyScript =
            "역시 사람들을 움직이는데에는 당신이 가장 적합하죠! 당신의 지휘력에 중국이 놀라고 일본이 경악했을지도 모릅니다. 정말 멋진 지휘실력이에요.";
        StartCoroutine("TypingStory", storyScript);
        characteristicArray[(int)Characteristic.Commanding] = true;
        statusLogText.color = Color.green;
        statusLogText.text = "통솔력";
        StopCoroutine("StatusFade");
        StartCoroutine("StatusFade");
        eventButton.SetActive(true);
        prologueButton2.SetActive(false);
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
            }
        }
        else
        {
            int randomNumber = Random.Range(0, 10);

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
                
            }
        }
        eventButton.SetActive(false);
    }


    public void SubStory1()
    {
        storyScript = "지금까지 촬영했던 사진과 영상의 필름들을 모두 잃어버린 것 같습니다. 찾고 싶은 마음은 굴뚝같지만, 곧 눈보라가 강하게 칠 것 같은데 찾을 수 있을까요?";
        StartCoroutine("TypingStory", storyScript);
        subEvent1_1Button.SetActive(true);
        if(characteristicArray[(int)Characteristic.Sharpness])
            subEvent1_2Button.SetActive(true);
    }

    public void SubEvent1_1Button()
    {
        storyScript = "눈 속에 파묻힌 필름을 다행히 찾아냈지만, 뒤늦게 오는 눈보라가 당신을 품습니다. " +
                      "운 좋게 빠져나오긴 했지만, 기진맥진한 상태가 되어버렸네요.";
        StartCoroutine("TypingStory", storyScript);
        mental -= 1;
        if (mental < 0)
            mental = 0;
        statusLogText.color = Color.red;
        statusLogText.text = "멘탈";
        MentalChanger();
        StartCoroutine("StatusFade");
        subEvent1_1Button.SetActive(false);
        subEvent1_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent1_2Button()
    {
        storyScript = "당신의 뛰어난 움직임으로 방금까지 걸어왔던 길을 신속하게 탐색했습니다." +
                      " 혹시 눈에 파묻히지는 않았을까, 가방에 있는데 못찾은 건 아닌가 하며 찾던 도중." +
                      " 발에 걸리는 무언가를 보니 필름이었습니다. 휴, 빨리 일행에게 복귀하여 한숨 돌려야겠네요.";
        StartCoroutine("TypingStory", storyScript);
        subEvent1_1Button.SetActive(false);
        subEvent1_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory2()
    {
        storyScript = "\"아니, 대장! 지금 사람이 이렇게 죽어가는데…\" 당신의 뒤에서 부 지휘관이 당신에게 외칩니다. " +
                      "왜인지 보니 이번 전진에서 쇠약하고 힘들어하는 동료들을 전 베이스캠프에 버리고 왔기 때문인 것 같습니다. " +
                      "하지만, 지휘관으로써의 판단은 옳았죠. 아파하는 동료를 사지에 몰아넣을 수는 없으니까요. " +
                      "당신은 갸우뚱하며 부 지휘관에게 말을 건넵니다. \"정말, 내 판단이 틀린 것 같은가?\" " +
                      "부 지휘관은 부들부들 떨며 억지로 화를 참는 듯 해보였습니다.";
        StartCoroutine("TypingStory", storyScript);
        subEvent2_1Button.SetActive(true);
        if(characteristicArray[(int)Characteristic.Commanding])
            subEvent2_2Button.SetActive(true);
    }
    public void SubEvent2_1Button()
    {
        storyScript = "애써 당신은 화를 삭혀보지만 분에 이기지 못해 벽을 강하게 때립니다.";
        StartCoroutine("TypingStory", storyScript);
        mental -= 1;
        if (mental < 0)
            mental = 0;
        statusLogText.color = Color.red;
        statusLogText.text = "멘탈";
        MentalChanger();
        StartCoroutine("StatusFade");
        subEvent2_1Button.SetActive(false);
        subEvent2_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent2_2Button()
    {
        storyScript = "\"아니, 무슨 소립니까?\" 당신의 부 지휘관이 소리칩니다. 이젠 아니겠지만요." +
                      " 당신은 그런 그를 묵묵히 무시하고 잘 따르는 팀원 몇 명을 뽑아 계속해서 모험을 떠날 채비를 합니다.";
        StartCoroutine("TypingStory", storyScript);
        subEvent2_1Button.SetActive(false);
        subEvent2_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    
    public void SubStory3()
    {
        storyScript = "당신은 여느때와 같이 정해진 길에 따라서 모험을 떠나고 있었습니다. " +
                      "하지만 동료의 품속에서 계속 시끄러운 소리가 나기에 그를 째려봅니다. " +
                      "\"아, 대장님. 그 강아지를 데리고 왔는데….\" 어이가 없었지만, 당신은 번뜩이는 아이디어가 떠올랐습니다!";
        StartCoroutine("TypingStory", storyScript);
        subEvent3_1Button.SetActive(true);
        subEvent3_2Button.SetActive(true);
    }
    public void SubEvent3_1Button()
    {
        storyScript = "\"한마리밖에 없는데요…?\" 하지만, 그건 중요하지 않았습니다. 뭐 어때요. 게임이면 한마리로 썰매좀 끌 수 있지 않겠어요?";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.green;
        statusLogText.text = "개";
        StartCoroutine("StatusFade");
        itemArray[(int)Item.Dog] = true;
        subEvent3_1Button.SetActive(false);
        subEvent3_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent3_2Button()
    {
        storyScript = "\"아니, 대장님 그건…\" 당신은 애써 시선을 피하는 대원을 무시하고 개를 잔혹하게 살인합니다. 아무리 게임이어도... ";
        StartCoroutine("TypingStory", storyScript);
        mental -= 1;
        hp += 1;
        if (hp > 3)
            hp = 3;
        if (mental < 0)
            mental = 0;
        MentalChanger();
        HpChanger();
        statusLogText.text = "<color=red>멘탈</color> <color=green>체력</color>";
        StartCoroutine("StatusFade");
        subEvent3_1Button.SetActive(false);
        subEvent3_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory4()
    {
        storyScript = "당신은 앞으로 나아가던중 발에 무언가 걸려 넘어집니다.. 홧김에 발로 차려는 찰나에 가방이라는것을 눈치챕니다!";
        StartCoroutine("TypingStory", storyScript);
        subEvent4Button.SetActive(true);
    }
    public void SubEvent4Button()
    {
        switch (Random.Range(0,13))
        {
            case 0:
                storyScript = "당신은 가방 안에 있던 권총 한자루를 챙깁니다..";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "총";
                StartCoroutine("StatusFade");
                itemArray[(int)Item.Gun] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 1:
                storyScript = "당신은 가방안에 있던 약간의 금화를 주머니에 넣습니다..";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "금화";
                StartCoroutine("StatusFade");
                itemArray[(int)Item.Gold] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 2:
                storyScript = "당신은 가방에 붙어있던 나침반을 떼서 가져갑니다..";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "나침반";
                StartCoroutine("StatusFade");
                itemArray[(int)Item.Compass] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 3:
                storyScript = "당신은 가방 안에 있던 방한복을 챙겨갑니다..";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "방한복";
                StartCoroutine("StatusFade");
                itemArray[(int)Item.Jumper] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 4:
                storyScript = "당신은 가방 안에 상비약이 있는걸 보곤 냉큼 집어갑니다..";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "약";
                StartCoroutine("StatusFade");
                itemArray[(int)Item.Medicine] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 5:
                storyScript = "당신은 가방 안에 있던 '사냥의 시간'이라는 책을 집어갑니다.. 권총을 다루는법이 꽤 능숙해지는 느낌을 받았습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "사격술";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Marksmanship] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 6:
                storyScript = "당신은 가방 안에 있던 '근육은 힘이다!'라는 책을 집어갑니다.. 근육에 오는 자극이 꽤 맛있다는걸 느껴지기 시작했습니다  ";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "근력";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Strong] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 7:
                storyScript = "당신은 가방 안에 있던 '표범은 왜 빠를까?'라는 책을 집어갑니다.. 표범처럼 빠르게 움직이는 방법을 깨우쳤습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "민첩함";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Sharpness] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 8:
                storyScript = "당신은 가방 안에 있던 '나를 위협하는 모든것'이라는 책을 집어갑니다.. 생명의 위협에 더 빠르게 대처할 수 있을것 같은 느낌을 받았습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "생존본능";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Intuition] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 9:
                storyScript = "당신은 가방 안에 있던 '하늘은 모든걸 알고있다'라는 책을 집어갑니다.. 날씨에 대한 이해도가 높아짐을 느꼈습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "기상학";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Meteorology] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 10:
                storyScript = "당신은 가방 안에 있던 '명탐정김정일'이라는 책을 집어갑니다.. 모든 진실을 알 수 있을것만 같은 느낌을 받았습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "분석력";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Navigational] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 11:
                storyScript = "당신은 가방 안에 있던 '계란 맛깔나게 삶는법'이라는 책을 집어갑니다.. 당신은 자신의 요리에 자신감이 생겼습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "요리력";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Cooking] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
            case 12:
                storyScript = "당신은 가방 안에 있던 '훌륭한 지휘자가 되는법'이라는 책을 집어갑니다.. 당신은 이제 주변 사람들을 통솔함에 도가 텃습니다";
                StartCoroutine("TypingStory", storyScript);
                statusLogText.color = Color.green;
                statusLogText.text = "통솔력";
                StartCoroutine("StatusFade");
                characteristicArray[(int)Characteristic.Commanding] = true;
                subEvent4Button.SetActive(false);
                eventButton.SetActive(true);
                break;
        }
    }
    public void SubStory5()
    {
        storyScript = "어느새 저녁이 되어 야영을 해야할 것 같습니다. 잠깐 하늘을 보니 아름다운 오로라가 펼쳐져 있네요. " +
                      "힘든 여정으로 인해서 지친 당신의 몸과 마음이 치유되는 기분을 느낍니다.";
        StartCoroutine("TypingStory", storyScript);
        subEvent5Button.SetActive(true);
    }

    public void SubEvent5Button()
    {
        storyScript = "당신은 부풀어오른 마음을 잠깐 접어두고 휴식을 취하기 위해서 숙면에 듭니다.";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.green;
        statusLogText.text = "멘탈";
        StartCoroutine("StatusFade");
        mental += 1;
        if (mental > 3)
            mental = 3;
        MentalChanger();
        subEvent5Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory6()
    {
        storyScript = "당신의 동료가 길을 가던중 고열로 쓰러졌습니다.";
        StartCoroutine("TypingStory", storyScript);
        subEvent6_1Button.SetActive(true);
        if (itemArray[(int)Item.Medicine])
        {
            subEvent6_2Button.SetActive(true);
        }
    }
    public void SubEvent6_1Button()
    {
        storyScript = "당신은 어쩔줄 몰라하며 간호하지만 그를 완치하기엔 역부족이었습니다..";
        StartCoroutine("TypingStory", storyScript);
        subEvent6_1Button.SetActive(false);
        subEvent6_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent6_2Button()
    {   
        storyScript = "당신이 가방에 남아있던 약을 먹이자 동료의 안색이 좋아졌습니다..";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.red;
        statusLogText.text = "약";
        itemArray[(int)Item.Medicine] = false;
        StartCoroutine("StatusFade");
        subEvent6_1Button.SetActive(false);
        subEvent6_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory7()
    {
        storyScript = "당신과 대원들은 잠깐 휴식을 하며, 무료함을 달래기 위해서 무언가를 찾고 있습니다. 괜찮은 물건이 없을까요?";
        StartCoroutine("TypingStory", storyScript);
        subEvent7_1Button.SetActive(true);
        if (itemArray[(int)Item.Gold])
        {
            subEvent7_2Button.SetActive(true);
        }
        
    }
    public void SubEvent7_1Button()
    {
        storyScript = "심심하던 당신과 대원들은 농담이라도 따먹기로 했습니다. \"왕이 넘어지면?\" \"킹콩!\" 하하. 재미있던 것 같습니다. 아마도요.";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.green;
        statusLogText.text = "멘탈";
        StartCoroutine("StatusFade");
        mental += 1;
        if (mental > 3)
            mental = 3;
        MentalChanger();
        subEvent7_1Button.SetActive(false);
        subEvent7_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent7_2Button()
    {   
        storyScript = "돈 내기는 불건전하지만, 다 큰 성인들이 잠깐 하는데 뭐 어떤가요. " +
                      "당신은 돈 내기를 다시는 하지 않겠다고 다짐하는 계기가 되었지만, 재미 있었으니 됐다며 휴식을 끝마쳤습니다.";
        StartCoroutine("TypingStory", storyScript);
        itemArray[(int)Item.Gold] = false;
        statusLogText.text = "<color=red>금화</color> <color=green>멘탈</color>";
        StartCoroutine("StatusFade");
        mental += 1;
        if (mental > 3)
            mental = 3;
        MentalChanger();
        
        subEvent7_1Button.SetActive(false);
        subEvent7_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory8()
    {
        storyScript = "오랜만에 콩 통조림을 따듯하게 뎁혀서 먹었습니다. 속까지 뜨끈해 지는게 포만감도 들고 마음도 편안하게 만들었습니다..";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.green;
        statusLogText.text = "체력 멘탈";
        StartCoroutine("StatusFade");
        hp += 1;
        mental += 1;
        if (hp > 3)
            hp = 3;
        if (mental > 3)
            mental = 3;
        HpChanger();
        MentalChanger();
        eventButton.SetActive(true);
    }
    public void SubStory9()
    {
        storyScript = "여느때와 같이 정해진 시간에 밥을 먹기 위해 통조림을 개봉하고 있었습니다. 어라, 근데 잘 열리지 않는군요."; 
        StartCoroutine("TypingStory", storyScript);
        subEvent9_1Button.SetActive(true);
        if(characteristicArray[(int)Characteristic.Strong])
         subEvent9_2Button.SetActive(true);
    }

    public  void SubEvent9_1Button()
    {
        storyScript = "당신은 무리해서 뚜껑을 열려고 시도하다 뚜껑에 손이 베였습니다. 아아, 아파라…"; 
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.red;
        statusLogText.text = "체력";
        StartCoroutine("StatusFade");
        hp -= 1;
        if (hp < 0)
            hp = 0;
        HpChanger();
        subEvent9_1Button.SetActive(false);
        subEvent9_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubEvent9_2Button()
    {
        storyScript = "당신은 힘 자랑을 하는 듯 무식하게 뚜껑을 뜯어내고 통조림을 허겁지겁 먹기 시작합니다. 조금은 남성성이 강해진 것 같네요."; 
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.green;
        statusLogText.text = "체력";
        StartCoroutine("StatusFade");
        hp += 1;
        HpChanger();
        subEvent9_1Button.SetActive(false);
        subEvent9_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory10()
    {
        storyScript = "귀여운 펭귄들이 잔뜩 모여있습니다! 어라, 근데 어째서인지 당신에게 펭귄 한마리가 뭔가를 열심히 밀면서 다가옵니다. " +
                      "가까이 가서 확인해볼까요?"; 
        StartCoroutine("TypingStory", storyScript);
        subEvent10_1Button.SetActive(true);
        subEvent10_2Button.SetActive(true);
    }

    public void SubEvent10_1Button()
    {
        if (Random.Range(0, 2) == 0)
            SubStory11();
        else
            SubStory12();
        subEvent10_1Button.SetActive(false);
        subEvent10_2Button.SetActive(false);
    }
    public void SubEvent10_2Button()
    {
        storyScript = "당신은 가던 길을 계속 가기로 합니다.";
        StartCoroutine("TypingStory", storyScript);
        subEvent10_1Button.SetActive(false);
        subEvent10_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void SubStory11()
    {
        storyScript = "펭귄이 당신에게 선물을 줬군요! 어디에 쓰는건지는… 자세히 살펴보도록 해야할 것 같네요.";
        StartCoroutine("TypingStory", storyScript);
        itemArray[(int)Item.Jumper] = true;
        itemArray[(int)Item.Medicine] = true;
        itemArray[(int)Item.Gold] = true;
        statusLogText.color=Color.green;
        statusLogText.text = "방한복 약 금화";
        StartCoroutine("StatusFade");
        eventButton.SetActive(true);
    }
    public void SubStory12()
    {
        storyScript = "펭귄 무리들이 당신이 아기 펭귄을 위협하려는 줄 알고 공격합니다. " +
                      "당신은 급하게 도망치지만 슬라이딩을 하며 오는 펭귄에게 다리가 걸려져 넘어졌습니다." +
                      " 어찌저찌 빠져나왔지만, 다리가 마음대로 움직이지는 않네요.";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.red;
        statusLogText.text = "체력";
        StartCoroutine("StatusFade");
        hp -= 1;
        if (hp < 0)
            hp = 0;
        HpChanger();
        eventButton.SetActive(true);
    }
    public void SubStory13()
    {
        
    }




    public void MainStory1()
    {
        storyScript =
            "길을 잃은 것 같습니다.. 어디로 가야할지 모르겠지만 이렇게 앞이 아무것도 안보이는 상황에서는 어디로 가야 올바른 길로 갈 수 있을까요?";
        StartCoroutine("TypingStory", storyScript);
        mainEvent1_1Button.SetActive(true);
        if (characteristicArray[(int)Characteristic.Navigational])
            mainEvent1_2Button.SetActive(true);
        mainStoryCount = 0;
        mainStoryProgress += 1;
    }
    public void MainEvent1_1Button()
    {
        storyScript =
            "어쩌겠나요. 일단 들이박고 봐야죠. 조금은 힘들게 원래 동선으로 복귀합니다.";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.red;
        statusLogText.text = "체력";
        hp -= 1;
        if (hp < 0)
            hp = 0;
        HpChanger();
        StartCoroutine("StatusFade");
        mainEvent1_1Button.SetActive(false);
        mainEvent1_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void MainEvent1_2Button()
    {
        storyScript =
            "당신의 뛰어난 분석력으로 다행히 안전하게 원래 동선으로 복귀하였습니다. 역시 든든한 이시대의 리더라고 할 수 있을 것 같네요.";
        StartCoroutine("TypingStory", storyScript);
        mainEvent1_1Button.SetActive(false);
        mainEvent1_2Button.SetActive(false);
    }

    public void MainStory2()
    {
        storyScript =
            "…안타까운 소식입니다. 당신보다 누군가가 남극점을 먼저 도착한 것 같습니다. 자신에게 계속 이 모험을 떠나는게 맞는지 묻습니다.";
        StartCoroutine("TypingStory", storyScript);
        eventButton.SetActive(true);
        mainEvent2_1Button.SetActive(true);
        if (characteristicArray[(int)Characteristic.Navigational])
            mainEvent2_2Button.SetActive(true);
    }

    public void MainEvent2_1Button()
    {
        storyScript =
            "당신은 애써 무시하지만 그 소식이 자신의 꿈을 짓밟았다는 것을 부정할 수 없었습니다.";
        StartCoroutine("TypingStory", storyScript);
        statusLogText.color = Color.red;
        statusLogText.text = "멘탈";
        mental -= 1;
        if (mental < 0)
            mental = 0;
        MentalChanger();
        StartCoroutine("StatusFade");
        mainEvent2_1Button.SetActive(false);
        mainEvent2_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void MainEvent2_2Button()
    {
        storyScript =
            "당신은 근거있는 이유를 들며, 자신보다 빨리 도착했을리 없다고 생각합니다. 공부를 한게 확실히 도움이 되네요.";
        StartCoroutine("TypingStory", storyScript);
        mainEvent2_1Button.SetActive(false);
        mainEvent2_2Button.SetActive(false);
        eventButton.SetActive(true);
    }
    public void MainStory3()
    {
        storyScript =
            "큰일났습니다! 급격한 눈보라가 치기 시작했습니다. 여기서 더 전진했다간 위험해질 수도 있을 것 같은데, 모험을 잠깐 쉬어가야 할지도 모르겠습니다.";
        StartCoroutine("TypingStory", storyScript);
        mainEvent3_1Button.SetActive(true);
        mainEvent3_2Button.SetActive(true);
    }

    public void MainEvent3_1Button()
    {
        HappyEnding();
    }
    public void MainEvent3_2Button()
    {
        storyScript =
            "당신은 애써 눈보라를 피해 기지에 귀환하였지만, 안타깝게도 4개월이 넘도록 눈보라는 그치지 않았습니다." +
            " 이러한 눈보라로 인해 식량 조달도 하지 못하고, 대원들도 많이 지쳤기에 노르웨이로 복귀하기로 결정하였습니다. 이번 여정의 끝은 여기까지네요.";
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
            "당신은 남극의 매서운 눈보라를 돌파하자고 했습니다." +
            " 팀원들은 무모하다고 했지만, 언제까지나 허황된 꿈이라며 무시하는 사람들에게 질타받고 싶지 않았기에 돌파하자고 합니다. " +
            "무모하다면 어떻습니까, 당신은 지금껏 한번도 인간의 손길이 닿지 않은 최초의 땅으로 발을 딛기 시작했습니다.";
        StartCoroutine("TypingStory", storyScript);
        retryButton.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void HpChanger()
    {
        switch (hp)
        {
            case 0:
                showHp[0].SetActive(false);
                showHp[1].SetActive(false);
                showHp[2].SetActive(false);
                break;
            case 1:
                showHp[0].SetActive(true);
                showHp[1].SetActive(false);
                showHp[2].SetActive(false);
                break;
            case 2:
                showHp[0].SetActive(true);
                showHp[1].SetActive(true);
                showHp[2].SetActive(false);
                break;
            case 3:
                showHp[0].SetActive(true);
                showHp[1].SetActive(true);
                showHp[2].SetActive(true);
                break;
        }
    }
    public void MentalChanger()
    {
        switch (mental)
        {
            case 0:
                showMental[0].SetActive(false);
                showMental[1].SetActive(false);
                showMental[2].SetActive(false);
                break;
            case 1:
                showMental[0].SetActive(true);
                showMental[1].SetActive(false);
                showMental[2].SetActive(false);
                break;
            case 2:
                showMental[0].SetActive(true);
                showMental[1].SetActive(true);
                showMental[2].SetActive(false);
                break;
            case 3:
                showMental[0].SetActive(true);
                showMental[1].SetActive(true);
                showMental[2].SetActive(true);
                break;
        }
    }

    IEnumerator StatusFade()
    {
        statusLogText.DOFade(1.0f, 1f);
        yield return new WaitForSeconds(1f);
        statusLogText.DOFade(0f, 1f);
        
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
