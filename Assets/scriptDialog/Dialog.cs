using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog//Класс - контент для заполнения диалогового окна
{
    
    public string name;//имя персонажа который говорит

    [TextArea(3, 10)]//утанавливаем размер окошка в инспекторе для текста диалога
    public string[] sentences;//массив фраз персонажа
}
