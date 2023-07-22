using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public static SpawnMap instance;

    public GameObject groundPrefab;
    public GameObject jembatanPrefab;

    public Material[] matGround;
    public Material[] matJembatan;

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
        RandomIndex();

        GameObject groundTemp = Instantiate(groundPrefab, transform);
        posZ += 50;
        groundTemp.transform.position = new Vector3(0, 0, posZ);
        if (GameplayManager.instance.stage >= 1) Destroy(transform.GetChild(0).gameObject);
        groundTemp.transform.GetChild(0).GetComponent<MeshRenderer>().material = matGround[randomIndex];


        GameObject jembatanTemp = Instantiate(jembatanPrefab, transform);
        posZ += 50;
        jembatanTemp.transform.position = new Vector3(0, 0, posZ);
        if (GameplayManager.instance.stage >= 2) Destroy(transform.GetChild(1).gameObject);
        jembatanTemp.transform.GetChild(0).GetComponent<MeshRenderer>().material = matJembatan[randomIndex];

    }
    int randomIndex;
    public bool[] randomBool;
    void RandomIndex()
    {
        int random = Random.Range(0, matGround.Length);

        if (randomBool.Length != matGround.Length) randomBool = new bool[matGround.Length];

        int checkTotal = 0;
        for (int i = 0; i < randomBool.Length; i++)
        {
            if (randomBool[i])
            {
                checkTotal++;
            }
        }
        if (checkTotal == randomBool.Length) randomBool = new bool[matGround.Length];


        for (int i = 0; i < randomBool.Length; i++)
        {
            if (!randomBool[i] && i == random)
            {
                randomBool[i] = true;
                randomIndex = i;
            }
            else if (randomBool[i] && i == random)
            {
                RandomIndex();
            }
        }
    }
}
