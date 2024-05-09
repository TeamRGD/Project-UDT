using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
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
        text.DOColor(new Color(0.3f, 0.9f, 0.8f), 0.01f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.DOColor(new Color(0,0,0), 0.01f).SetEase(Ease.Linear);
    }
}
