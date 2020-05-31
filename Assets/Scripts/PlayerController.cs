using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 1f;

    public int doseSize = 3;

    private int numVirusesLeft;

    private int currDoses = 3;
    // Start is called before the first frame update
    void Start()
    {
        currDoses = doseSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown("space") && currDoses > 0) {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            currDoses -= 1;
        }

        if (Input.GetKeyDown("r")) {
            currDoses = doseSize;
        }

        if (GameObject.Find("Coronavirus(Clone)")) {
            ;
        } else {
            Debug.Log("You win!");
            ApplicationModel.wonGame = true;
            SceneManager.LoadScene("MainGame");
        }
    }
}
