using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeed = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * PlayerSpeed * Time.deltaTime);

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
