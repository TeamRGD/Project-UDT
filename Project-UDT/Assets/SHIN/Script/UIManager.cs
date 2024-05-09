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

    public int currentCategory;
    // Start is called before the first frame update
    void Start()
    {
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
}
