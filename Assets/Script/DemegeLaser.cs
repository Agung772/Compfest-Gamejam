using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemegeLaser : MonoBehaviour
{
    bool cdAtt;
    public int demege = 5;
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
                    Player.instance.HitPlayer(demege);

                    AudioManager.instance.TerkenaHitSFX();
                    yield return new WaitForSeconds(0.2f);
                    cdAtt = false;
                }
            }
        }
    }
}
