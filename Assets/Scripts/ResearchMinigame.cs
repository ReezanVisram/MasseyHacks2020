using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMinigame : MonoBehaviour
{
    public GameObject virus;

    private List<Transform> viruses = new List<Transform>();

    private float speed = 1f;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < 3; row++) {
            for (int col = -4; col < 4; col++) {
                viruses.Add(virus.transform);
                Instantiate(virus, new Vector3(col + 1, row + 3, 0), Quaternion.identity);
            }
        }
        ApplicationModel.wentToResearch = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
