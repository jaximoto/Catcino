using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StatManager : MonoBehaviour
{
    public static StatManager instance;

    [Header("Player Stats")]
    public int luck;
    public int cautuion;
    public int perception;

    public float mulitplier = 1.0f;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateLuck(int amount)
    {
        luck += amount;
    }
    public void UpdateCaution(int amount)
    {
        cautuion += amount;
    }
    public void UpdatePerception(int amount)
    {
        perception += amount;
    }
    


}