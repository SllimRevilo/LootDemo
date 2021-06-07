using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReadOuts : MonoBehaviour
{
    public Text balanceText;
    public Text lastWinText;
    public Text denominationText;
    public GameObject displayAmountPanel;
    public Text displayAmountText;
    public MoneyValues values;
    /// <summary>
    /// inits texts
    /// </summary>
    void Start()
    {
        balanceText.text = "$" + values.balance.ToString("0.00");
        lastWinText.text = "$" + values.lastWin.ToString("0.00");
        denominationText.text = "$" + values.currentDemonination.ToString("0.00");
    }

    /// <summary>
    /// opens the amount won for a second
    /// </summary>
    /// <param name="amount"> amount to display or negative to display better luck</param>
    /// <returns>waiting a second</returns>
    public IEnumerator DisplayAmount(float amount)
    {
        Debug.Log("display");
        if(amount>0)
        {
            displayAmountText.text = "The chest contained $" + amount.ToString("0.00");
        }
        else
        {
            displayAmountText.text = "Better luck next time";
        }
        displayAmountPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        displayAmountPanel.SetActive(false);
    }
    /// <summary>
    /// changes the denomination text
    /// </summary>
    public void UpdateDenominationText()
    {
        denominationText.text = "$" + values.currentDemonination.ToString("0.00");
    }
    /// <summary>
    /// changes the winnings text
    /// </summary>
    public void UpdateWinningsText()
    {
        lastWinText.text = "$" + values.lastWin.ToString("0.00");
    }
    /// <summary>
    /// changes the balance text
    /// </summary>
    public void UpdateBalanceText()
    {
        balanceText.text = "$" + values.balance.ToString("0.00");
    }
}
