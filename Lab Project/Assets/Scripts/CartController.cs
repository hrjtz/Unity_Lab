using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public bool isBeingDamaged;
    private float verticalInput;
    private float horizontalInput;

    public float distanceFromCartx;
    public float cartRangex = 3;

    public float distanceFromCartz;
    public float cartRangez = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Enemy"))
        {
            isBeingDamaged = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (CompareTag("Enemy"))
        {
            isBeingDamaged = false;
        }
    }

    private void Moving()
    {
        if (!isBeingDamaged)
        {
            Distance();
        }
    }

    private void Distance()
    {
        distanceFromCartx = player.transform.position.x - transform.position.x;

        if (distanceFromCartx > cartRangex)
        {
            transform.position = new Vector3(player.transform.position.x - cartRangex, transform.position.y, transform.position.z);
        }

        if (distanceFromCartx < -cartRangex)
        {
            transform.position = new Vector3(player.transform.position.x + cartRangex, transform.position.y, transform.position.z);
        }

        distanceFromCartz = player.transform.position.z - transform.position.z;

        if (distanceFromCartz > cartRangez)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - cartRangez);
        }

        if (distanceFromCartz < -cartRangez)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + cartRangez);
        }
    }


}
