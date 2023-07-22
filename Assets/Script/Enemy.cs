using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool active;
    public int hp = 100;
    [SerializeField] Transform range;
    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < range.localScale.x / 2)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active)
        {
            var player = Player.instance.transform.position;
            Quaternion rotTarget = Quaternion.LookRotation(new Vector3(player.x, 0, player.z) - new Vector3(transform.position.x, 0, transform.position.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 300 * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, rotTarget) < 5)
            {
                if (!cdAtt)
                {
                    cdAtt = true;
                    StartCoroutine(Coroutine());
                    IEnumerator Coroutine()
                    {
                        Attack();
                        yield return new WaitForSeconds(1);
                        cdAtt = false;
                    }
                }
            }


        }
    }

    public int demege;
    bool cdAtt;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform point;
    public void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.Impulse);
        projectile.GetComponent<DemegeProjectile>().demege = demege;
    }

    public void Hit(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
