using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveVirus : MonoBehaviour
{
    public float speed = 1f;
    public int direction = 1;

    public float maxLeft;
    public float maxRight;

    private float timer = 0.0f;

    public GameObject coronaProjectile;

    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name != "FinishTrigger") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        } else {
            ApplicationModel.wonGame = false;
            SceneManager.LoadScene("MainGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);

        if (transform.position.x > maxLeft || transform.position.x < maxRight) {
            direction = -direction;
            transform.Translate(0, -1, 0);
            speed += 1;
        }
    }
}
