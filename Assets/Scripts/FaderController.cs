using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeFromBlack()
    {
        anim.SetTrigger("FadeFromBlack");
    }

    public void FadeIntoBlack()
    {
        anim.SetTrigger("FadeIntoBlack");
    }
}
