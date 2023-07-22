using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMutar : MonoBehaviour
{
    public float speed;
    float rotY;
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY += Time.deltaTime * speed, transform.eulerAngles.z);
    }
}
