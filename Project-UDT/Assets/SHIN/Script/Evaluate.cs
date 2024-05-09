using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluate : MonoBehaviour
{
    public GameObject topUI;
    public GameObject bottomUI;
    public GameObject returnBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onComplete()
    {
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        bottomRect.DOAnchorPosY(-70f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(230f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(-35f, 0.75f).SetEase(Ease.OutQuart);
    }

    public void returnComplete()
    {
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        bottomRect.DOAnchorPosY(140f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(-230f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(35f, 0.75f).SetEase(Ease.OutQuart);
    }
}
