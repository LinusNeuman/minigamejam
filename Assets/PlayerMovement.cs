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
        Vector2 axisMovement = Vector2.zero;
        axisMovement.x = Input.GetAxis("Horizontal");
        axisMovement.y = Input.GetAxis("Vertical");

        myRigidbody2D.velocity = axisMovement * PlayerSpeed;
    }
}
