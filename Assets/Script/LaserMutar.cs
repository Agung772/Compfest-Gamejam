using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMutar : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.position.y, transform.eulerAngles.z);
    }
}
