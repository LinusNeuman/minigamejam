using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    bool Locked = true;

    BoxCollider2D myBoxCollider;

    bool HasPlayerCompletedLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unlock()
    {
        Locked = false;

        // Start animating sprite upwards

        // Remove collision on box collider
        myBoxCollider.enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Locked || HasPlayerCompletedLevel)
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCompletedLevel();
        }
    }

    void PlayerCompletedLevel()
    {
        HasPlayerCompletedLevel = true;

        // Load next level
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
