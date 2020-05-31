using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VaccineClass;

public class VaccineManager : MonoBehaviour
{
    public Text vaccineTitle;
    public Text vaccineInfo;
    public Text vaccineCostText;

    public int vaccineCost;

    public GameObject vaccinePanel;
    public GameObject progressPanel;

    public GameObject dnaButton;

    public GameObject gameManager;
    private Money money;

    public Vaccine currVaccine = null;

    private int currVaccineType;
    private int[] extraIngredients = {-1, -1, -1};

    private bool vaccineFinished = false;

    void Start() {
        gameManager = GameObject.Find("GameManager");
        money = gameManager.GetComponent<Money>();

        if (ApplicationModel.researchedDna) {
            dnaButton.SetActive(true);
        }
    }

    public void DisplayInfo(GameObject sender) {
        if (sender.name == "LiveAttenuatedButton") {
            vaccineTitle.text = "Live Attenuated Vaccine:";
            vaccineInfo.text = "Uses a weakened virus to triggern an immune response. Most effective but also has the highest risk of infection from the actual vaccine.";
        } else if (sender.name == "InactivatedButton") {
            vaccineTitle.text = "Inactivated Virus Vaccine:";
            vaccineInfo.text = "Uses a dead virus to trigger an immune response. Less effective than a Live Attenuated virus but also has a lower risk.";
        } else if (sender.name == "PolysaccharideButton") {
            vaccineTitle.text = "Subunit Vaccine:";
            vaccineInfo.text = "Uses a viral component to trigger an immune response. Effectiveness varies, but virtually no risk of infection.";
        } else if (sender.name == "ToxinButton") {
            vaccineTitle.text = "Toxoid Vaccine:";
            vaccineInfo.text = "Uses a virus-produced toxin to triggern an immune response. Can be risky depending on dose of toxin.";
        } else if (sender.name == "DNAButton") {
            vaccineTitle.text = "DNA Vaccine: ";
            vaccineInfo.text = "Uses the virus's Deoxyribonucleic Acid to trigger an immune response. A relatively new technology";
        }
    }

    public void DetermineVaccineType(GameObject sender) {
        if (sender.name == "LiveAttenuatedButton") {
            currVaccineType = 1;
            vaccineCost = 400000;
            vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
        } else if (sender.name == "InactivatedButton") {
            currVaccineType = 2;
            vaccineCost = 200000;
            vaccineCostText.text = "Cost: $" + vaccineCost / 10000.0f + "K";
        } else if (sender.name == "PolysaccharideButton") {
            currVaccineType = 3;
            vaccineCost = 600000;
            vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
        } else if (sender.name == "ToxinButton") {
            currVaccineType = 4;
            vaccineCost = 300000;
            vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
        } else if (sender.name == "DNAButton") {
            currVaccineType = 4;
            vaccineCost = 800000;
            vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
        }
    }

    public void AddAluminum() {
        extraIngredients[0] = 1;
        vaccineCost += 50000;
        vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
    }

    public void AddGelatin() {
        extraIngredients[1] = 2;
        vaccineCost += 250000;
        vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
    }

    public void AddFormaldehyde() {
        extraIngredients[2] = 3;
        vaccineCost += 80000;
        vaccineCostText.text = "Cost: $" + vaccineCost / 1000.0f + "K";
    }

    public void ClearInfo() {
        vaccineTitle.text = "";
        vaccineInfo.text = "";
    }

    public void CreateVaccine() {
        if (money.currentMoney - vaccineCost > 0) {
            Debug.Log(money.currentMoney - vaccineCost);
            money.currentMoney -= vaccineCost;
            vaccinePanel.SetActive(false);
            progressPanel.SetActive(true);
            currVaccine = new Vaccine(currVaccineType, extraIngredients);
        } else {
            Debug.Log("Not enough money!");
        }
    }
}
