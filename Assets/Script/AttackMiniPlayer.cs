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
        CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
        CanvasGameplay.instance.attackButton.interactable = true;
    }
    public void Attack()
    {
        if (cd <= 0)
        {
            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                cd = maxCD;
                CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
                CanvasGameplay.instance.attackButton.interactable = false;
                while (cd > 0)
                {
                    cd -= Time.deltaTime;
                    CanvasGameplay.instance.cdAttack.fillAmount = cd / maxCD;
                    if (cd <= 0)
                    {
                        CanvasGameplay.instance.attackButton.interactable = true;
                    }
                    yield return null;
                }
            }
        }

    }
}
