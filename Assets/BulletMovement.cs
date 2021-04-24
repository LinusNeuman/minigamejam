using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.velocity.Set(BulletSpeed, BulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
