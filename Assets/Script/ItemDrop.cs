using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Player>())
        {
            particle.Play();
            Destroy(particle.gameObject, 3);
            particle.transform.parent = null;
            Player.instance.hp = Player.instance.maxHp;
            Player.instance.UpdateUI();
            Destroy(gameObject);

        }
    }
}
