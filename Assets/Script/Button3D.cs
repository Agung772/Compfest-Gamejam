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
        if (MainmenuUI.instance.uiActive) return;

        animator.SetTrigger("Down");

        AudioManager.instance.ButtonClickSFX();
    }
    private void OnMouseEnter()
    {
        if (MainmenuUI.instance.uiActive) return;
        stay = true;
    }
    private void OnMouseExit()
    {
        if (MainmenuUI.instance.uiActive) return;
        stay = false;
    }
    private void OnMouseUp()
    {
        if (MainmenuUI.instance.uiActive) return;
        animator.SetTrigger("Up");

        if (stay)
        {
            onClick.Invoke();
        }

    }
}
