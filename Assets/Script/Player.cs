using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public bool bigPlayer;
    public float speedPlayer;

    [SerializeField]
    GameObject topiPlayer;

    [SerializeField]
    new Rigidbody rigidbody;

    float offsetTopi;

    public float aklerasi;

    public ParticleSystem particelPlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        topiPlayer.transform.parent = null;

        SetSmallPlayer();
    }

    private void Update()
    {
        topiPlayer.transform.position = Vector3.Lerp(topiPlayer.transform.position, transform.position + Vector3.up * offsetTopi, 100 * Time.deltaTime);


        MovePlayer();


        if (aklerasi < 1)
        {
            aklerasi += Time.deltaTime * 0.08f;
        }
    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");

        speedPlayer += Time.deltaTime * 0.02f;

        rigidbody.AddForce(Vector3.forward * 1 * speedPlayer * aklerasi);


        if (rigidbody.velocity.z > speedPlayer)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, speedPlayer);
        }
        if (rigidbody.velocity.z < -speedPlayer)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -speedPlayer);
        }
    }

    public void SetBigPlayer()
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        offsetTopi = 1.45f;
        bigPlayer = true;
    }
    public void SetSmallPlayer()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        offsetTopi = 0.75f;
        bigPlayer = false;
    }

}
