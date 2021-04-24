using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarObjectiveLogic : MonoBehaviour
{
    private ObjectiveTracker myObjectiveTracker;

    // Start is called before the first frame update
    void Start()
    {
        myObjectiveTracker = FindObjectOfType<ObjectiveTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            myObjectiveTracker.ObjectiveCompleted(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
