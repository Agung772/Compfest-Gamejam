using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    AudioSource audioSource;

    //-------------
    string _Audio = "Audio";
    string _AudioDefault = "AudioDefault";
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        //SetDefault
        if (PlayerPrefs.GetFloat(_AudioDefault) == 0)
        {
            PlayerPrefs.SetFloat(_AudioDefault, 1);

            PlayerPrefs.SetFloat(_Audio, 0.7f);
        }

        var audioButton = AudioButton.instance;
        if (PlayerPrefs.GetFloat(_Audio) == 0)
        {
            valueAudio = 0;
            audioSource.volume = 0;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[0];
        }
        else if (PlayerPrefs.GetFloat(_Audio) == 0.3f)
        {
            valueAudio = 1;
            audioSource.volume = 0.3f;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[1];
        }
        else if (PlayerPrefs.GetFloat(_Audio) == 0.7f)
        {
            valueAudio = 2;
            audioSource.volume = 0.7f;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[2];
        }

        audioSource.clip = gameplayBGM;
        audioSource.Play();

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            SFX = true;
        }
    }

    public int valueAudio;
    public void SetAudio()
    {
        valueAudio--;
        if (valueAudio < 0) valueAudio = 2;

        var audioButton = AudioButton.instance;
        if (valueAudio == 0)
        {
            audioSource.volume = 0;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[0];

            PlayerPrefs.SetFloat(_Audio, 0);
        }
        else if (valueAudio == 1)
        {
            audioSource.volume = 0.3f;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[1];

            PlayerPrefs.SetFloat(_Audio, 0.3f);
        }
        else if (valueAudio == 2)
        {
            audioSource.volume = 0.7f;
            audioButton.GetComponent<Image>().sprite = audioButton.GetComponent<AudioButton>().logoAudio[2];

            PlayerPrefs.SetFloat(_Audio, 0.7f);
        }

        ButtonClickSFX();
    }

    //-------------------
    [Space]
    [SerializeField]
    public AudioClip gameplayBGM;

    [SerializeField]
    public AudioClip
        buttonClickSFX,
        loseSFX,
        sihirSFX,
        tembokHancurSFX;

    bool SFX;
    public void ButtonClickSFX() 
    { 
        if (SFX)
        {
            audioSource.PlayOneShot(buttonClickSFX);
        }
 
    }
    public void LoseSFX() { audioSource.PlayOneShot(loseSFX); }
    public void SihirSFX() { audioSource.PlayOneShot(sihirSFX); }
    public void TembokHancurSFX() { audioSource.PlayOneShot(tembokHancurSFX); }
}
