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
    [SerializeField] CharacterController characterController;
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
    }

    public void HitPlayer(int value)
    {
        hp -= value;
        UpdateUI();
    }

    void UpdateUI()
    {
        CanvasGameplay.instance.bar.fillAmount = hp / maxHp;
        CanvasGameplay.instance.hpText.text = hp.ToString();

    }
}
