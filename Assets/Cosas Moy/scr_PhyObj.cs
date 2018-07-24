using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PhyObj : MonoBehaviour {

    Rigidbody Myrg;
    AudioSource MyAudioS;

	// Use this for initialization
	void Start () {
        Myrg = GetComponent<Rigidbody>();
        MyAudioS = GetComponent<AudioSource>();
    }
	

    private void OnCollisionEnter(Collision collision)
    {
        if (Myrg && MyAudioS)
        {
            if (Myrg.velocity.magnitude>1f && !MyAudioS.isPlaying)
            {
                MyAudioS.Play();
            }
        }
    }
}
