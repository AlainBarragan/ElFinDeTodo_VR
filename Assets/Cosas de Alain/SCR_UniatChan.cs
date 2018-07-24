using UnityEngine;

public class SCR_UniatChan : MonoBehaviour
{
    private Animator anim;
    private bool poseida;
    new private AudioSource[] audio;

    private void Start()
    {
        audio = this.GetComponentsInChildren<AudioSource>();
        poseida = false;
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        //anim.SetLayerWeight(1, SCR_DemonLevel.malboneco * 0.01f);
        anim.SetFloat("Miedo", SCR_DemonLevel.malboneco);
        if (SCR_DemonLevel.malboneco >= 100 && !poseida)
        {
            poseida = true;
            audio[audio.Length - 1].Play();
        }
    }

    public void Llorar()
    {
        audio[Random.Range(0, audio.Length - 2)].Play();
    }
}