using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMiniPlayer : MonoBehaviour
{
    public static AttackMiniPlayer instance;

    public int demege;
    [SerializeField] float maxCD;
    float cd;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform point;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateUI(false);

        CanvasGameplay.instance.demegeText.text = demege.ToString();
    }
    public void Attack()
    {
        if (cd <= 0)
        {
            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(point.forward * 20, ForceMode.Impulse);
            projectile.GetComponent<DemegeProjectile>().demege = demege;

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                cd = maxCD;
                CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
                CanvasGameplay.instance.attackButton.interactable = false;

                AudioManager.instance.ProjectileRobotSFX();

                while (cd > 0)
                {
                    cd -= Time.deltaTime;
                    CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
                    if (cd <= 0)
                    {
                        CanvasGameplay.instance.attackButton.interactable = true;
                        break;
                    }
                    yield return null;
                }
            }
        }

    }

    public void UpdateUI(bool value)
    {

        if (!value)
        {
            cd = 0;
        }
        CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
        CanvasGameplay.instance.attackButton.interactable = value;

    }
}
