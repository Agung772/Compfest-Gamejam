using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMiniPlayer : MonoBehaviour
{
    public int demege;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform point;
    public void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
        Destroy(projectile, 5);
    }
}
