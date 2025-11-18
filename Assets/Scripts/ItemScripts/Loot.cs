using UnityEngine;
using System;
public class Loot : MonoBehaviour
{
    public ItemSO ItemSO;
    public SpriteRenderer sr;

    public int quantity;
    public Animator animator;
    public static event Action<ItemSO, int> OnLootCollected;

    private void OnValidate()
    {
        if (ItemSO == null)
            return;
        {
            sr.sprite = ItemSO.itemIcon;
            this.name = ItemSO.itemName;
        }
    }
}
