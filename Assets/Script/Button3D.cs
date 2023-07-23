using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onClick;
    [SerializeField] Animator animator;

    bool stay;
    private void OnMouseDown()
    {
        animator.SetTrigger("Down");

        AudioManager.instance.ButtonClickSFX();
    }
    private void OnMouseEnter()
    {
        stay = true;
    }
    private void OnMouseExit()
    {
        stay = false;
    }
    private void OnMouseUp()
    {
        animator.SetTrigger("Up");

        if (stay)
        {
            onClick.Invoke();
        }

    }

    public void Button()
    {
        print("Click");
    }
}
