using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenActionsPanel : MonoBehaviour
{
    public GameObject actionPanel;
    public GameObject vaccinePanel;
    public GameObject researchPanel;

    public GameObject vaccineFailedPanel;

    public GameObject vaccineSuccessPanel;

    public void OpenActionPanel() {
        if (actionPanel != null) {
            actionPanel.SetActive(true);
        }
    }

    public void CloseActionPanel() {
        if (actionPanel != null) {
            actionPanel.SetActive(false);
        }
    }


    public void OpenVaccinePanel() {
        if (vaccinePanel != null) {
            vaccinePanel.SetActive(true);
            actionPanel.SetActive(false);
        }
    }

    public void CloseVaccinePanel() {
        if (vaccinePanel != null) {
            vaccinePanel.SetActive(false);
        }
    }

    public void CloseFailedPanel() {
        if (vaccineFailedPanel != null) {
            vaccineFailedPanel.SetActive(false);
        }
    }

    public void CloseSuccessPanel() {
        if (vaccineSuccessPanel != null) {
            vaccineSuccessPanel.SetActive(false);
        }
    }

    public void CloseReasearchPanel() {
        researchPanel.SetActive(false);
    }
}
