using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer : MonoBehaviour
{
    public bool active;

    [SerializeField] float speed = 5;


    public float minX, maxX;
    public float minZ, maxZ;

    public float offsetY;
    public Vector3 posisiAwal;

    [SerializeField] CharacterController characterController;
    [SerializeField] AttackMiniPlayer attackMiniPlayer;

    private void Start()
    {
        transform.parent = null;
        posisiAwal = transform.position;
    }

    private void Update()
    {
        if (active)
        {
            Move();

            if (Input.GetKeyUp(KeyCode.Space))
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

        //Limit 
        if (transform.position.x > maxX + posisiAwal.x)
        {
            transform.position = new Vector3(maxX + posisiAwal.x, offsetY, transform.position.z);
        }
        if (transform.position.x < minX + posisiAwal.x)
        {
            transform.position = new Vector3(minX + posisiAwal.x, offsetY, transform.position.z);
        }
        if (transform.position.z > maxZ + posisiAwal.z)
        {
            transform.position = new Vector3(transform.position.x, offsetY, maxZ + posisiAwal.z);
        }
        if (transform.position.z < minZ + posisiAwal.z)
        {
            transform.position = new Vector3(transform.position.x, offsetY, minZ + posisiAwal.z);
        }

        //Set Pos Y
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, offsetY, transform.position.z), 5 * Time.deltaTime);
    }

    public bool back, defaultBool;
    void AutoMove()
    {
        var player = Player.instance.transform.position;
        Vector3 posDefault = new Vector3(player.x, 1.75f, player.z + -1);

        if (Vector3.Distance(transform.position, new Vector3(player.x, offsetY, player.z + -1)) > 0.1f && back)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.x, offsetY, player.z + -1), 5 * Time.deltaTime);
            print("back");
        }
        else if (back)
        {
            back = false;
            defaultBool = true;

            print("false");
        }
        else
        {
            if (Vector3.Distance(transform.position, posDefault) > 0.1f && defaultBool)
            {
                transform.position = Vector3.Lerp(transform.position, posDefault, 5 * Time.deltaTime);
                print("default");
            }
            else if (defaultBool)
            {
                defaultBool = false;

                Player.instance.active = true;
            }
            else
            {
                transform.position = posDefault;
            }

        }




        //transform.position = new Vector3(player.x, posisiAwal.y, player.z);
    }

    public void SavePosisi()
    {
        posisiAwal = transform.position;
    }
}
