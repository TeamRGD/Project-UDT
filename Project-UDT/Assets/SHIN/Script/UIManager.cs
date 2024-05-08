using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] scrollViews;
    // Start is called before the first frame update
    void Start()
    {
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
}
