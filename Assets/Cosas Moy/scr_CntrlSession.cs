using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_CntrlSession : MonoBehaviour {

    public static scr_CntrlSession CS;

    public Text T_Respuesta;
    public GameObject[] Preguntas = new GameObject[3];
    public GameObject SE_session;

    private void Awake()
    {
        CS = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
