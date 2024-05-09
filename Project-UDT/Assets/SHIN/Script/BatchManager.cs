using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BatchManager : MonoBehaviour
{
    public GameObject[] interactions;
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
                            isClicked = !isClicked; break;
                        }
                    } else
                    {
                        if (curObj == interactions[prevInt])
                        {
                            prevInt = -1;
                            isClicked = !isClicked; break;
                        } else
                        {
                            if (curObj == interactions[i])
                            {
                                prevInt = i; break;
                            }
                        }
                    }
                        //여기서 적절한 프리펩 호출하면 될듯
                    }
                Debug.Log(prevInt);
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
