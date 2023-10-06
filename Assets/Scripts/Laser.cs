using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 10.0f;

    // Update is called once per frame
    private void Update()
    {
        LaserMovement();
    }

    private void LaserMovement()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y >= 5.5f)
        {
            Destroy(gameObject);
        }
    }
}
