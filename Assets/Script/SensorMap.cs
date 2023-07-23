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


            AudioManager.instance.TutupPinntuSFX();
            animator.SetTrigger("Close");
            Destroy(gameObject);
        }
    }
}
