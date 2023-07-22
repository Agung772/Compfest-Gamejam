using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool active;
    public int maxHp = 100;
    float hp;
    [SerializeField] Transform range;

    [SerializeField] Transform rotateMesh;
    [SerializeField] Image bar;

    private void Start()
    {
        hp = maxHp;
        bar.fillAmount = hp / maxHp;
    }
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
            Quaternion rotTarget = Quaternion.LookRotation(new Vector3(player.x, 0, player.z) - new Vector3(rotateMesh.position.x, 0, rotateMesh.position.z));
            rotateMesh.rotation = Quaternion.RotateTowards(rotateMesh.rotation, rotTarget, 300 * Time.deltaTime);

            if (Quaternion.Angle(rotateMesh.rotation, rotTarget) < 3)
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
        projectile.GetComponent<Rigidbody>().AddForce(point.forward * 30, ForceMode.Impulse);
        projectile.GetComponent<DemegeProjectile>().demege = demege;

    }

    public void Hit(int value)
    {
        hp -= value;

        bar.fillAmount = hp / maxHp;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
