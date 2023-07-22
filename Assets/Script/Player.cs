using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public bool active;

    public float maxHp = 100;
    float hp;
    [SerializeField] float speed = 5;
    [SerializeField] float heading = 5;
    public CharacterController characterController;

    public Transform pointMinirobot;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        hp = maxHp;
        active = true;

        UpdateUI();
    }
    private void Update()
    {
        if (active)
        Move();
    }

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
            heading = Mathf.Atan2(inputX, inputZ);
            transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0);
        }

    }

    public void HitPlayer(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            hp = 0;
            GameplayManager.instance.PlayerDeath();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        CanvasGameplay.instance.bar.fillAmount = hp / maxHp;
        CanvasGameplay.instance.hpText.text = hp.ToString();

    }
}
