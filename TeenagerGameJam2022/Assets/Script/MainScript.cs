using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public enum Characteristic
    {
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j,
        k,
        l,
        m,
        n,
        o,
        p
    }
    [SerializeField] private int hp;
    [SerializeField] private int fear;
    [SerializeField] private int hunger;

    private bool[] characteristicArray;
    [SerializeField] private Text storyTeller;
    [SerializeField] private Text title;
    private string storyScript;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject prologueButton1;
    [SerializeField] private GameObject prologueButton2;
    
    
    
    
    
    public void Prologue()
    {
        title.gameObject.SetActive(false);
        startButton.SetActive(false);
        storyTeller.gameObject.SetActive(true);
        storyScript =
            " 1872년 7월 16일, 당신 어느 마을의  오두막에서 태어났습니다. \n" +
            " 15살 시절 우연히 탐험 보고서를 얻은 후 읽으며 탐험가의 매력에 빠져 꿈을 키우기 시작했던 당신은 어느새 훌쩍 자라 첫 탐험으로 남극으로 떠났었죠. \n" +
            " 펭귄과 바다표범을 먹은 적도 있었지만, 그건 중요하지 않을겁니다 \n" +
            " 그 후 선장 면허를 취득한 당신은 자기학을 공부하고, 기상학 관련 지식을 배우며 누구와도 비교할 수 없는 만능 선장의 길을 걷게 되었습니다. \n" +
            " 이후 북서항로도 정복한 당신은 남극점을 탐험하기 위하여 ‘프람 호’와 함께 여정을 준비하고 있네요. ";
        StartCoroutine("TypingStory", storyScript);
        prologueButton1.SetActive(true);
    }

    public void Prologue1()
    {
        prologueButton1.SetActive(false);
        storyScript =
            " 당신은 남극점을 정복하기 위한 모험을 떠나게 됩니다. \n" +
            " 당신의 앞에는 위험이 도사릴지도 모르죠. 하지만, 그런 위험조차 당신의 압도적인 ‘이 능력’ 덕분에 헤쳐나갈 수 있겠죠! ";
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
        }
    }

    public void GetCharacteristic1()
    {
        
        storyScript =
            " 당신은 어려서부터 관찰력이 어쩌구 \n" +
            " 어쩌구 저쩌구를 얻고 당신을 길을 떠났습니다..";
        StartCoroutine("TypingStory", storyScript);
        
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
