using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 offset;

    private void OnValidate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, 1000 * Time.deltaTime);
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
