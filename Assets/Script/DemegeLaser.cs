using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemegeLaser : MonoBehaviour
{
    bool cdAtt;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (!cdAtt)
            {
                cdAtt = true;
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    Player.instance.HitPlayer(5);
                    yield return new WaitForSeconds(0.2f);
                    cdAtt = false;
                }
            }
        }
    }
}
