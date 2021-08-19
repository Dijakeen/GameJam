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
    public void StartDialog(Dialog dialog) //Первый запускаемый метод из DialogTrigger
    {
 
            animator.SetBool("isOne", true);//еще не разобрался
            Debug.Log("Talk to" + dialog.name);

            nameText.text = dialog.name;//Пишет в текст для имени имя (переменную из класса dialog)

            sentences.Clear();//Очищяет коллекцию строк

            foreach (string sentence in dialog.sentences)//Проходимся по каждой фразе из массива фраз в диалоге
            {
                sentences.Enqueue(sentence);//добавляем в коллекцию(каждый элемент ставится следующим после предыдущего) каждую фразу
            }
        DisplayNextSentence();//отправляемся  в метод для переключения рфзу в первый раз
    }

    public void DisplayNextSentence ()//метод, который используется для onClick в кнопке перехода к следующей рфзе
    {
        if (sentences.Count == 0)//проверяем остались ли еще в очереди фразы, если нет, то переходим к методу и заканчиваем скрипт
        {
           
            if (dialogsQ.Count == 0)
            {
                EndDialog();
                return;
            }
            StartDialog(dialogsQ.Dequeue());//переходим к методу EndDialog
            return;
        }
        
        string sentence = sentences.Dequeue();//объявляем новую переменную и инициализируем ее следующим в очереди элементом(фраза) очереди
       // dialogText.text = sentence;//изменяем текст диалога 
        StartCoroutine(TypeSentence(sentence));//вызываем метод который выводит текст по буквам
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";//диалог появляется как пуская строка
        foreach(char letter in sentence.ToCharArray())//проходимся по каждому символу в строке
        {
            dialogText.text += letter;//добавляем символ в диалоговое окно
            yield return new WaitForSeconds(0.02f);//я хз как это работает, нужно чтобы не мгновенно все заполнялось          
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
