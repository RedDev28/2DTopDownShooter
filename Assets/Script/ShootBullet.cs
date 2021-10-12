using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    public ParticleSystem enemyDead;
    public float speed = 5f;
    public float recoil = 3f;
    public float destroyBulletTime = 3f;
    public float shakeTime = 1f;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletRb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait(destroyBulletTime));
    }

    private IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(this.gameObject);
    }

    private IEnumerator bulletHit(Collision2D enemy)
    {
        yield return new WaitForSeconds(0);
        Destroy(this.gameObject);
        Destroy(enemy.gameObject);
        Instantiate(enemyDead, enemy.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(bulletHit(collision));
        }
    }
}
