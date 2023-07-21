using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer : MonoBehaviour
{
    public bool active;

    [SerializeField] float speed = 5;


    public float minX, maxX;
    public float minZ, maxZ;
    public Vector3 posisiAwal;

    [SerializeField] CharacterController characterController;
    [SerializeField] AttackMiniPlayer attackMiniPlayer;

    private void Start()
    {
        posisiAwal = transform.position;
    }

    private void Update()
    {
        if (active)
        {
            Move();

            if (Input.GetMouseButtonDown(0))
            {
                attackMiniPlayer.Attack();
            }
        }
        else
        {
            AutoMove();
        }




    }
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 v3 = new Vector3(inputX, 0, inputZ);

        characterController.Move(v3 * speed * Time.deltaTime);

        if (transform.position.x > maxX + posisiAwal.x)
        {
            transform.position = new Vector3(maxX + posisiAwal.x, posisiAwal.y, transform.position.z);
        }
        if (transform.position.x < minX + posisiAwal.x)
        {
            transform.position = new Vector3(minX + posisiAwal.x, posisiAwal.y, transform.position.z);
        }
        if (transform.position.z > maxZ + posisiAwal.z)
        {
            transform.position = new Vector3(transform.position.x, posisiAwal.y, maxZ + posisiAwal.z);
        }
        if (transform.position.z < minZ + posisiAwal.z)
        {
            transform.position = new Vector3(transform.position.x, posisiAwal.y, minZ + posisiAwal.z);
        }
        transform.position = new Vector3(transform.position.x, posisiAwal.y, transform.position.z);
    }
    void AutoMove()
    {
        var player = Player.instance.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.x, posisiAwal.y, player.z), 5 * Time.deltaTime);
        //transform.position = new Vector3(player.x, posisiAwal.y, player.z);
    }

    public void SavePosisi()
    {
        posisiAwal = transform.position;
    }
}
