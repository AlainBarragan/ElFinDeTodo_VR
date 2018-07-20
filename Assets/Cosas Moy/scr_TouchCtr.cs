using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TouchCtr : MonoBehaviour {

    public OVRInput.Controller MyController;

    GameObject Model;

    bool IsRight = true;

	// Use this for initialization
	void Start () {
        Model = transform.GetChild(0).gameObject;

        if (MyController == OVRInput.Controller.RTouch)
        {
            IsRight = true;
        } else
        {
            IsRight = false;
        }
        StartCoroutine(HandsCheck());
    }

    IEnumerator HandsCheck()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if (!OVRInput.GetControllerPositionTracked(MyController))
            {
                Debug.Log("No traking");
                Model.SetActive(false);
            }
            else if (!Model.activeSelf)
            {
                Model.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion HandQ = OVRInput.GetLocalControllerRotation(MyController);

        transform.localPosition = OVRInput.GetLocalControllerPosition(MyController) + new Vector3(0f, 0.6f, 0f);
        transform.rotation = Quaternion.Euler(HandQ.eulerAngles.x, HandQ.eulerAngles.y + 180, HandQ.eulerAngles.z);

    }
}
