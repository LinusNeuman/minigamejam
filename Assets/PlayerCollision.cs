using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private static string BULLET_TAG = "Bullet";

    [SerializeField]
    private PlayerShoot playerShoot;

    private bool catchTheBullet = false;
    private GameObject bullet;

    [SerializeField]
    private float catchTime = 0.2f;

    [SerializeField]
    private float catchCooldown = 1f;

    private float lastCatchTime = -100f;

    [SerializeField]
    private GameObject bulletCatchIndicator;

    public Rigidbody2D[] bodyparts;

    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time > catchCooldown + lastCatchTime)
            {
                SetBulletCatcher();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(BULLET_TAG))
        {
            bullet = collision.transform.gameObject;
            HitByBullet();
        }
    }

    private void HitByBullet()
    {
        if (catchTheBullet)
        {
            CatchTheBullet();
        }

        else
        {
            Death();
        }
    }

    private void Death()
    {

        animator.enabled = false;

        foreach (var part in bodyparts)
        {
            part.simulated = true;
            part.AddForce(new Vector2(Random.Range(-1, 1f), Random.Range(-1f, 1f)) * 500);
        }
        //TOTO: Death stuff;
        print("You died lol");
    }

    private void CatchTheBullet()
    {
        Destroy(bullet);
        playerShoot.AddBullet();
    }

    public void SetBulletCatcher()
    {
        lastCatchTime = Time.time;
        bulletCatchIndicator.SetActive(true);
        catchTheBullet = true;
        StartCoroutine(BulletTimer());
    }

    private IEnumerator BulletTimer()
    {
        yield return new WaitForSeconds(catchTime);
        catchTheBullet = false;
        bulletCatchIndicator.SetActive(false);
    }
}
