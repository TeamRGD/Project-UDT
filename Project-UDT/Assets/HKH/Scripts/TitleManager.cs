using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject titleUI;
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
            titleRect.DOScale(0f, 0.5f).SetEase(Ease.InExpo).OnComplete(() => titleUI.SetActive(false));
        }
    }


}
