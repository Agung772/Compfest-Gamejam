using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorMap : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            SpawnMap.instance.Spawn();

            GameplayManager.instance.stage++;
            animator.SetTrigger("Close");
            Destroy(gameObject);
        }
    }
}
