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
    bool cd;
    public void PindahScene(string namaScene)
    {
        if (!cd)
        {
            cd = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {

                TransisiScene("Start");
                yield return new WaitForSeconds(2);
                SceneManager.LoadScene(namaScene);
                TransisiScene("Exit");
                cd = false;
            }
        }
    }

    public void Quit()
    {
        if (!cd)
        {
            cd = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                TransisiScene("Start");
                yield return new WaitForSeconds(2);
                Application.Quit();
                cd = false;
            }
        }
    }

    public void SpawnNotif(string value)
    {
        if (spawnNotifText.transform.childCount > 0)
        {
            Destroy(spawnNotifText.transform.GetChild(0).gameObject);
        }
        GameObject temp = Instantiate(notifText, spawnNotifText);
        temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value;
    }
}
