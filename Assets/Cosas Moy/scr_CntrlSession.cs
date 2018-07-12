using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_CntrlSession : MonoBehaviour {

    public static scr_CntrlSession CS;

    public Text T_Respuesta;
    public GameObject[] Preguntas = new GameObject[3];
    public GameObject SE_session;

    Dictionary<string, string[]> Dialogo = new Dictionary<string, string[]>();

    private void Awake()
    {
        CS = this;
    }

    // Use this for initialization
    void Start () {
        string[] ans = new string[3];
        for (int i=0; i<3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_01_"+i.ToString());
        }
        for (int i=0; i<10; i++)
        {
            Dialogo.Add("txt_ques_01_" + i.ToString(), ans);
        }
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_02_" + i.ToString());
        }
        Dialogo.Add("txt_ques_02", ans);
        ans = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_03_" + i.ToString());
        }
        Dialogo.Add("txt_ques_03", ans);
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_04_" + i.ToString());
        }
        Dialogo.Add("txt_ques_04", ans);
        Dialogo.Add("txt_ques_04_1", ans);
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_05_" + i.ToString());
        }
        Dialogo.Add("txt_ques_05", ans);
        Dialogo.Add("txt_ques_05_1", ans);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
