using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Food,
        Key,
        Prikol
    }

    public static string GetName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Food: return "Food";
            case ItemType.Prikol: return "Prikol";
            case ItemType.Key: return "Key";
        }
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Food:return 5;
            case ItemType.Prikol:return 1;
            case ItemType.Key:return 30;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Food: return GameAssets.i.s_Food;
            case ItemType.Prikol: return GameAssets.i.s_Prikol;
            case ItemType.Key: return GameAssets.i.s_Key;
        }
    }
}
