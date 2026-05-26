using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelManger : MonoBehaviour
{
    public static levelManger main;
    public Transform startPoint;

    public Transform[] path;



    public int currency;
    public int lives;


    private void Awake()
    {
        main = this;
    }


    private void Start()
    {
        currency = 100;
        lives = 20;
    }

   

    public void GainCurrency(int amount)
    {
        currency += amount;

    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }else return false;
    }
}
