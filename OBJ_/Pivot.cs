using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private GameObject pivot;
    private GameObject player;

    private void Start()
    {
        pivot = GameObject.FindWithTag("Pivot");
        player = GameObject.FindWithTag("Player");
    }

    void Update() {

    }

    private void LateUpdate()
    {
        Pos();
        Rotate();
    }

    // �÷��̾� �Ӹ� ���� ��ġ ����
    private void Pos()
    {
        if (player != null) {
            pivot.transform.position = player.transform.position + (Vector3.up * 0.7f);
        }
    }

    // �Ǻ�, ī�޶� ȸ��
    private void Rotate()
    {
        Vector3 Angles = transform.rotation.eulerAngles;
        float MouseX = Input.GetAxis("Mouse X") * 2.5f;
        float MouseY = Input.GetAxis("Mouse Y") * 2.5f;
        float eulerAnglesX = Angles.x - MouseY; // �ִ� ī�޶� ���� ������ ���� ����
        float eulerAnglesY = Angles.y + MouseX;

        // ȸ�� ���� �ִ� ���� ����
        if (eulerAnglesX < 180)
        {
            eulerAnglesX = Mathf.Clamp(eulerAnglesX, -1, 70); // -1���� ������ ���� �αٿ����� ������ ��������
        }
        else if (eulerAnglesX >= 180)
        {
            eulerAnglesX = Mathf.Clamp(eulerAnglesX, 359, 361); // 1���� ������ ���� ����
        }

        // Angles += new Vector3(-MouseY, MouseX, 0) * 3f; ���Ϸ� �ޱ�ȭ ��Ű�� �����̼� ���� �Ұ�

        // ���콺 �����ӿ� ���� CamSpot ȸ�� �� ����
        if (Cursor.visible == false)
        {
            pivot.transform.rotation = Quaternion.Euler(eulerAnglesX, eulerAnglesY, Angles.z);
        }
    }
}