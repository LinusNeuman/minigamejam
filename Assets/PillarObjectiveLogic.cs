using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarObjectiveLogic : MonoBehaviour
{
    private ObjectiveTracker myObjectiveTracker;

    private AudioSource myAudioSource;

    ParticleSystem myParticleSystem;

    bool IsCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        myObjectiveTracker = FindObjectOfType<ObjectiveTracker>();

        myAudioSource = GetComponent<AudioSource>();

        myParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsCompleted)
            return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            myObjectiveTracker.ObjectiveCompleted(gameObject);
            myAudioSource.Play();
            myParticleSystem.Play();
            IsCompleted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
