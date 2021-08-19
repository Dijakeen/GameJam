using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public DialogTrigger dialogTrigger;
    public Text nameText;
    public Text dialogText;
    delegate void dialogIsFalse();
    public Animator animator;
    public GameObject obj;
    public bool byDialog = false;
    Movement movement;
    PhysicsJump physicsJump;
    public bool IsSpace = false;

    //delegate void FalseBoolDialog();

    private Queue<string> sentences;
    private Queue<Dialog> dialogsQ;

    void Start()
    {
        sentences = new Queue<string>();
        dialogsQ = new Queue<Dialog>();
        movement = obj.GetComponent<Movement>();        
        physicsJump = obj.GetComponent<PhysicsJump>();

    }

    public void StartDialogs (List<Dialog> dialogsL)
    {
        if (!byDialog)
        {
            dialogsQ.Clear();
            foreach (Dialog dialog in dialogsL)
            {
                dialogsQ.Enqueue(dialog);
            }
            Dialog dialogInStart = dialogsQ.Dequeue();
            StartDialog(dialogInStart);
            byDialog = true;
            movement.enabled = false;
            physicsJump.enabled = false;

        }
    }
    public void StartDialog(Dialog dialog) //������ ����������� ����� �� DialogTrigger
    {
 
            animator.SetBool("isOne", true);//��� �� ����������
            Debug.Log("Talk to" + dialog.name);

            nameText.text = dialog.name;//����� � ����� ��� ����� ��� (���������� �� ������ dialog)

            sentences.Clear();//������� ��������� �����

            foreach (string sentence in dialog.sentences)//���������� �� ������ ����� �� ������� ���� � �������
            {
                sentences.Enqueue(sentence);//��������� � ���������(������ ������� �������� ��������� ����� �����������) ������ �����
            }
        DisplayNextSentence();//������������  � ����� ��� ������������ ���� � ������ ���
    }

    public void DisplayNextSentence ()//�����, ������� ������������ ��� onClick � ������ �������� � ��������� ����
    {
        if (sentences.Count == 0)//��������� �������� �� ��� � ������� �����, ���� ���, �� ��������� � ������ � ����������� ������
        {
           
            if (dialogsQ.Count == 0)
            {
                EndDialog();
                return;
            }
            StartDialog(dialogsQ.Dequeue());//��������� � ������ EndDialog
            return;
        }
        
        string sentence = sentences.Dequeue();//��������� ����� ���������� � �������������� �� ��������� � ������� ���������(�����) �������
       // dialogText.text = sentence;//�������� ����� ������� 
        StartCoroutine(TypeSentence(sentence));//�������� ����� ������� ������� ����� �� ������
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";//������ ���������� ��� ������ ������
        foreach(char letter in sentence.ToCharArray())//���������� �� ������� ������� � ������
        {
            dialogText.text += letter;//��������� ������ � ���������� ����
            yield return new WaitForSeconds(0.02f);//� �� ��� ��� ��������, ����� ����� �� ��������� ��� �����������          
        }
        IsSpace = false;
    }
    public void EndDialog()
    {
        Debug.Log("End dialog");
        animator.SetBool("isOne", false);
        byDialog = false;
        movement.enabled = true;
        physicsJump.enabled = true;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !IsSpace)
        {
            DisplayNextSentence();
            IsSpace = true;
        }
    }


}
