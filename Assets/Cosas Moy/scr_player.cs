using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Leap;

public class scr_player : MonoBehaviour {

    public GameObject Oculus;
    public GameObject NormalCamera;

    // Use this for initialization
    void Start () {
		if (XRDevice.isPresent)
        {
            Oculus.SetActive(true);
            NormalCamera.SetActive(false);
        }
	}
	
}
