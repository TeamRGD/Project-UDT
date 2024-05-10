using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] categoties;
    public GameObject[] scrollViews;

    public Image destroyTeduri;
    public GameObject destroyInfo;
    public GameObject bottomUI;
    public GameObject moneyInfo;

    public Texture2D destroyCursor;
    public Texture2D originalCursor;

    public int currentCategory;
    // Start is called before the first frame update
    void Start()
    {
        destroyTeduri.enabled = false;
        onCategoryClick(0);
        for (int i = 0; i < scrollViews.Length; i++)
        {
            scrollViews[i].SetActive(true);
            if (i == 0)
            {
                continue;
            }
            scrollViews[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick(int index)
    {
        Debug.Log(index);
        for (int i = 0; i < scrollViews.Length; i++)
        {
            scrollViews[i].SetActive(true);
            if (i == index)
            {
                continue;
            }
            scrollViews[i].SetActive(false);
        }
    }

    public void onCategoryClick(int index)
    {
        for (int i = 0; i < categoties.Length; i++)
        {
            if (i == index)
            {
                categoties[i].DOFade(0f, 0.1f).SetEase(Ease.Linear);
            }
            else
            {
                categoties[i].DOFade(1f, 0.1f).SetEase(Ease.Linear);
            }
        }
    }

    public void onDestroyClick()
    {
        destroyTeduri.enabled = true;
        Cursor.SetCursor(destroyCursor, new Vector2(0, 0), CursorMode.Auto);
        RectTransform teduriRect = destroyTeduri.GetComponent<RectTransform>();
        teduriRect.DOScale(1f, 0.75f).SetEase(Ease.OutQuart);
        RectTransform destroyRect = destroyInfo.GetComponent<RectTransform>();
        destroyRect.DOAnchorPosY(-50f, 1f).SetEase(Ease.OutQuart);
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        bottomRect.DOAnchorPosY(-80f, 0.5f).SetEase(Ease.InQuart);
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(50f, 0.5f).SetEase(Ease.InQuart);
    }

    public void OnDestroyExit() {
        Cursor.SetCursor(originalCursor, new Vector2(0, 0), CursorMode.Auto);
        RectTransform teduriRect = destroyTeduri.GetComponent<RectTransform>();
        teduriRect.DOScale(1.05f, 0.75f).SetEase(Ease.InQuart).OnComplete(() => destroyTeduri.enabled = false);
        RectTransform destroyRect = destroyInfo.GetComponent<RectTransform>();
        destroyRect.DOAnchorPosY(50f, 1f).SetEase(Ease.OutQuart);
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        bottomRect.DOAnchorPosY(137f, 0.5f).SetEase(Ease.OutQuart);
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(-50f, 0.75f).SetEase(Ease.OutQuart);
    }
}
