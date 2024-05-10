using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject bottomUI;
    public GameObject moneyUI;

    public UIManager ui;
    //public string SceneToLoad;
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SceneManager.LoadScene(SceneToLoad);
    //    }
    //}

    void Start()
    {

        
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RectTransform titleRect = titleUI.GetComponent<RectTransform>();
            titleRect.DOScale(0f, 0.5f).SetEase(Ease.InExpo).OnComplete(() => startFunc());
        }
    }

    public void startFunc()
    {
        titleUI.SetActive(false);
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        bottomRect.DOAnchorPosY(137f, 1f).SetEase(Ease.OutQuart);
        RectTransform moneyRect = moneyUI.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(-50f, 1f).SetEase(Ease.OutQuart).OnComplete(() => ui.GetComponent<TitleManager>().enabled = false) ;
    }


}
