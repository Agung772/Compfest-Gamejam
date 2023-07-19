using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Animator transisiAnimator;

    public Transform spawnNotifText;
    public GameObject notifText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void TransisiScene(string value)
    {
        if (value == "Start")
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.SetTrigger("Start");
        }
        else
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.SetTrigger("Exit");
        }
    }

    public void PindahScene(string namaScene)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            TransisiScene("Start");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(namaScene);
            TransisiScene("Exit");
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void SpawnNotif(string value)
    {
        GameObject temp = Instantiate(notifText, spawnNotifText);
        temp.GetComponent<TextMeshProUGUI>().text = value;
    }
}
