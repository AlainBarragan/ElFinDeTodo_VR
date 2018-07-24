using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FxsGhost : MonoBehaviour {

    public AudioSource[] Fxs = new AudioSource[10];

    public void StartEffects()
    {
        StartCoroutine(GhostEvents());
    }
    IEnumerator GhostEvents()
    {
        while(true)
        {
            transform.position = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
            if (SCR_DemonLevel.malboneco>5)
                Fxs[Random.Range(0, Fxs.Length)].Play();
            float ttn = Random.Range(10f,20f);
            yield return new WaitForSeconds(ttn);
        }

    }
}
