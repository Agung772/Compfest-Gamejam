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
    [SerializeField] GameObject aim;
    [SerializeField] Transform model3D;

    private void Start()
    {
        transform.parent = null;
        SavePosisi();
    }

    private void Update()
    {
        if (active)
        {
            Move();
            
            if (Input.GetKeyUp(KeyCode.E))
            {
                attackMiniPlayer.Attack();
            }
            if (!aim.activeInHierarchy)
            {
                aim.SetActive(true);
            }

            model3D.localEulerAngles = Vector3.Lerp(model3D.localEulerAngles, new Vector3(model3D.localEulerAngles.x, 180, model3D.localEulerAngles.z), 5 * Time.deltaTime);
        }
        else
        {
            AutoMove();
            if (aim.activeInHierarchy)
            {
                aim.SetActive(false);
            }

            model3D.localEulerAngles = Vector3.Lerp(model3D.localEulerAngles, new Vector3(model3D.localEulerAngles.x, 0, model3D.localEulerAngles.z), 5 * Time.deltaTime);
        }




    }
    float heading;
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 v3 = new Vector3(inputX, 0, inputZ);

        characterController.Move(v3 * speed * Time.deltaTime);

        float inputXRaw = Input.GetAxisRaw("Horizontal");
        float inputZRaw = Input.GetAxisRaw("Vertical");
        Vector2 v2 = new Vector2(inputXRaw, inputZRaw);
        if (v2.magnitude > 0.5f)
        {
            print(v2.magnitude);
            heading = Mathf.Atan2(inputX, inputZ);
            transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0);
        }

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
        var player = Player.instance.pointMinirobot.position;
        Vector3 posDefault = new Vector3(player.x, player.y, player.z);

        if (Vector3.Distance(transform.position, new Vector3(player.x, offsetY, player.z)) > 0.1f && back)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.x, offsetY, player.z), 5 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, Player.instance.transform.eulerAngles.y, 0);
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
                transform.rotation = Quaternion.Euler(0, Player.instance.transform.eulerAngles.y, 0);
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
                transform.rotation = Quaternion.Euler(0, Player.instance.transform.eulerAngles.y, 0);
            }

        }




        //transform.position = new Vector3(player.x, posisiAwal.y, player.z);
    }

    public void SavePosisi()
    {
        posisiAwal = Player.instance.transform.position;
    }
}
