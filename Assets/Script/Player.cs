using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private float zRotation;
    private bool hasGun = false;
    public float yOffset = 0.5f;
    public float xOffset = 0.5f;
    private Vector2 top;
    private Vector2 down;
    private Vector2 left;
    private Vector2 right;

    private AudioManager audioManager;
    public LayerMask rayCastLayerMask;
    public Transform shootPoint;
    public GameObject bullet;
    private Rigidbody2D rb;
    private GameObject gun;
    private GameObject gunPos;
    private Animator playerAnim;
    private Data data;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GameObject.Find("Gun");
        gunPos = GameObject.Find("Gun position");
        playerAnim = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        data = GameObject.Find("Data Container").GetComponent<Data>();
    }

    private void Update()
    {
        WalkAnimation();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        mousePos.Normalize();
        zRotation = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (hasGun == true)
        {
            gun.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }

        if (Input.GetMouseButtonDown(0) && hasGun == true)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, 0, zRotation));
            audioManager.shootSound.Play();
        }

        Boudary();
    }

    void FixedUpdate()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            gun.transform.position = gunPos.transform.position;
            gun.gameObject.transform.SetParent(this.gameObject.transform);
            hasGun = true;
        }

        if (collision.gameObject.CompareTag("battery"))
        {
            speed += data.speedLimit;
            Destroy(collision.gameObject);
            audioManager.powerUpSound.Play();
        }

        if (collision.gameObject.CompareTag("Objective"))
        {
            data.hasObjective = false;
            Destroy(collision.gameObject);
            data.score += 1;
            audioManager.objectiveSound.Play();
        }
    }

    private void WalkAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetTrigger("WalkT");
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetTrigger("WalkD");
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerAnim.SetTrigger("WalkL");
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetTrigger("WalkR");
        }
    }

    private void Boudary()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(shootPoint.transform.position, Vector2.up, 12f, rayCastLayerMask);
        if (rayUp.collider.gameObject.tag == "TBoundary")
        {
            top = rayUp.point;
        }

        RaycastHit2D rayD = Physics2D.Raycast(shootPoint.transform.position, Vector2.down, 12f, rayCastLayerMask);
        if (rayD.collider.gameObject.tag == "DBoundary")
        {
            down = rayD.point;
        }

        RaycastHit2D rayL = Physics2D.Raycast(shootPoint.transform.position, Vector2.left, 20f, rayCastLayerMask);
        if (rayL.collider.gameObject.tag == "LBoundary")
        {
            left = rayL.point;
        }

        RaycastHit2D rayR = Physics2D.Raycast(shootPoint.transform.position, Vector2.right, 20f, rayCastLayerMask);
        if (rayR.collider.gameObject.tag == "RBoundary")
        {
            right = rayR.point;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DBoundary"))
        {
            this.transform.position = new Vector2(this.transform.position.x, top.y - yOffset);
        }

        if (collision.gameObject.CompareTag("TBoundary"))
        {
            this.transform.position = new Vector2(this.transform.position.x, down.y + yOffset);
        }

        if (collision.gameObject.CompareTag("LBoundary"))
        {
            this.transform.position = new Vector2(right.x - xOffset, this.transform.position.y);
        }

        if (collision.gameObject.CompareTag("RBoundary"))
        {
            this.transform.position = new Vector2(left.x + xOffset, this.transform.position.y);
        }
    }
}