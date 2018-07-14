using System.Collections;
using UnityEngine;

public class SCR_DemonLevel : MonoBehaviour
{
    public AuraAPI.AuraVolume auraVolume;
    public static float malboneco;

    private scr_ParanormalCtrl paranormalCtrl;

    private void Start()
    {
        paranormalCtrl = FindObjectOfType<scr_ParanormalCtrl>();
        malboneco = 0.0f;
        auraVolume.density.injectionParameters.strength = malboneco * 0.01f;
        StartCoroutine(FaruMalbonajnAferojn());
    }

    private IEnumerator FaruMalbonajnAferojn()
    {
        if (malboneco > 100)
            malboneco = 100;
        else if (malboneco < 0)
            malboneco = 0;
        yield return new WaitForSeconds(110.0f - malboneco);
        FindObjectOfType<SCR_UniatChan>().Llorar();
        auraVolume.density.injectionParameters.strength = malboneco * 0.01f;
        StartCoroutine(FaruMalbonajnAferojn());
    }
}