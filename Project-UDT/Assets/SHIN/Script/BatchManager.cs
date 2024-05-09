using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BatchManager : MonoBehaviour
{
    public GameObject[] interactions;
    public Image[] highlights;
    public RectTransform rectTransform;

    private GameObject prevObj;
    private int prevInt;
    private bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        prevInt = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject curObj = EventSystem.current.currentSelectedGameObject;
            if (curObj != null) 
            {
                Debug.Log("Hello");
                for (int i = 0; i < interactions.Length; i++)
                {
                    if (prevInt == -1)
                    {
                        if (curObj == interactions[i])
                        {
                            prevInt = i;
                            RectTransform highRect = highlights[i].GetComponent<RectTransform>();
                            highRect.DOScaleX(1f, 0.1f).SetEase(Ease.OutSine);
                            isClicked = !isClicked; break;
                        }
                    } else
                    {
                        if (curObj == interactions[prevInt])
                        {
                            RectTransform highRect = highlights[prevInt].GetComponent<RectTransform>();
                            highRect.DOScaleX(0f, 0.1f).SetEase(Ease.OutSine);
                            prevInt = -1;
                            isClicked = !isClicked; break;
                        } else
                        {
                            if (curObj == interactions[i])
                            {
                                RectTransform prevHighRect = highlights[prevInt].GetComponent<RectTransform>();
                                prevHighRect.DOScaleX(0f, 0.1f).SetEase(Ease.OutSine);
                                RectTransform highRect = highlights[i].GetComponent<RectTransform>();
                                highRect.DOScaleX(1f, 0.1f).SetEase(Ease.OutSine);
                                prevInt = i; break;
                            }
                        }
                    }
                    }
                }
            }
        if (isClicked)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                rectTransform.DOAnchorPosY(-80f, 0.25f).SetEase(Ease.OutSine);
            } else
            {
                rectTransform.DOAnchorPosY(140f, 0.25f).SetEase(Ease.OutSine);
            }
        }
    }
}
