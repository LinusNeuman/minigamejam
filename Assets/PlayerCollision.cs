using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public CircleCollider2D[] bodypartColliders;

    public Animator animator;

    public GameObject gameoverScreen;

    [SerializeField]
    private float gibPower = 250;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time > catchCooldown + lastCatchTime)
            {
                SetBulletCatcher();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReloadScene();
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
        ActivateGib();

        DeactivateControlls();

        gameoverScreen.SetActive(true);

        //TOTO: Death stuff;
        print("You died lol");
    }

    private void ActivateGib()
    {
        animator.enabled = false;

        foreach (var part in bodyparts)
        {
            part.simulated = true;
            part.AddForce(new Vector2(Random.Range(-1, 1f), Random.Range(-1f, 1f)) * gibPower);
        }

        foreach (var part in bodypartColliders)
        {
            part.enabled = true;
        }
    }

    private void DeactivateControlls()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;
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

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
