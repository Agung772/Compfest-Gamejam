using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorClose : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            animator.SetTrigger("Close");

            GameplayManager.instance.UpStage();

            Destroy(gameObject);
        }
    }
}
