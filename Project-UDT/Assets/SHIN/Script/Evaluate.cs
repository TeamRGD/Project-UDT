using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Evaluate : MonoBehaviour
{
    public GameObject topUI;
    public GameObject bottomUI;
    public GameObject returnBtn;
    public GameObject moneyInfo;

    public GameObject generating;
    public Text[] text;

    public TextMeshProUGUI arrow;

    private bool isFolded;
    // Start is called before the first frame update
    void Start()
    {
        isFolded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onComplete()
    {
        isFolded = false;
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "";
        }
        generating.SetActive(true);
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(50f, 0.75f).SetEase(Ease.OutQuart);
        bottomRect.DOAnchorPosY(-70f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(600f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(-35f, 0.75f).SetEase(Ease.OutQuart);
        text[0].DOText("<b><size=40>1. ���� �ο�</size></b>", 0.8f).SetDelay(8.8f).OnStart(() => generating.SetActive(false));
        text[1].DOText("<b>�ǵ�� : </b> ���� ���迡�� ������ �ִ� ���� �ο��� ������� �ʴٴ� ���� �α� ������ ����ȭ �߼��� ����� �� �ɰ��� ������ �߱��� �� �ֽ��ϴ�. �̴� �ְ� ���� ����, ����ȭ, �׸��� ���� ������ ���� �����Ϸ� �̾��� �� �ֽ��ϴ�.\r\n<b>���� ���� : </b>�ְ� ������ �е��� ������Ű�� ���� ���� �ְ� �ǹ��̳� ��е� ����Ʈ ������ ���迡 ���Խ�Ű����. ����, �ְ�, ���, �׸��� ���� �ü��� ������ ȥ�� ��� ������ �����Ͽ� ���� Ȱ�뵵�� ���̰�, �α� ���� �ɷ��� �����ϼ���.\n", 6f).SetDelay(9.6f);
        text[2].DOText("<b><size=40>2. �Ǽ� ���</size></b>", 0.8f).SetDelay(15.6f);
        text[3].DOText("<b>�ǵ�� : </b> ������Ʈ�� ���� �ʰ��� �ڱ��� ȿ���� ����� �����ϸ� ������Ʈ�� ���� ���ɼ����� �������� ������ ��Ĩ�ϴ�. �Ǽ� ����� ��ȹ���� ���� ��Ÿ���� ���� �ڿ� ��а� ��� ���� ������ ������� �ʿ䰡 ������ ��Ÿ���ϴ�.\r\n<b>���� ���� : </b>���� �����ϸ鼭�� ��� ȿ������ ���� ���縦 ����Ͽ� �Ǽ� ����� �����ϼ���. ���� �ܰ迡�� �Ǽ� ����� ������ �� �ִ� ����� ã�ƺ�����. ���� ���, ���ʿ��� ������ ��Ҹ� �����ϰų� �� ������ ���踦 �����Ͽ� ����� ������ �� �ֽ��ϴ�.\n", 6.2f).SetDelay(16.4f);
        text[4].DOText("<b><size=40>3. ź�� ����</size></b>", 0.8f).SetDelay(22.6f);
        text[5].DOText("<b>�ǵ�� : </b>������ ���� ����� ź�� ������ ��緮 �߻���ų �� �ִ� ��Ҹ� ���� �����ϰ� �ֽ��ϴ�. �̴� ���� ��ȭ�� ���� �������� ������ ��ĥ �� �ֽ��ϴ�.\r\n<b>���� ���� : </b>���� �ý����� ���� �Ǵ� ���� ������� ��ȯ�ϰ�, ���� �� �ǹ��� ������ ȿ���� ���̱� ���� ���� ������ ��ȭ�ϼ���. ����, ź�� ��� ����� ��ȭ�ϱ� ���� ���� ��ȭ�� Ȯ���ϴ� ���� ����ϼ���.\n", 5.7f).SetDelay(23.4f);
        text[6].DOText("<b><size=40>4. ģȯ�� ���</size></b>", 0.8f).SetDelay(29.1f);
        text[7].DOText("<b>�ǵ�� : </b>���迡 ģȯ�� ����� ����� �����Ͽ� ���� ������ ���� ��� �ʼ����� ����� ��ȸ�� ��ġ�� �ֽ��ϴ�.\r\n<b>���� ���� : </b>���� ������ ���� ������ ���, ����Ʈ ���� ���, �׸��� ��ȿ�� ������ �ý����� �����Ͽ� ���踦 �����ϼ���.\n", 5.2f).SetDelay(29.9f);
        text[8].DOText("<b><size=40>5. �������� & ��⹰</size></b>", 0.8f).SetDelay(35.1f);
        text[9].DOText("<b>�ǵ�� : </b>���� ����� ��⹰ ������ �������� ó���� ���� ü������ ��ȹ�� �����մϴ�.\r\n<b>���� ���� : </b>��Ȱ�� ���α׷��� ��ȭ�ϰ�, ��⹰ ���� ������ �����ϼ���. ������ �������� ó���� ���� �ü��� ���迡 ���Խ��� ȯ������� �����ϼ���.\n", 5.3f).SetDelay(35.9f);
        text[10].DOText("<b><size=40>6. ����� �������� ���� ��ȸ</size></b>", 0.8f).SetDelay(41.2f);
        text[11].DOText("<b>�ǵ�� : </b>���� ���谡 ����� ������ �ڿ��� ����� Ȱ������ ���ϰ� �ֽ��ϴ�.\r\n<b>���� ���� : </b>�¾籤, ǳ��, ���� �� ����� ������ �ҽ��� �����Ͽ� ������ �ڸ����� ���̰�, ������ ����� ������ �� �ִ� ����� ����ϼ���.",5f).SetDelay(42f);
    }

    public void returnComplete()
    {
        isFolded = true;
        RectTransform bottomRect = bottomUI.GetComponent<RectTransform>();
        RectTransform topRect = topUI.GetComponent<RectTransform>();
        RectTransform returnRect = returnBtn.GetComponent<RectTransform>();
        RectTransform moneyRect = moneyInfo.GetComponent<RectTransform>();
        moneyRect.DOAnchorPosY(-50f, 0.75f).SetEase(Ease.OutQuart);
        bottomRect.DOAnchorPosY(137f, 0.75f).SetEase(Ease.OutQuart);
        topRect.DOAnchorPosX(-600f, 0.75f).SetEase(Ease.OutQuart);
        returnRect.DOAnchorPosX(35f, 0.75f).SetEase(Ease.OutQuart);
    }

    public void doFold()
    {
        if (isFolded)
        {
            RectTransform topRect = topUI.GetComponent<RectTransform>();
            topRect.DOAnchorPosX(600f, 0.75f).SetEase(Ease.OutQuart);
            isFolded = !isFolded;
            arrow.text = "<";
        } else
        {
            RectTransform topRect = topUI.GetComponent<RectTransform>();
            topRect.DOAnchorPosX(0f, 0.75f).SetEase(Ease.OutQuart);
            isFolded = !isFolded;
            arrow.text = ">";
        }
    }
}
