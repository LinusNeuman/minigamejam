using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerSpeed;

    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        Vector2 axisMovement = Vector2.zero;
        axisMovement.x = Input.GetAxis("Horizontal");
        axisMovement.y = Input.GetAxis("Vertical");

        myRigidbody2D.velocity = axisMovement * PlayerSpeed;
        animator.SetFloat("speed", myRigidbody2D.velocity.magnitude);

    }
}
