using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;

    [SerializeField]
    [Range(0, 1f)]
    private float bulletSpawnOffset = 0.5f;

    Vector3 myTargetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myTargetPosition = Input.mousePosition;
            myTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(myTargetPosition.x, myTargetPosition.y, 0.0f));

            var aimDirection = (myTargetPosition - transform.position).normalized;

            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector3 position = transform.position;
            position += aimDirection * bulletSpawnOffset;

            GameObject gameObj = Instantiate(Bullet, position, rotation);
        }
    }
}
