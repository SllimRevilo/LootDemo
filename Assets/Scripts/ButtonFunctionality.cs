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
    public Color disableColor = new Color(195,86,54,255);
    [HideInInspector]
    public Color normalColor;

    /// <summary>
    /// sets the noaml color and updates buttons
    /// </summary>
    void Start()
    {
        this.normalColor = playButton.image.color;
        UpdateDecrementButton();
        UpdateIncrementButton();
        UpdatePlayButton();
    }

    /// <summary>
    /// increments the denomination
    /// </summary>
    public void Increment()
    {
        moneyValues.Increment();
        textReadOuts.UpdateDenominationText();
        UpdateDecrementButton();
        UpdateIncrementButton();
        UpdatePlayButton();
    }
    /// <summary>
    /// decrements the denomination
    /// </summary>
    public void Decrement()
    {
        moneyValues.Decrement();
        textReadOuts.UpdateDenominationText();
        UpdateDecrementButton();
        UpdateIncrementButton();
        UpdatePlayButton();
    }
    /// <summary>
    /// makes the game start
    /// </summary>
    public void Play()
    {
        winnings.DivideAmongChests();
        UpdatePlayButton();
        UpdateIncrementButton();
        UpdateDecrementButton();
    }
    /// <summary>
    /// updates the increment button's usability
    /// </summary>
    public void UpdateIncrementButton()
    {
        //Debug.Log("pooper is " +winnings.foundPooper);
        if(moneyValues.currentDemoninationIndex >= moneyValues.denominations.Length-1 || !winnings.foundPooper)
        {
            incrementButton.interactable = false;
            incrementButton.image.color = disableColor;
        }
        else
        {
            incrementButton.interactable = true;
            incrementButton.image.color = normalColor;

        }

    }
    /// <summary>
    /// updates the decrement button's usability
    /// </summary>
    public void UpdateDecrementButton()
    {
        if(moneyValues.currentDemoninationIndex <= 0 || !winnings.foundPooper)
        {
            decrementButton.interactable = false;
            decrementButton.image.color = disableColor;
        }
        else
        {
            decrementButton.interactable = true;
            decrementButton.image.color = normalColor;

        }

    }
    /// <summary>
    /// updates the play button's usability
    /// </summary>
    public void UpdatePlayButton()
    {
        
        if(moneyValues.balance < moneyValues.currentDemonination || !winnings.foundPooper)
        {
            //Debug.Log(moneyValues.balance + " balance and make false");
            playButton.interactable = false;
            playButton.image.color = disableColor;
        }
        else
        {
            //Debug.Log("good");
            playButton.interactable = true;
            playButton.image.color = normalColor;
        }

    }

}
