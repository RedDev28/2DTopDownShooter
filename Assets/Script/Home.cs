using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private Animator cameraAnim;
    private Data data;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        cameraAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        data = GameObject.Find("Data Container").GetComponent<Data>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            data.health--;
            Destroy(collision.gameObject);
            cameraAnim.SetTrigger("canShake");
            audioManager.explodeSound.gameObject.SetActive(true);
        }

        else
        {
            audioManager.explodeSound.gameObject.SetActive(false);
        }
    }
}
