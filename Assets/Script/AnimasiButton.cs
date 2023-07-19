using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiButton : MonoBehaviour
{
    public void SetEnter(bool value)
    {
        Animator animator = GetComponent<Animator>();
        if (value)
        {
            animator.SetBool("Enter", true);
        }
        else
        {
            animator.SetBool("Enter", false);
        }
    }
}
