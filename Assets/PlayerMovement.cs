using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerSpeed;

    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            {
                myRigidbody2D.velocity = new Vector2(PlayerSpeed, myRigidbody2D.velocity.y);

            }
        }
        if (moveHorizontal < 0)
        {
            myRigidbody2D.velocity = new Vector2(-PlayerSpeed, myRigidbody2D.velocity.y);
        }
    }
}
