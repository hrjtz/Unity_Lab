using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject cart;
    public float speed;
    public float cartBoundX = 3f;
    public float cartBoundZ = 2f;

    // Start is called before the first frame update
    void Start()
    {
        cart = GameObject.Find("Cart");
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    void enemyMovement()
    {
        Vector3 cartPos = new Vector3(cart.transform.position.x, 0, cart.transform.position.z);
        Vector3 enemyPos = new Vector3(transform.position.x, 0, transform.position.z);

        if (!(enemyPos.x < cartPos.x + cartBoundX && enemyPos.z < cartPos.z + cartBoundZ) | !(enemyPos.x > cartPos.x - cartBoundX && enemyPos.z > cartPos.z - cartBoundZ))
        {
            Vector3 lookDirection = (cartPos - enemyPos).normalized;
            transform.Translate(lookDirection * Time.deltaTime * speed);
        }
    }

}