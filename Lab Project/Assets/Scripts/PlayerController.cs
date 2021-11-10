using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xBound = 11.0f;
    private float zBound = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerConstraint();
    }

    // Player's movement
    void PlayerMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    // Constrains player position
    void PlayerConstraint()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
}
