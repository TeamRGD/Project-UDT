using System.Collections;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    public GameObject[] smokeObjects; // ���� ������Ʈ �迭
    public float delayBetweenSmokes = 1f; // �� ���� ������ �ð���
    public float disappearTime = 3f; // ���Ⱑ ������������ �ð�
    public Vector3 moveDirectionY = new Vector3(0, 1, 0); // y�� ���� �̵�
    public Vector3 moveDirectionYZ = new Vector3(0, 1, 1); // y��� z�� ���� �̵�
    public float moveDistance = 1f; // �̵� �Ÿ�

    private void Start()
    {
        StartCoroutine(SpawnAndMoveSmokes());
    }

    IEnumerator SpawnAndMoveSmokes()
    {
        foreach (GameObject smoke in smokeObjects)
        {
            StartCoroutine(MoveAndDisappear(smoke));
            yield return new WaitForSeconds(delayBetweenSmokes); // ���� ���Ⱑ ���۵Ǳ���� ��ٸ�
        }
    }

    IEnumerator MoveAndDisappear(GameObject smoke)
    {
        // �ʱ� ��ġ ����
        Vector3 originalPosition = smoke.transform.position;

        // y������ 1�� ���� �̵�
        float elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            smoke.transform.position += moveDirectionY * moveDistance * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // y��� z�� �������� �̵�
        elapsedTime = 0;
        while (elapsedTime < disappearTime - 1f) // �̹� 1�ʰ� ����
        {
            smoke.transform.position += moveDirectionYZ * moveDistance * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���� �����
        smoke.SetActive(false);
        yield return new WaitForSeconds(1f); // ������� ȿ���� ���� ��� ���

        // �ʱ� ��ġ���� �ٽ� Ȱ��ȭ
        smoke.transform.position = originalPosition;
        smoke.SetActive(true);

        // �ٽ� �ݺ�
        StartCoroutine(MoveAndDisappear(smoke));
    }
}
