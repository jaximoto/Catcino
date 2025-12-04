using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public List<SlotSymbol> symbols;

    public List<GameObject> Reels;

   public List<GameObject> Slot0;
    public List<GameObject> Slot1;
    public List<GameObject> Slot2;

    public int StartY;
    public int EndY;
    // We have 4 images on each reel, so we need at least 4 symbols
    // Use lean tween to move the reel down and have the last one loop to the top offscreen
    enum ReelState
    {
        Bets,
        Spinning,
        Stopping,
        Stopped
    }

    public  struct Slot
    {
        public GameObject reelObject;
        public List<GameObject> symbolObjects;
        public float scrollSpeed;
    };
    // have a list of 3 slot objects
    // move each object, once it ends reset it

    public List<Slot> slots = new List<Slot>();


    ReelState currentState = ReelState.Bets;
    public int currentBet = 0;

    // function to change state to 
    public void TakeBet(int betAmount)
    {
        currentState = ReelState.Bets;
        currentBet = betAmount;
        //Debug.Log("Current Bet: " + currentBet);
    }

    
    void RecycleSymbol(List<Slot> slot, S int slotIdx)
    {
        // Move to top of list
        slot.Insert(0, slot[1]);

        // Reset position
        symbol.transform.position = new Vector2(symbol.anchoredPosition.x, StartY);

        // Update image
        symbol.GetComponent<Image>().sprite = GetNextSprite();

        // Restart tween
        TweenSymbol(symbol, endY, scrollSpeed);
    }

    void TweenSymbol(RectTransform symbol, float endY, float speed, GameObject)
    {
        float distance = Mathf.Abs(symbol.anchoredPosition.y - endY);
        float duration = distance / speed;

        LeanTween.moveY(symbol, endY, duration).setOnComplete(() => {
            RecycleSymbol(symbol);
        });
    }

    public void Spin()
    {
        if (currentState != ReelState.Spinning)
            return;
        currentState = ReelState.Spinning;
        // Logic to start spinning the reel
        Debug.Log("Reel is spinning...");
        
        foreach (GameObject reel in Reels)
        {
            
            LeanTween.moveY(reel, SlotBottomPosition, .5f);
        }

    }
}
