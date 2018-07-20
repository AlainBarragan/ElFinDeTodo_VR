using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class scr_PhyButton : MonoBehaviour {

    public int IdButton = 0;

    float select_time = 0f;

    bool HandOn = false;

    public string idQs;

    Image Bar;

	// Use this for initialization
	void Start () {
        Bar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        bool InputMode = XRDevice.isPresent;
        if (!InputMode)
            InputMode = Input.GetMouseButton(0);

        if (HandOn && InputMode)
        {
            if (select_time<1f)
            {
                select_time += Time.deltaTime;
                if (select_time >= 1f)
                {
                    DoAccion();
                }
            }
        } else
        {
            select_time = 0f;
        }

        Bar.fillAmount = select_time;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandOn = false;
        }
    }

    private void OnEnable()
    {
        HandOn = false;
        select_time = 0f;
    }

    void DoAccion()
    {
        switch(IdButton)
        {
            case 0:
            case 1:
            case 2: // Questions
                {
                    scr_CntrlSession.CS.SelectQuest(IdButton);
                }
                break;
            case 3: //Credits
                {
                    scr_CntrlSession.CS.SwitchCredits();
                }
                break;
            case 4:
                {
                    scr_CntrlSession.CS.ChangeLang();
                }
                break;
            case 5:
                {
                    Application.Quit();
                }
                break;
            case -1:
                {
                    scr_CntrlSession.CS.StartGame();
                }
                break;

        }
    }
}
