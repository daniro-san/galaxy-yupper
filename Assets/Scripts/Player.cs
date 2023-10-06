using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.0f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.4f;
    private float _nextFire = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
        FireLaser();
    }

    private void FireLaser()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.91f, 0), Quaternion.identity);

            _nextFire = Time.time + _fireRate;
        }
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _playerSpeed * Time.deltaTime);

        RestrainPlayerPosition();
    }

    private void RestrainPlayerY()
    {
        if (transform.position.y > 0)
        {
            transform.position = new Vector2(transform.position.x, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector2(transform.position.x, -4.2f);
        }
    }

    private void RestrainPlayerX()
    {
        if (transform.position.x > 9.0f)
        {
            transform.position = new Vector2(-9.0f, transform.position.y);
        }
        else if (transform.position.x < -9.0f)
        {
            transform.position = new Vector2(9.0f, transform.position.y);
        }
    }

    private void RestrainPlayerPosition()
    {
        RestrainPlayerY();
        RestrainPlayerX();
    }
}
