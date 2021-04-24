using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GateController : MonoBehaviour
{
    bool Locked = true;

    [SerializeField]
    float GateEndPositionY;

    [SerializeField]
    AudioClip GateOpening1;

    [SerializeField]
    AudioClip GateOpening2;

    AudioSource myAudioSource;

    GameObject myChildMovable;

    BoxCollider2D myBoxCollider;

    bool HasPlayerCompletedLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();

        myAudioSource = GetComponent<AudioSource>();

        myChildMovable = transform.GetChild(0).gameObject;
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

        myChildMovable.transform.DOLocalMoveY(GateEndPositionY, 2.0f);

        myAudioSource.clip = GateOpening1;
        myAudioSource.Play();
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
