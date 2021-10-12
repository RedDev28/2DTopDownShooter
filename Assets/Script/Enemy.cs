using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private GameObject home;

    // Start is called before the first frame update
    void Start()
    {
        home = GameObject.Find("Home");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, home.transform.position, speed * Time.deltaTime);
    }
}
