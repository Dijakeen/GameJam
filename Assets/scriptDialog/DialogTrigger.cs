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
        //Производит поиск скрипта DialogManger, и запускает в нем StartDialog с параметром dialog
        //(в который мы пишем название и текст диалога в инспекторе)
    }

    public void FixedUpdate()
    {
            distance = Vector3.Distance(dialogObj.transform.position, transform.position);//Рассчитываем расстояние между объектом диалога и нашим персонажем
            if (distance <= dialogDistance && Input.GetKey(KeyCode.E))//проверяем, меньше растояние чем предельное, нажата ли кнопка "Е" и был это диалог или нет(иначе происходит дич БАГ!)
            {
                TriggerDialog();//вызываем метод вызова  диалога
                Debug.Log("Вызвали метод");

            }
    }


}
