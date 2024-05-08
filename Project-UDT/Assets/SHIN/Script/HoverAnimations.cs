using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOAnchorPosY(33f, 0.1f).SetEase(Ease.InOutSine);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOAnchorPosY(23f, 0.1f).SetEase(Ease.InOutSine);
    }

}
