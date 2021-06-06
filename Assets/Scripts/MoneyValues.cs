using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyValues : MonoBehaviour
{
    public TextReadOuts textReadOuts;
    public float balance = 10.00f;
    public float lastWin = 0.00f;
    public float[] denominations = {.25f,.50f,1.00f,5.00f};
    [HideInInspector]
    public float currentDemonination;
    [HideInInspector]
    public int currentDemoninationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.currentDemonination = denominations[currentDemoninationIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// increments the denomination index
    /// </summary>
    public void Increment()
    {
        if(currentDemoninationIndex < denominations.Length-1)
        {
            this.currentDemoninationIndex++;
            this.currentDemonination = this.denominations[this.currentDemoninationIndex];
        }
    }

    /// <summary>
    /// decrements the denomination index
    /// </summary>
    public void Decrement()
    {
        if(currentDemoninationIndex > 0)
        {
            this.currentDemoninationIndex--;
            this.currentDemonination = this.denominations[this.currentDemoninationIndex];
        }
    }

    /// <summary>
    /// adds an amount to the winnings
    /// </summary>
    /// <param name="addAmt">amount to be added</param>
    public void AddWinnings(float addAmt)
    {
        this.lastWin += addAmt;
        textReadOuts.UpdateWinningsText();
    }

    /// <summary>
    /// adds an amount to the balance
    /// </summary>
    /// <param name="addAmt">amount to be added</param>
    public void AddBalance(float addAmt)
    {
        this.balance += addAmt;
        textReadOuts.UpdateBalanceText();
    }
    /// <summary>
    /// takes off the current denomination from the balance
    /// </summary>
    public void SubBalance()
    {
        this.balance -= currentDemonination;
        textReadOuts.UpdateBalanceText();
    }
    /// <summary>
    /// resets last win to 0
    /// </summary>
    public void ResetWinnings()
    {
        this.lastWin = 0;
        textReadOuts.UpdateWinningsText();
    }
}
