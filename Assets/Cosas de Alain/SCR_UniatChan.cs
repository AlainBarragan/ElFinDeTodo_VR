using UnityEngine;

public class SCR_UniatChan : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetLayerWeight(1, SCR_DemonLevel.malboneco * 0.01f);
        anim.SetBool("flotar", SCR_DemonLevel.malboneco > 80);
    }

    public void Llorar()
    {
        anim.SetTrigger("Llorar");
    }
}