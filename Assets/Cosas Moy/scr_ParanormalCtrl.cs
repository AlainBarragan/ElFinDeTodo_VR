using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ParanormalCtrl : MonoBehaviour {

    public Rigidbody[] Pobjects = new Rigidbody[10];

    public Rigidbody[] Sobjects = new Rigidbody[10];

    public Animation[] Aobjects = new Animation[10];

    int Current;

    // Use this for initialization
    void Start () {
        Current = -1;
        StartCoroutine(ParanormalPulsation());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoParanormalActivity()
    {
        int acction = Random.Range(0,4);

        switch(acction)
        {
            case 0:
                {
                    int idr = Random.Range(0, Pobjects.Length);
                    Pobjects[idr].AddForce(new Vector3(Random.Range(4, 12), Random.Range(4, 12), Random.Range(4, 12)), ForceMode.Impulse);
                    Pobjects[idr].useGravity = true;
                }
                break;
            case 1:
                {
                    StartCoroutine(ParanormalLevitation());
                }
                break;
            case 2:
                {
                    Current = Random.Range(0, Sobjects.Length);
                }
                break;
            case 3:
                {
                    Aobjects[Random.Range(0, Aobjects.Length)].Play();
                }
                break;
        }

        
    }

    IEnumerator ParanormalPulsation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (Current!=-1)
            {
                Sobjects[Current].AddForce(new Vector3(0f,0f, Random.Range(1, 2)), ForceMode.Force);
            }
        }
    }

    IEnumerator ParanormalLevitation()
    {
        int obj = Random.Range(0, Pobjects.Length);
        Pobjects[obj].useGravity = false;
        Pobjects[obj].AddForce(new Vector3(0f, 0f, 1f), ForceMode.Force);
        yield return new WaitForSeconds(3f);
        Pobjects[obj].useGravity = true;
        Pobjects[obj].AddForce(new Vector3(Random.Range(4, 12), Random.Range(4, 12), Random.Range(4, 12)), ForceMode.Force);
    }


}
