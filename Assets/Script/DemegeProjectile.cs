using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemegeProjectile : MonoBehaviour
{
    public int demege;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            print("Hit Enemy");
        }
        if (collision.collider.GetComponent<Enemy>())
        {
            print("Hit Enemy");
        }

    }
}
