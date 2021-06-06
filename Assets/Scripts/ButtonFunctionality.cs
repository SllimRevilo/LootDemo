using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionality : MonoBehaviour
{
    public Button playButton;
    public Button incrementButton;
    public Button decrementButton;
    public MoneyValues moneyValues;
    public TextReadOuts textReadOuts;
    public Winnings winnings;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDecrementButton();
        UpdateIncrementButton();
        UpdatePlayButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        moneyValues.Increment();
        textReadOuts.UpdateDenominationText();
        UpdateDecrementButton();
        UpdateIncrementButton();
    }
    public void Decrement()
    {
        moneyValues.Decrement();
        textReadOuts.UpdateDenominationText();
        UpdateDecrementButton();
        UpdateIncrementButton();
    }

    public void Play()
    {
        winnings.DivideAmongChests();
        UpdatePlayButton();
    }

    public void UpdateIncrementButton()
    {
        if(moneyValues.currentDemoninationIndex >= moneyValues.denominations.Length-1)
        {
            incrementButton.interactable = false;
        }
        else
        {
            incrementButton.interactable = true;
        }
    }

    public void UpdateDecrementButton()
    {
        if(moneyValues.currentDemoninationIndex <= 0)
        {
            decrementButton.interactable = false;
        }
        else
        {
            decrementButton.interactable = true;
        }
    }

    public void UpdatePlayButton()
    {
        
        if(moneyValues.balance < moneyValues.currentDemonination)
        {
            Debug.Log(moneyValues.balance + " balance and make false");
            playButton.interactable = false;
        }
        else
        {
            Debug.Log("good");
            playButton.interactable = true;
        }
        if(winnings.chestValues.Count >0)
        {
            Debug.Log(winnings.chestValues.Count + " count and make false");
            playButton.interactable = false;
        }
    }
}
