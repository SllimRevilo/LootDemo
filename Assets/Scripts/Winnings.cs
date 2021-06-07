using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnings : MonoBehaviour
{
    public GameManager gameManager;   
    public bool foundPooper = true;
    
    public int[] commonMulitplers = {0};
    public int[] rareMultipliers = {1,2,3,4,5,6,7,8,9,10};
    public int[] epicMultipliers = {12,16,24,32,48,64};
    public int[] legendaryMultipliers = {100,200,300,400,500};
    public MoneyValues moneyValues;

    // these four need to add to 100
    public int commonChance = 50;
    public int rareChance = 30;
    public int epicChance = 15;
    public int legendaryChance = 5;

    public List<float> chestValues;
    public ButtonFunctionality buttonFunctionality;
    private float currentWin = 0;

    /// <summary>
    /// init chest values
    /// </summary>
    public void Start()
    {
        chestValues = new List<float>();
    }

    /// <summary>
    /// gets the roll mulitplier 
    /// </summary>
    /// <returns>the roll multiplier</returns>
    public int GetRollMultiplier()
    {
        // random value between 1-100
        int randomVal = Random.Range(1,101);
        if(randomVal <= commonChance)
        {
            int randChanceVal = Random.Range(0,commonMulitplers.Length);
            return commonMulitplers[randChanceVal];

        }
        else if(randomVal <= commonChance + rareChance)
        {
            int randChanceVal = Random.Range(0,rareMultipliers.Length);
            return rareMultipliers[randChanceVal];
        }
        else if(randomVal <= commonChance + rareChance + epicChance)
        {
            int randChanceVal = Random.Range(0,epicMultipliers.Length);
            return epicMultipliers[randChanceVal];
        }
        else if(randomVal <= commonChance + rareChance + epicChance + legendaryChance)
        {
            int randChanceVal = Random.Range(0,legendaryMultipliers.Length);
            return legendaryMultipliers[randChanceVal];
        }
        else
        {
            Debug.Log("Error chances are incorrect");
        }
        //error case
        return -1;
    }


    /// <summary>
    /// splits the total amount earned into the chests
    /// </summary>
    public void DivideAmongChests()
    {
        this.ResetChestValues();
        moneyValues.SubBalance();
        moneyValues.ResetWinnings();

        int numChests = 0;
        float leftOver = this.GetRollMultiplier() * moneyValues.currentDemonination;
        this.currentWin = leftOver;


        // used to get number of chests
        // ideally this would not be hardcoded but the numbers are highly experimental
        // and only used here so I wanted to save time so i kept as is
        if(leftOver == 0)
        {
            numChests = 0;
            return;
        }
        else if(leftOver <10)
        {
            numChests = Random.Range(1,4);
        }
        else if(leftOver <50)
        {
            numChests = Random.Range(3,6);
        }
        else if(leftOver <100)
        {
            numChests = Random.Range(4,7);
        }
        else if(leftOver <250)
        {
            numChests = Random.Range(5,9);
        }
        else
        {
            numChests = Random.Range(6,9);
        }

        while(this.chestValues.Count < numChests-1)
        {
            //gets random amount between .05 and max but takes away the 2 decimals
            float upperLimit = leftOver*.75f;
            leftOver = leftOver*.25f;
            float randAmount = Random.Range(5f,upperLimit*100f);
            //finds amount to subtract to make sure its divisible by .05
            float firstValMod = randAmount/100f % .05f; 
            // amount that is divisible by 5
            float firstVal = randAmount/100f - firstValMod;

            this.chestValues.Add(firstVal);
            leftOver += upperLimit - firstVal;
        }
        float currAmt =0;
        foreach (float chest in chestValues)
        {
            currAmt += chest;
        }
        // fixes issues with last value being slightly off
        float lastVal = this.currentWin-currAmt;
        lastVal= (float)System.Math.Round(lastVal,2);
        this.chestValues.Add(lastVal);
        buttonFunctionality.UpdatePlayButton();


    }

    /// <summary>
    /// Resets the value of the chests and the current win
    /// </summary>
    public void ResetChestValues()
    {
        this.chestValues.Clear();
        this.currentWin = 0;
        this.foundPooper = false;
        this.gameManager.ResetChests();
    }

    /// <summary>
    /// gets a randomm number from the winnings and adds it to the winnings total and balance total
    /// </summary>
    public void GetWinnings()
    {
        if(chestValues.Count <= 0)
        {
            // if we have done this before
            if(foundPooper)
            {
                return;
            }
            Debug.Log("change pooper to true");
            moneyValues.AddBalance(this.currentWin);
            this.foundPooper = true;
            this.buttonFunctionality.UpdateDecrementButton();
            this.buttonFunctionality.UpdateIncrementButton();
            this.buttonFunctionality.UpdatePlayButton();
            return;
        }
        int randIndex = Random.Range(0,chestValues.Count);
        float winnings = chestValues[randIndex];
        chestValues.RemoveAt(randIndex);

        moneyValues.AddWinnings(winnings);
    }
}
