using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModalManager : MonoBehaviour
{
    public GameObject[] modalContainers;
    public GameObject[] modals;
    public Image[] backGrounds;

    private int bug;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < modalContainers.Length; i++)
        {
            modalContainers[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onModalOnClick(int index)
    {
        for (int i = 0; i < modalContainers.Length; i++)
        {
            modalContainers[i].SetActive(false);
        }
        for (int i = 0; i < modalContainers.Length; i++)
        {
            if (i == index)
            {
                modalContainers[i].SetActive(true);
                RectTransform modalRect = modals[i].GetComponent<RectTransform>();
                modalRect.localScale = Vector3.one;
                modalRect.DOScale(0f, 0.25f).From().SetEase(Ease.OutQuart);
                backGrounds[i].DOFade(0.2f, 0.25f).SetEase(Ease.Linear);
                Debug.Log("Hi!");
            }
        }
    }

    public void onModalOffClick(int index)
    {
        for (int i = 0; i < modalContainers.Length; i++)
        {
            if (i == index)
            {
                bug = i;
                RectTransform modalRect = modals[i].GetComponent<RectTransform>();
                backGrounds[i].DOFade(0f, 0.25f).SetEase(Ease.Linear);
                modalRect.DOScale(0f, 0.25f).SetEase(Ease.InQuart).OnComplete(() => modalContainers[bug].SetActive(false));
                Debug.Log("Hi!!!");
            }
        }
    }
}
