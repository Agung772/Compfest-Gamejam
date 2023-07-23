using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMutar : MonoBehaviour
{
    public float speed;
    float rotY;
    public GameObject range;
    private void Start()
    {
        range.SetActive(false); 
    }
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY += Time.deltaTime * speed, transform.eulerAngles.z);
    }
}
