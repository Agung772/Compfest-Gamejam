using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ParticleSystem efectSentuhan, projectile;
    public ParticleSystem efectSpawn;
    public ParticleSystem efectIdle;
    public ParticleSystem efectBeam;

    private void Start()
    {
        efectSpawn.Play();
        //Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;

        efectSentuhan.Play();
        Destroy(efectSentuhan.gameObject, 2);
        efectSentuhan.transform.parent = null;


        efectIdle.Stop();
        Destroy(efectIdle.gameObject, 2);
        efectIdle.transform.parent = null;

        Destroy(efectSpawn.gameObject, 2);
        efectSpawn.transform.parent = null;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;



        Destroy(gameObject);
    }
}
