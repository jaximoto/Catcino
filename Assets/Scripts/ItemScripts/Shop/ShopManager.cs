using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public class ShopManager : MonoBehaviour
{
    public static event Action<ShopManager, bool> OnShopOpened;
    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private List<ShopItems> shopOutfits;

    [SerializeField] private ShopSlot[] shopSlots;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject shopPanel; // assign the parent UI panel for the shop
    private enum ShopType { Items = 0, Outfits = 1 }
    private ShopType activeShop = ShopType.Items;

    private void Start()
    {
        // default to items shop, but keep the shop panel closed at start
        activeShop = ShopType.Items;
        // prepare slots so the UI is ready when opened
        PopulateShop();

        if (shopPanel != null)
            shopPanel.SetActive(false);
        else
            Debug.LogWarning("ShopManager.Start: shopPanel is not assigned. The shop panel will remain in its scene-set state.");

        // notify listeners that the shop is closed at start
        OnShopOpened?.Invoke(this, false);
    }

    public void PopulateShop()
    {
        List<ShopItems> listToShow = (activeShop == ShopType.Outfits) ? shopOutfits : shopItems;

        // If the selected list is null or empty, hide all slots
        if (listToShow == null || listToShow.Count == 0)
        {
            for (int i = 0; i < shopSlots.Length; i++)
                shopSlots[i].gameObject.SetActive(false);
            return;
        }

        for (int i = 0; i < listToShow.Count && i < shopSlots.Length; i++)
        {
            ShopItems shopItem = listToShow[i];
            if (shopItem == null || shopItem.itemSO == null)
            {
                shopSlots[i].gameObject.SetActive(false);
                continue;
            }

            shopSlots[i].Initialize(shopItem.itemSO, shopItem.price);
            shopSlots[i].gameObject.SetActive(true);
        }

        for (int i = listToShow.Count; i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);
        }
    }

    // Public API for UI buttons
    public void ShowItems()
    {
        activeShop = ShopType.Items;
        PopulateShop();
        OnShopOpened?.Invoke(this, true);
    }

    public void ShowOutfits()
    {
        activeShop = ShopType.Outfits;
        PopulateShop();
        OnShopOpened?.Invoke(this, true);
    }

    // Helper for Unity Button to pass index (0 = items, 1 = outfits)
    public void ShowShopByIndex(int index)
    {
        if (index == (int)ShopType.Outfits) ShowOutfits();
        else ShowItems();
    }

    // Toggle the shop panel on/off. Bind this to a UI Button placed outside the shop UI.
    public void ToggleShop()
    {
        if (shopPanel == null)
        {
            Debug.LogWarning("ShopManager.ToggleShop: shopPanel is not assigned.");
            return;
        }

        bool willOpen = !shopPanel.activeSelf;
        shopPanel.SetActive(willOpen);

        if (willOpen)
        {
            // ensure the currently selected shop is populated when opening
            PopulateShop();
        }

        OnShopOpened?.Invoke(this, willOpen);
    }

    // Explicit open/close helpers
    public void OpenShopPanel()
    {
        if (shopPanel == null) return;
        if (!shopPanel.activeSelf)
        {
            shopPanel.SetActive(true);
            PopulateShop();
            OnShopOpened?.Invoke(this, true);
        }
    }

    public void CloseShopPanel()
    {
        if (shopPanel == null) return;
        if (shopPanel.activeSelf)
        {
            shopPanel.SetActive(false);
            OnShopOpened?.Invoke(this, false);
        }
    }
    public void TryBuyItem(ItemSO itemSO, int price)
    {
        if (itemSO != null && inventoryManager.gold >= price)
        {
            if (HasSpaceInInventory(itemSO))
            {
                inventoryManager.gold -= price;
                inventoryManager.goldText.text = inventoryManager.gold.ToString();
                inventoryManager.AddItem(itemSO, 1);
            }

        }
    }
    private bool HasSpaceInInventory(ItemSO itemSO)
    {
        foreach (var slot in inventoryManager.itemSlots)
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
                return true;
            else if (slot.itemSO == null)
                return true;

        }
        return false;
    }
    public void SellItem(ItemSO itemSO)
    {
        if (itemSO == null)
            return;
        foreach(var slot in shopSlots)
        {
            if(slot.itemSO == itemSO)
            {
                inventoryManager.gold += slot.price /2;
                inventoryManager.goldText.text = inventoryManager.gold.ToString();
                return;
            }
        }
        
    }
}
[System.Serializable]
public class ShopItems
{
    public ItemSO itemSO;
    public int price;
}

