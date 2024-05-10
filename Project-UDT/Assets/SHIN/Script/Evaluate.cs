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
        text[0].DOText("<b><size=40>1. 수용 인원</size></b>", 0.8f).SetDelay(8.8f).OnStart(() => generating.SetActive(false));
        text[1].DOText("<b>피드백 : </b> 현재 설계에서 도시의 최대 수용 인원이 충분하지 않다는 점은 인구 증가와 도시화 추세를 고려할 때 심각한 문제를 야기할 수 있습니다. 이는 주거 공간 부족, 과밀화, 그리고 관련 인프라에 대한 과부하로 이어질 수 있습니다.\r\n<b>권장 사항 : </b>주거 지역의 밀도를 증가시키기 위해 다층 주거 건물이나 고밀도 아파트 단지를 설계에 포함시키세요. 또한, 주거, 상업, 그리고 레저 시설을 통합한 혼합 사용 개발을 적용하여 공간 활용도를 높이고, 인구 수용 능력을 개선하세요.\n", 6f).SetDelay(9.6f);
        text[2].DOText("<b><size=40>2. 건설 비용</size></b>", 0.8f).SetDelay(15.6f);
        text[3].DOText("<b>피드백 : </b> 프로젝트의 예산 초과는 자금의 효율적 사용을 저해하며 프로젝트의 지속 가능성에도 부정적인 영향을 미칩니다. 건설 비용이 계획보다 높게 나타나는 것은 자원 배분과 비용 관리 전략을 재검토할 필요가 있음을 나타냅니다.\r\n<b>권장 사항 : </b>지속 가능하면서도 비용 효율적인 건축 자재를 사용하여 건설 비용을 절감하세요. 설계 단계에서 건설 비용을 절감할 수 있는 방법을 찾아보세요. 예를 들어, 불필요한 구조적 요소를 제거하거나 더 간단한 설계를 적용하여 비용을 절감할 수 있습니다.\n", 6.2f).SetDelay(16.4f);
        text[4].DOText("<b><size=40>3. 탄소 배출</size></b>", 0.8f).SetDelay(22.6f);
        text[5].DOText("<b>피드백 : </b>현재의 도시 설계는 탄소 배출을 상당량 발생시킬 수 있는 요소를 많이 포함하고 있습니다. 이는 기후 변화에 대한 부정적인 영향을 끼칠 수 있습니다.\r\n<b>권장 사항 : </b>교통 시스템을 전기 또는 수소 기반으로 전환하고, 도시 내 건물의 에너지 효율을 높이기 위해 건축 기준을 강화하세요. 또한, 탄소 흡수 기능을 강화하기 위해 도시 녹화를 확대하는 것을 고려하세요.\n", 5.7f).SetDelay(23.4f);
        text[6].DOText("<b><size=40>4. 친환경 기술</size></b>", 0.8f).SetDelay(29.1f);
        text[7].DOText("<b>피드백 : </b>설계에 친환경 기술의 사용이 부족하여 지속 가능한 도시 운영에 필수적인 기술적 기회를 놓치고 있습니다.\r\n<b>권장 사항 : </b>지속 가능한 건축 자재의 사용, 스마트 빌딩 기술, 그리고 고효율 에너지 시스템을 포함하여 설계를 개선하세요.\n", 5.2f).SetDelay(29.9f);
        text[8].DOText("<b><size=40>5. 유독물질 & 폐기물</size></b>", 0.8f).SetDelay(35.1f);
        text[9].DOText("<b>피드백 : </b>현재 설계는 폐기물 관리와 유독물질 처리에 대한 체계적인 계획이 부족합니다.\r\n<b>권장 사항 : </b>재활용 프로그램을 강화하고, 폐기물 감소 전략을 도입하세요. 적절한 유독물질 처리와 저장 시설을 설계에 포함시켜 환경오염을 방지하세요.\n", 5.3f).SetDelay(35.9f);
        text[10].DOText("<b><size=40>6. 신재생 에너지에 대한 기회</size></b>", 0.8f).SetDelay(41.2f);
        text[11].DOText("<b>피드백 : </b>도시 설계가 신재생 에너지 자원을 충분히 활용하지 못하고 있습니다.\r\n<b>권장 사항 : </b>태양광, 풍력, 지열 등 신재생 에너지 소스를 통합하여 에너지 자립도를 높이고, 에너지 비용을 절감할 수 있는 방안을 모색하세요.",5f).SetDelay(42f);
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
