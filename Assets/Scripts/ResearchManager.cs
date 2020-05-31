using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
    public Text researchTitle;
    public Text researchInfo;
    
    GameObject gameManager;

    Money money;


    // Start is called before the first frame update
    void OnEnable()
    {
        gameManager = GameObject.Find("GameManager");

        money = gameManager.GetComponent<Money>();

        if (ApplicationModel.wonGame) {
            researchTitle.text = "You Completed Research!";
            if (!ApplicationModel.researchedDna) {
                ApplicationModel.researchedDna = true;

                researchInfo.text = "You completed research and unlocked the DNA Vaccine type!";
            } else {
                researchInfo.text = "You completed research and earned $500K to continue developing a vaccine!";
                money.currentMoney += 500000;
            }
        } else {
            researchTitle.text = "Research failed";
            researchInfo.text = "Try again using what you've learned!";
        }

    }

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
