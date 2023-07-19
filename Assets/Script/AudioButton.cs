using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public static AudioButton instance;

    public Sprite[] logoAudio;
    private void Awake()
    {
        instance = this;
    }



}
