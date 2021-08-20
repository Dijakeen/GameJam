using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    bool is_ground = false;     //переменна€ котора€ хранит в себе значение, "на земле ли игрок"
    Rigidbody2D player;         //так как мы часть обращаемс€ к физике, то не лишним будет закэшировать этот компонент
    public float force = 6;     //сила с которой будет прыгать персонаж

    void Start()
    {
        player = GetComponent<Rigidbody2D>(); //при старке сцены, получаем компонент и сохран€ем в переменную
    }

    void OnTriggerStay2D(Collider2D col)
    {               //если в тригере что то есть и у обьекта тег "ground"
        if (col.tag == "ground") is_ground = true;      //то включаем переменную "на земле"
    }
    void OnTriggerExit2D(Collider2D col)
    {              //если из триггера что то вышло и у обьекта тег "ground"
        if (col.tag == "ground") is_ground = false;     //то вџключаем переменную "на земле"
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_ground)               //если нажата кнопка "пробел" и игрок на земле
            player.AddForce(Vector2.up * force, ForceMode2D.Impulse);   //то придаем ему силу вверх импульсным пинком
    }
}