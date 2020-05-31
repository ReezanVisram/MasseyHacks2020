using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int startingMoney = 1000000;
    
    public Text balance;

    public int currentMoney = 1000000;

    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationModel.wentToResearch) {
            currentMoney = PersistInformation.currentMoney;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMoney >= Mathf.Pow(10, 6)) {
            balance.text = "$" + currentMoney / Mathf.Pow(10, 6) + "M";
        }  else if (currentMoney >= Mathf.Pow(10, 3)) {
            balance.text = "$" + currentMoney / Mathf.Pow(10, 3) + "K";
        } else {
            balance.text = "$" + currentMoney;
        }
    }
}
