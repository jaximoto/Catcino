using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public List<SlotSymbol> symbols;
   
    
    // We have 4 images on each reel, so we need at least 4 symbols
    // Use lean tween to move the reel down and have the last one loop to the top offscreen
    // Update is called once per frame
    void Update()
    {
        
    }
}
