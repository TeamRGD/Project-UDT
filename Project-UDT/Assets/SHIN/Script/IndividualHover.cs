using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IndividualHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI objectName;
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
        objectName.DOColor(new Color(0, 200, 197), 0.01f).SetEase(Ease.Linear);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectName.DOColor(new Color(0,0,0), 0.01f).SetEase(Ease.Linear);
    }
}
