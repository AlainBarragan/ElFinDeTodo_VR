using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_UniatChan : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetLayerWeight(1, SCR_DemonLevel.malboneco);
    }
}
