using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public List<Dialog> dialogs;
    public GameObject dialogObj;
    public float distance;
    public float dialogDistance = 3f;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialogs(dialogs);
        //���������� ����� ������� DialogManger, � ��������� � ��� StartDialog � ���������� dialog
        //(� ������� �� ����� �������� � ����� ������� � ����������)
    }

    public void FixedUpdate()
    {
            distance = Vector3.Distance(dialogObj.transform.position, transform.position);//������������ ���������� ����� �������� ������� � ����� ����������
            if (distance <= dialogDistance && Input.GetKey(KeyCode.E))//���������, ������ ��������� ��� ����������, ������ �� ������ "�" � ��� ��� ������ ��� ���(����� ���������� ��� ���!)
            {
                TriggerDialog();//�������� ����� ������  �������
                Debug.Log("������� �����");

            }
    }


}
