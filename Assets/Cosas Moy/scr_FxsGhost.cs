using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FxsGhost : MonoBehaviour {
	
	// Update is called once per frame
	void Start () {
        StartCoroutine(GhostEvents());
	}

    IEnumerator GhostEvents()
    {
        while(true)
        {
            if (SCR_DemonLevel.malboneco>30)
            {
                transform.position = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
                transform.GetChild(Random.Range(0, transform.childCount)).GetComponent<AudioSource>().Play();
            }
            float ttn = 500 / SCR_DemonLevel.malboneco;
            ttn = Random.Range(ttn, ttn * 2);
            yield return new WaitForSeconds(ttn);
        }

    }
}
