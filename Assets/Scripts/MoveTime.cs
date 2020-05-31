using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTime : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public int day = 0;
    public int week = 0;
    private int dayThreshold = 60;
    private int timeInDay = 0;

    private int currSpeed = 0;

    public Slider daySlider;
    public Text sliderText;

    public GameObject vaccineManagerObject;

    public GameObject vaccineFailedPanel;
    public Text vaccineFailedInformation;

    public GameObject vaccineSuccessPanel;

    public Slider developmentSlider;
    public Slider phase1Slider;
    public Slider phase2Slider;
    public Slider phase3Slider;

    public VaccineManager vaccineManager;

    public GameObject progressPanel;

    GameObject gameManager;

    Money money;

    private void Speed1() {
        timeInDay += 1;
    }

    private void Speed2() {
        timeInDay += 2;
    }

    private void Speed3() {
        timeInDay += 3;
    }

    private void SetSliderVal() {
        daySlider.value = timeInDay;
    }

    private void UpdateSliderText() {
        sliderText.text = "W" + week + "D" + day;
    }


    public void Pause() {
        currSpeed = 0;
    }

    public void SetSpeed1() {
        currSpeed = 1;
    }

    public void SetSpeed2() {
        currSpeed = 2;
    }

    public void SetSpeed3() {
        currSpeed = 3;
    }

    void Start() {
        vaccineManager = vaccineManagerObject.GetComponent<VaccineManager>();

        gameManager = GameObject.Find("GameManager");

        money = gameManager.GetComponent<Money>();

        if (ApplicationModel.wentToResearch) {
            day = PersistInformation.days;
            week = PersistInformation.weeks;

            if (PersistInformation.currVaccine != null) {
                vaccineManager.currVaccine = PersistInformation.currVaccine;
                progressPanel.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (currSpeed == 1) {
            Speed1();
        } else if (currSpeed == 2) {
            Speed2();
        } else if (currSpeed == 3) {
            Speed3();
        }

        SetSliderVal();
        UpdateSliderText();

        if (timeInDay > dayThreshold) {
            day += 1;
            if (vaccineManager.currVaccine != null) {
                if (!vaccineManager.currVaccine.vaccineFailed) {
                    if (!vaccineManager.currVaccine.finishedDevelopment) {
                        vaccineManager.currVaccine.IncreaseProgress();
                        developmentSlider.value = vaccineManager.currVaccine.progressMade;
                    } else {
                        if (!vaccineManager.currVaccine.finishedPhase1) {
                            vaccineManager.currVaccine.Phase1();
                            phase1Slider.value = vaccineManager.currVaccine.phase1Days;
                        } else {
                            if (!vaccineManager.currVaccine.finishedPhase2) {
                                vaccineManager.currVaccine.Phase2();
                                phase2Slider.value = vaccineManager.currVaccine.phase2Days;
                            } else {
                                if (!vaccineManager.currVaccine.productionReady) {
                                    vaccineManager.currVaccine.Phase3();
                                    phase3Slider.value = vaccineManager.currVaccine.phase3Days;
                                } else {
                                    vaccineSuccessPanel.SetActive(true);
                                    Pause();
                                }
                            }
                        }
                    }
                } else {
                    vaccineFailedPanel.SetActive(true);
                    if (vaccineManager.currVaccine.phase1Days < vaccineManager.currVaccine.phase1DaysRequired) {
                        if (rand.Next(2) == 0) {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 1. The monkeys you were testing with became infected with COVID-19. Try a different vaccine type or different ingredients to see if they produce a different immune response. You have been granted $300K for 1 more attempt.";
                        } else {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 1. The monkeys you were testing on fell ill due to something in your vaccine. Try a different type or different extra ingredients to try and minizime side effects. You have been granted $300K for 1 more attempt.";
                        }
                        money.currentMoney += 300000;
                    } else if (vaccineManager.currVaccine.phase2Days < vaccineManager.currVaccine.phase2DaysRequired) {
                        if (rand.Next(2) == 0) {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 2. The limited amount of humans you were testing your vaccine on fell victim to COVID-19. Try a different type of vaccine or different ingredients to see if they produce a different immune response. Due to your vaccine's success in animals, the government is granting you an additional $1M to continue developing your vaccine.";
                        } else {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 2. The humans you were testing on complained of too many adverse side effects, and so your vaccine will not be approved. Try a different approach. Due to your vaccine's success in animals, the government is granting you an additional $1M to continue developing your vaccine.";
                        }
                        money.currentMoney += 1000000;

                    } else {
                        if (rand.Next(2) == 0) {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 3. The limited amount of humans you were testing your vaccine on fell victim to COVID-19. Try a different type of vaccine or different ingredients to see if they produce a different immune response. Due to your vaccine's success in early trials, the government is granting you an additional $2M to continue developing your vaccine.";
                        } else {
                            vaccineFailedInformation.text = "Your vaccine failed in Phase 3. The humans you were testing on complained of too many adverse side effects, and so your vaccine will not be approved. Try a different approach. Due to your vaccine's success in early trials, the government is granting you an additional $2M to continue developing your vaccine.";
                        }
                        money.currentMoney += 2000000;
                    }
                    Pause();
                    vaccineManager.currVaccine = null;
                }
            }

            timeInDay = 0;
        }

        if (day > 7) {
            week += 1; 
            day = 0;
        }

    }
}
