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
    public Image[] icons;
    public Image[] highlights;
    public RectTransform rectTransform;
    public Text moneyText;
    public Material outliner;

    public Texture2D moveCursor;
    public Texture2D originalCursor;
    private Disposition dispositionScript;
    private DestroyBuilding destroyBuilding;

    private int prevInt;
    private bool isClicked;

    public float money;
    private float[] moneyValues = {10, 1, 1, 1, 1, 1, 100, 1000, 4000, 30, 100, 0.1f, 0.1f, 0.1f, 0.1f, 1, 100, 10};
    // Start is called before the first frame update
    void Start()
    {
        GameObject buildingManager = GameObject.Find("BuildingManager");
        dispositionScript = buildingManager.GetComponent<Disposition>();
        destroyBuilding = buildingManager.GetComponent <DestroyBuilding>(); //destroyBuilding.id_ 사용하면 해서 돈 깎으면 됨. 
        isClicked = false;
        prevInt = -1;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dispositionScript.currentInstance == null)
        {
            if (prevInt!=-1)
            {
                icons[prevInt].material = null;
                Cursor.SetCursor(originalCursor, new Vector2(0, 0), CursorMode.Auto);
                RectTransform highRect = highlights[prevInt].GetComponent<RectTransform>();
                highRect.DOScaleX(0f, 0.1f).SetEase(Ease.OutSine);
                //배치에 따른 돈 상승 코드, 배치기능이랑 합쳐지면 맞게 수정할거임.
                money += moneyValues[prevInt];
                moneyText.DOText(money.ToString()+"M", 0.25f, true, ScrambleMode.Numerals);
                prevInt = -1;
                isClicked = !isClicked;
                rectTransform.DOAnchorPosY(137f, 0.25f).SetEase(Ease.OutSine);
            }
        }
        if (destroyBuilding.isRemovalMode)
        {
            if (destroyBuilding.isRemoved)
            {
                // 여기서 돈 깎으삼.
                Debug.Log("removed");
                money -= moneyValues[destroyBuilding.id_];
                moneyText.DOText(money.ToString() + "M", 0.25f, true, ScrambleMode.Numerals);
                destroyBuilding.isRemoved = false;
            }
        }
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
                            icons[i].material = outliner;
                            Cursor.SetCursor(moveCursor, new Vector2(0, 0), CursorMode.Auto);
                            prevInt = i;
                            RectTransform highRect = highlights[i].GetComponent<RectTransform>();
                            highRect.DOScaleX(1f, 0.1f).SetEase(Ease.OutSine);
                            isClicked = !isClicked;
                            break;
                        }
                    } else
                    {
                        if (curObj == interactions[prevInt])
                        {
                            icons[prevInt].material = null;
                            Cursor.SetCursor(originalCursor, new Vector2(0, 0), CursorMode.Auto);
                            RectTransform highRect = highlights[prevInt].GetComponent<RectTransform>();
                            highRect.DOScaleX(0f, 0.1f).SetEase(Ease.OutSine);
                            //배치에 따른 돈 상승 코드, 배치기능이랑 합쳐지면 맞게 수정할거임.
                            money += moneyValues[prevInt];
                            moneyText.DOText(money.ToString(), 0.25f, true, ScrambleMode.Numerals);
                            prevInt = -1;
                            isClicked = !isClicked; break;
                        } else
                        {
                            if (curObj == interactions[i])
                            {
                                icons[i].material = outliner;
                                icons[prevInt].material = null;
                                Cursor.SetCursor(moveCursor, new Vector2(0, 0), CursorMode.Auto);
                                RectTransform prevHighRect = highlights[prevInt].GetComponent<RectTransform>();
                                prevHighRect.DOScaleX(0f, 0.1f).SetEase(Ease.OutSine);
                                RectTransform highRect = highlights[i].GetComponent<RectTransform>();
                                highRect.DOScaleX(1f, 0.1f).SetEase(Ease.OutSine);
                                prevInt = i;
                                break;
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
                rectTransform.DOAnchorPosY(137f, 0.25f).SetEase(Ease.OutSine);
            }
        }
    }
}
