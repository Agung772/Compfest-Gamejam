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
            collision.collider.GetComponent<Player>().HitPlayer(demege);
        }
        if (collision.collider.GetComponent<Enemy>())
        {
            print("Hit Enemy");
            collision.collider.GetComponent<Enemy>().Hit(demege);
        }

    }
}
