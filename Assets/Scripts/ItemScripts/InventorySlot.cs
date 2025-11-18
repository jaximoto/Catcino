using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;
    public ItemSO itemSO;
    public int quantity;
    public Image itemIcon;
    public TMP_Text quantityText;
    private static ShopManager activeShop;
    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();
    }


    private void OnEnable()
    {
        ShopManager.OnShopOpened += HandleShopOpened;
    }
    private void OnDisable()
    {
        ShopManager.OnShopOpened -= HandleShopOpened;
    }
    private void HandleShopOpened(ShopManager shopManager, bool isOpen)
    {
        activeShop = isOpen ? shopManager : null;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (activeShop != null)
                {
                    activeShop.SellItem(itemSO);
                    quantity --;
                    UpdateUI();
                }
                else
                {
                    inventoryManager.UseItem(this);
                }
            }
        }
    }
    public void UpdateUI()
    {
        if(quantity <= 0)
            itemSO = null;
        
        if (itemSO != null)
        {
            itemIcon.sprite = itemSO.itemIcon;
            itemIcon.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemIcon.gameObject.SetActive(false);
            quantityText.text = "";
        }

    }
}
