using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] bool _haveKey;
    [SerializeField] bool _havePrikol;

    public bool CheckItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Key:
                if (_haveKey)
                    return true;
                else
                    return false;

            case Item.ItemType.Prikol:
                if (_havePrikol)
                    return true;
                else
                    return false;
        }
    }

    public void GetItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Key:
                _haveKey = true;
                return;
            case Item.ItemType.Prikol:
                _havePrikol = true;
                return;
        }
    }
}
