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

    public GameObject[] mapEarlyGame;
    public GameObject[] mapMidGame;
    public GameObject[] mapLateGame;

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
    bool level1, level2, level3;
    int length;
    public void Spawn()
    {
        RandomIndex();
        GameObject groundTemp = null;

        if (GameplayManager.instance.stage >= 4)
        {
            if (!level3) { level3 = true; randomMapBool = new bool[mapLateGame.Length]; }

            length = mapLateGame.Length;
            RandomMapIndex();
            groundTemp = Instantiate(mapLateGame[randomMapIndex], transform);
            print("Spawn map Late Game " + randomMapIndex);
        }
        else if (GameplayManager.instance.stage >= 2)
        {
            if (!level2) { level2 = true; randomMapBool = new bool[mapMidGame.Length]; }

            length = mapMidGame.Length;
            RandomMapIndex();
            groundTemp = Instantiate(mapMidGame[randomMapIndex], transform);
            print("Spawn map Mid Game " + randomMapIndex);
        }
        else if (GameplayManager.instance.stage >= 0)
        {
            if (!level1) { level1 = true; randomMapBool = new bool[mapEarlyGame.Length]; }

            length = mapEarlyGame.Length;
            RandomMapIndex();
            groundTemp = Instantiate(mapEarlyGame[randomMapIndex], transform);
            print("Spawn map Early Game " + randomMapIndex);
        }


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

    int randomMapIndex;
    public bool[] randomMapBool;
    void RandomMapIndex()
    {
        int random = Random.Range(0, length);

        int checkTotal = 0;
        for (int i = 0; i < randomMapBool.Length; i++)
        {
            if (randomMapBool[i])
            {
                checkTotal++;
            }
        }
        if (checkTotal == length) { randomMapBool = new bool[length]; print("Reset"); }


        for (int i = 0; i < randomMapBool.Length; i++)
        {
            if (!randomMapBool[i] && i == random)
            {
                randomMapBool[i] = true;
                randomMapIndex = i;
            }
            else if (randomMapBool[i] && i == random)
            {
                RandomMapIndex();
            }
        }
    }
}
