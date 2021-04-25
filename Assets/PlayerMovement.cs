using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerSpeed;

    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource myAudioSource;

    float timeLastFootstep = 0.0f;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        if (!animator)
        {
            animator = GetComponentInChildren<Animator>();

            if (!animator)
            {
                print("Yooo there is no animator anywhere ._.");
                return;
            }

            Debug.Log("You didn't assign an animator but we found this", animator);
        }
    }

    void Update()
    {
        Vector2 axisMovement = Vector2.zero;
        axisMovement.x = Input.GetAxis("Horizontal");
        axisMovement.y = Input.GetAxis("Vertical");

        myRigidbody2D.velocity = axisMovement * PlayerSpeed;
        animator.SetFloat("speed", myRigidbody2D.velocity.magnitude);

        if (Time.time - timeLastFootstep >= 0.4f)
        {
            timeLastFootstep = Time.time;

            if (myRigidbody2D.velocity.magnitude >= 1.0f)
            {
                myAudioSource.pitch = Random.Range(0.5f, 2);
                myAudioSource.Play();
            }
        }
    }
}
