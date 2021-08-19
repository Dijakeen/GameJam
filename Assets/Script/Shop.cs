using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    public GameObject player;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemStand(Item.ItemType.Food, Item.GetSprite(Item.ItemType.Food), Item.GetName(Item.ItemType.Food), Item.GetCost(Item.ItemType.Food), 0);
        CreateItemStand(Item.ItemType.Prikol, Item.GetSprite(Item.ItemType.Prikol), Item.GetName(Item.ItemType.Prikol), Item.GetCost(Item.ItemType.Prikol), 1);
        CreateItemStand(Item.ItemType.Key, Item.GetSprite(Item.ItemType.Key), Item.GetName(Item.ItemType.Key), Item.GetCost(Item.ItemType.Key), 2);
    }

    private void CreateItemStand(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);

        float shopItemDist = 3f;
        shopItemTransform.position = new Vector3(-shopItemDist * positionIndex, shopItemTransform.position.y, shopItemTransform.position.z);

        shopItemTransform.Find("itemText").GetComponent<TextMeshPro>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshPro>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemSprite").GetComponent<SpriteRenderer>().sprite = itemSprite;
        shopItemTransform.Find("boxCollider").GetComponent<PlayerInTrigger>().triggeret.AddListener(() => TryBuyItem(itemType));
    }

    void TryBuyItem(Item.ItemType itemType)
    {
        int fds = player.GetComponent<Wallet>()._pickUpCoin;
        if (fds >= Item.GetCost(itemType) && !player.GetComponent<InventoryManager>().CheckItem(itemType))
        {
            fds -= Item.GetCost(itemType);
            player.GetComponent<Wallet>()._pickUpCoin = fds;
            player.GetComponent<Wallet>()._money.text = fds.ToString();
            player.GetComponent<InventoryManager>().GetItem(itemType);
        }
        else
            Debug.Log("Fuck you");
    }

}
