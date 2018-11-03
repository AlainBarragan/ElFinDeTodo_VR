using System.Collections;
using UnityEngine;

public class scr_ParanormalCtrl : MonoBehaviour
{
    public Rigidbody[] Pobjects = new Rigidbody[10];

    public Animator[] GhAnims = new Animator[3];

    private int Current;

    // Use this for initialization
    private void Start()
    {
        Current = -1;
    }

    public void DoParanormalActivity()
    {
        int acction = Random.Range(0, 3);

        switch (acction)
        {
            case 0:
                {
                    int idr = Random.Range(0, Pobjects.Length);
                    Pobjects[idr].AddForce(new Vector3(Random.Range(8, 12), Random.Range(8, 12), Random.Range(8, 12)), ForceMode.Impulse);
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
                    GhAnims[Random.Range(0, GhAnims.Length)].SetTrigger("Fade");
                }
                break;
        }
        FindObjectOfType<SCR_UniatChan>().Llorar();
    }

    private IEnumerator ParanormalLevitation()
    {
        int obj = Random.Range(0, Pobjects.Length);
        Pobjects[obj].useGravity = false;
        Pobjects[obj].AddForce(new Vector3(0f, 0f, 10f), ForceMode.Impulse);
        yield return new WaitForSeconds(5f);
        Pobjects[obj].useGravity = true;
        Pobjects[obj].AddForce(new Vector3(Random.Range(4, 12), Random.Range(4, 12), Random.Range(4, 12)), ForceMode.Force);
    }
}