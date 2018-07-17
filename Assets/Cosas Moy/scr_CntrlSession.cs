using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_CntrlSession : MonoBehaviour {

    public static scr_CntrlSession CS;

    public Text T_Respuesta;
    public Text[] Preguntas = new Text[3];
    public GameObject Btn_StartButton;
    public GameObject Btn_Credits;
    public GameObject Btn_Lang;
    public GameObject Btn_Exit;
    public GameObject Btn_Back;
    public GameObject Btn_Escapar;

    public GameObject Credits;
    public GameObject Menu;
    public GameObject Questions;
    public GameObject Title;

    SCR_DoritoMov Dorito;

    Dictionary<string, string[]> Dialogo = new Dictionary<string, string[]>();

    List<string> AllQues = new List<string>();

    private void Awake()
    {
        CS = this;
    }

    // Use this for initialization
    void Start () {
        Btn_StartButton.SetActive(false);
        StartCoroutine(LoadSession());
        Dorito = FindObjectOfType<SCR_DoritoMov>();
    }
	
    IEnumerator LoadSession()
    {
        string[] ans = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_01_" + i.ToString());
        }
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 10; i++)
        {
            Dialogo.Add("txt_ques_01_" + i.ToString(), ans);
        }
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_02_" + i.ToString());
        }
        Dialogo.Add("txt_ques_02", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_06_" + i.ToString());
        }
        Dialogo.Add("txt_ques_06", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_07_" + i.ToString());
        }
        Dialogo.Add("txt_ques_07_1", ans);
        Dialogo.Add("txt_ques_07_2", ans);
        Dialogo.Add("txt_ques_07_3", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_09_" + i.ToString());
        }
        Dialogo.Add("txt_ques_09", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 3; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_10_" + i.ToString());
        }
        Dialogo.Add("txt_ques_10", ans);
        yield return new WaitForFixedUpdate();
        ans = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_03_" + i.ToString());
        }
        Dialogo.Add("txt_ques_03", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_04_" + i.ToString());
        }
        Dialogo.Add("txt_ques_04", ans);
        Dialogo.Add("txt_ques_04_1", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_05_" + i.ToString());
        }
        Dialogo.Add("txt_ques_05", ans);
        Dialogo.Add("txt_ques_05_1", ans);
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 5; i++)
        {
            ans[i] = scr_Lang.GetText("txt_ans_08_" + i.ToString());
        }
        Dialogo.Add("txt_ques_08", ans);
        yield return new WaitForFixedUpdate();
        ans = new string[1] {"P"};
        for (int i=0; i<10; i++)
        {
            Dialogo.Add("txt_afi_"+i.ToString(), ans);
        }
        yield return new WaitForFixedUpdate();
        for (int i=0; i<10; i++)
        {
            AllQues.Add("txt_ques_01_"+i.ToString());
            AllQues.Add("txt_afi_" + i.ToString());
        }
        yield return new WaitForFixedUpdate();
        AllQues.Add("txt_ques_02");
        AllQues.Add("txt_ques_03");
        AllQues.Add("txt_ques_04");
        AllQues.Add("txt_ques_04_1");
        AllQues.Add("txt_ques_05");
        AllQues.Add("txt_ques_05_1");
        AllQues.Add("txt_ques_06");
        AllQues.Add("txt_ques_07_1");
        AllQues.Add("txt_ques_07_2");
        AllQues.Add("txt_ques_07_3");
        AllQues.Add("txt_ques_08");
        AllQues.Add("txt_ques_09");
        AllQues.Add("txt_ques_10");
        

        //End Of LOAD
        Btn_StartButton.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        if (Dorito)
        {
            //Pendiente
        }

    }

    public void SwitchCredits()
    {
        if (Credits.activeSelf)
        {
            Credits.SetActive(false);
            Menu.SetActive(true);
            Btn_Back.SetActive(false);
        } else
        {
            Credits.SetActive(true);
            Menu.SetActive(false);
            Btn_Back.SetActive(true);
        }
    }

    public void ChangeLang()
    {
        scr_Lang.Op_Leng++;
        if (scr_Lang.Op_Leng > 2)
            scr_Lang.Op_Leng = 0;
        scr_Lang.setLanguage();
    }

    public void StartGame()
    {
        Credits.SetActive(false);
        Menu.SetActive(false);
        Btn_Back.SetActive(false);
        Questions.SetActive(true);
        Title.SetActive(false);
        T_Respuesta.gameObject.SetActive(true);
        Btn_Escapar.SetActive(true);
        Btn_StartButton.SetActive(false);
        SetQuestions();
    }

    public void SelectQuest(int _id)
    {
        string idstring = Preguntas[_id].transform.parent.GetComponent<scr_PhyButton>().idQs;
        if (Dorito)
            Dorito.SkribuString(Dialogo[idstring][Random.Range(0,Dialogo[idstring].Length)]);
        SetQuestion(_id);
    }

    public void SetQuestions()
    {
        for (int i=0; i<3; i++)
        {
            if (AllQues.Count == 0)
                break;

            int idq = Random.Range(0, AllQues.Count);
            string q = AllQues[idq];
            AllQues.RemoveAt(idq);
            Preguntas[i].text = scr_Lang.GetText(q);
            Preguntas[i].transform.parent.GetComponent<scr_PhyButton>().idQs = q;
        }
    }

    public void SetQuestion(int _id)
    {
        int idq = Random.Range(0, AllQues.Count);
        string q = AllQues[idq];
        AllQues.RemoveAt(idq);
        Preguntas[_id].text = scr_Lang.GetText(q);
        Preguntas[_id].transform.parent.GetComponent<scr_PhyButton>().idQs = q;
    }
}
