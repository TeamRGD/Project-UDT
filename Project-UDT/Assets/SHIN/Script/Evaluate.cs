using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Evaluate : MonoBehaviour
{
    public GameObject topUI;
    public GameObject bottomUI;
    public GameObject returnBtn;
    public GameObject moneyInfo;

    public GameObject generating;
    public Text[] text;

    public TextMeshProUGUI arrow;

    private bool isFolded;
    // Start is called before the first frame update
    void Start()
    {
        isFolded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onComplete()
    {
        isFolded = false;
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "";
        }
        generating.SetActive(true);
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(50f, 0.75f).SetEase(Ease.OutQuart);
        bottomRect.DOAnchorPosY(-70f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(600f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(-35f, 0.75f).SetEase(Ease.OutQuart);
        text[0].DOText("<b><size=50>1. 애국가 1절</size></b>\r\n", 0.8f, true, ScrambleMode.None).SetDelay(7f).OnStart(() => generating.SetActive(false));
        text[1].DOText("동해물과 백두산이 마르고 닳도록 하느님이 보우하사 우리나라 만세 무궁화 삼천리 화려강산 대한사람 대한으로 길이 보전하세\n\r\n", 3f, true, ScrambleMode.None).SetDelay(7.8f);
        text[2].DOText("<b><size=50>1. 애국가 2절</size></b>\r\n", 1.2f, true, ScrambleMode.None).SetDelay(10.8f);
        text[3].DOText("남산 위의 저 소나무 철갑을 두른 듯 바람서리 불변함은 우리 기상일세 무궁화 삼천리 화려강산 대한사람 대한으로 길이 보전하세\n\r\n", 4f, true, ScrambleMode.None).SetDelay(12f).SetEase(Ease.OutQuart);
        text[4].DOText("<b><size=50>1. 애국가 3절</size></b>\n\r\n", 1f, true, ScrambleMode.None).SetDelay(17.2f);
        text[5].DOText("가을 하늘 공활한데 높고 구름없이 밝은 달은 우리 가슴 일편단심일세 무궁화 삼천리 화려강산 대한사람 대한으로 길이 보전하세", 4f, true, ScrambleMode.None).SetDelay(18.2f);   
    }

    public void returnComplete()
    {
        isFolded = true;
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(-50f, 0.75f).SetEase(Ease.OutQuart);
        bottomRect.DOAnchorPosY(140f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(-600f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(35f, 0.75f).SetEase(Ease.OutQuart);
    }

    public void doFold()
    {
        if (isFolded)
        {
            RectTransform topRect = topUI.GetComponent<RectTransform>();
            topRect.DOAnchorPosX(600f, 0.75f).SetEase(Ease.OutQuart);
            isFolded = !isFolded;
            arrow.text = "<";
        } else
        {
            RectTransform topRect = topUI.GetComponent<RectTransform>();
            topRect.DOAnchorPosX(0f, 0.75f).SetEase(Ease.OutQuart);
            isFolded = !isFolded;
            arrow.text = ">";
        }
    }
}
