using UnityEngine;
[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
  public string itemName;
  [TextArea] public string itemDescription;
  public Sprite itemIcon;

  public bool isCoin;
  public int stackSize = 5;

  [Header("Item Stats")]
    public int luckBonus;
    public int cautionBonus;
    public int perceptionBonus;

  [Header("For Temporary Items")]
    public int duration;




}
