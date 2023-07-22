using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public static SpawnMap instance;

    public GameObject[] groundPrefab;
    public GameObject jembatanPrefab;

    public float posZ;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        posZ = transform.GetChild(1).position.z;

        Spawn();
    }
    public void Spawn()
    {
        int randomGround = Random.Range(0, groundPrefab.Length);
        GameObject groundTemp = Instantiate(groundPrefab[randomGround], transform);
        posZ += 50;
        groundTemp.transform.position = new Vector3(0, 0, posZ);
        if (GameplayManager.instance.stage >= 1) Destroy(transform.GetChild(0).gameObject);


        GameObject jembatanTemp = Instantiate(jembatanPrefab, transform);
        posZ += 50;
        jembatanTemp.transform.position = new Vector3(0, 0, posZ);
        if (GameplayManager.instance.stage >= 2) Destroy(transform.GetChild(1).gameObject);

    }
}
