using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public bool active = true;
    public bool attack;
    public int maxHp = 100;
    float hp;

    public float speedAtt = 3;
    [SerializeField] Transform range;

    [SerializeField] Transform rotateMesh;
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] GameObject dropHPPrefab;

    [SerializeField] ParticleSystem particle1;
    [SerializeField] ParticleSystem particle2;


    public void Set(int maxHPValue, int demegeValue)
    {
        maxHp = maxHPValue;
        demege = demegeValue;

        hp = maxHp;
        bar.fillAmount = hp / maxHp;
        hpText.text = hp.ToString();
    }
    private void Update()
    {
        if (!active) return;

        if (Vector3.Distance(transform.position, Player.instance.transform.position) < range.localScale.x / 2)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack)
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
                        yield return new WaitForSeconds(speedAtt);
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

        AudioManager.instance.ProjectileEnemySFX();

    }

    public void Hit(int value)
    {
        hp -= value;

        bar.fillAmount = hp / maxHp;
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            Instantiate(dropHPPrefab, transform.position, Quaternion.identity);


            particle1.Play();
            particle2.Play();

            Destroy(particle1.gameObject, 2f);
            Destroy(particle2.gameObject, 2f);

            particle1.transform.parent = null;
            particle2.transform.parent = null;

            Destroy(gameObject, 0.1f);

        }
    }
}
