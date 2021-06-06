using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReadOuts : MonoBehaviour
{
    public Text balanceText;
    public Text lastWinText;
    public Text denominationText;
    public MoneyValues values;
    // Start is called before the first frame update
    void Start()
    {
        balanceText.text = "$" + values.balance;
        lastWinText.text = "$" + values.lastWin;
        denominationText.text = "$" + values.denomination[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
