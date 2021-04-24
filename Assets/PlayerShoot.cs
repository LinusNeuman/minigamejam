using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;

    Vector2 myTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myTargetPosition = Input.mousePosition;
            myTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(myTargetPosition.x, myTargetPosition.y, 0.0f));

            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector3 position = transform.position;
            position.x += 10.0f * transform.forward.x;
            position.y += 10.0f * transform.forward.y;
            GameObject gameObj = Instantiate(Bullet, position, rotation);
            Rigidbody2D bulletRigidbody = gameObj.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(transform.forward * 50.0f);
        }
    }
}
