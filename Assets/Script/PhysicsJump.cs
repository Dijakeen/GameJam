using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    bool is_ground = false;     //���������� ������� ������ � ���� ��������, "�� ����� �� �����"
    Rigidbody2D player;         //��� ��� �� ����� ���������� � ������, �� �� ������ ����� ������������ ���� ���������
    public float force = 6;     //���� � ������� ����� ������� ��������

    void Start()
    {
        player = GetComponent<Rigidbody2D>(); //��� ������ �����, �������� ��������� � ��������� � ����������
    }

    void OnTriggerStay2D(Collider2D col)
    {               //���� � ������� ��� �� ���� � � ������� ��� "ground"
        if (col.tag == "ground") is_ground = true;      //�� �������� ���������� "�� �����"
    }
    void OnTriggerExit2D(Collider2D col)
    {              //���� �� �������� ��� �� ����� � � ������� ��� "ground"
        if (col.tag == "ground") is_ground = false;     //�� ��������� ���������� "�� �����"
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_ground)               //���� ������ ������ "������" � ����� �� �����
            player.AddForce(Vector2.up * force, ForceMode2D.Impulse);   //�� ������� ��� ���� ����� ���������� ������
    }
}