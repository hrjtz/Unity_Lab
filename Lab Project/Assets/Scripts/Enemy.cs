using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject cart;
    public float speed;
    private Vector3 cartPos;
    private Vector3 enemyPos;
    float ogspeed;
    private bool isTouchingCart;

    // Start is called before the first frame update
    void Start()
    {
        cart = GameObject.Find("Cart");
        ogspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouchingCart)
        {
            cartPos = new Vector3(cart.transform.position.x, 0, cart.transform.position.z);
            enemyPos = new Vector3(transform.position.x, 0, transform.position.z);
            enemyMovement();
        }
    }

    void enemyMovement()
    {
        Vector3 lookDirection = (cartPos - enemyPos).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cart"))
        {
            isTouchingCart = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouchingCart = false;
    }

}