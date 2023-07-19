using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCursor : MonoBehaviour
{
    public static ParticleCursor instance;
    public bool active;

    public GameObject perticle;
    public float speed = 1;

    bool cooldown;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (active)
        {
            transform.position = Input.mousePosition;

            if (!cooldown)
            {
                cooldown = true;
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    GameObject temp = Instantiate(perticle, transform);
                    temp.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
                    temp.transform.SetParent(transform.parent);
                    Destroy(temp, 2f);
                    yield return new WaitForSeconds(speed);
                    cooldown = false;
                }
            }
        }
    }
}
