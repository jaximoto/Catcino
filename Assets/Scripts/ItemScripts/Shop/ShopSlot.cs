using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text itemPriceText;
    public Image itemImage;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private ShopInfo shopInfo;
    public int price;
    


    public void Initialize(ItemSO newItemSO, int price)
    {
        itemSO = newItemSO;
        itemImage.sprite = itemSO.itemIcon;
        itemNameText.text = itemSO.itemName;
        this.price = price;
        itemPriceText.text = price.ToString();

    }
    public void OnBuyButtonClicked()
    {
        if (itemSO != null)
            shopManager.TryBuyItem(itemSO, price);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        shopInfo.ShowItemInfo(itemSO);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        shopInfo.HideItemInfo();
    }
    
}
