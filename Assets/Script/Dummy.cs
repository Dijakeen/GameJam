using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public GameObject k;
    private void Awake()
    {
        ChangeSprite(Item.GetSprite(Item.ItemType.Prikol));
    }
    void ChangeSprite(Sprite sprite)
    {
        k.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
