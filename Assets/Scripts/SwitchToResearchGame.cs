using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToResearchGame : MonoBehaviour
{
    public GameObject gameManager;

    public MoveTime moveTime;
    public Money money;
    public GameObject researchPanel;
    void Start() {
        if (ApplicationModel.wentToResearch) {
            researchPanel.SetActive(true);
        }
        gameManager = GameObject.Find("GameManager");
        moveTime = gameManager.GetComponent<MoveTime>();
        money = gameManager.GetComponent<Money>();
    }
    public void SwtichToResearch() {
        PersistInformation.days = moveTime.day;
        PersistInformation.weeks = moveTime.week;
        PersistInformation.currVaccine = moveTime.vaccineManager.currVaccine;
        PersistInformation.currentMoney = money.currentMoney;
        SceneManager.LoadScene("ResearchScene");
    }
}
