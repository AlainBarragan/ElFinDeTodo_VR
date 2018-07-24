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
    scr_ParanormalCtrl Monika;

    public AudioSource as_Select;
    public AudioSource as_Start;

    Dictionary<string, string[]> Dialogo = new Dictionary<string, string[]>();

    List<string> AllQues = new List<string>();

    string CurrentAnsw = "";

    public GameObject AmbientSounds;

    private void Awake()
    {
        CS = this;
    }

    // Use this for initialization
    void Start () {
        Btn_StartButton.SetActive(false);
        StartCoroutine(LoadSession());
        Dorito = FindObjectOfType<SCR_DoritoMov>();
        Monika = FindObjectOfType<scr_ParanormalCtrl>();
    }
	
    IEnumerator LoadSession()
    {
        string[] ans = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans[i] = "txt_ans_01_" + i.ToString();
        }
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < 10; i++)
        {
            Dialogo.Add("txt_ques_01_" + i.ToString(), ans);
        }
        yield return new WaitForFixedUpdate();
        string[] ans2 = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans2[i] = "txt_ans_02_" + i.ToString();
        }
        Dialogo.Add("txt_ques_02", ans2);
        yield return new WaitForFixedUpdate();
        string[] ans6 = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans6[i] = "txt_ans_06_" + i.ToString();
        }
        Dialogo.Add("txt_ques_06", ans6);
        yield return new WaitForFixedUpdate();
        string[] ans7 = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans7[i] = "txt_ans_07_" + i.ToString();
        }
        Dialogo.Add("txt_ques_07_1", ans7);
        Dialogo.Add("txt_ques_07_2", ans7);
        Dialogo.Add("txt_ques_07_3", ans7);
        yield return new WaitForFixedUpdate();
        string[] ans9 = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans9[i] = "txt_ans_09_" + i.ToString();
        }
        Dialogo.Add("txt_ques_09", ans9);
        yield return new WaitForFixedUpdate();
        string[] ans10 = new string[3];
        for (int i = 0; i < 3; i++)
        {
            ans10[i] = "txt_ans_10_" + i.ToString();
        }
        Dialogo.Add("txt_ques_10", ans10);
        yield return new WaitForFixedUpdate();
        string[] ans3 = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans3[i] = "txt_ans_03_" + i.ToString();
        }
        Dialogo.Add("txt_ques_03", ans3);
        yield return new WaitForFixedUpdate();
        string[] ans4 = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans4[i] = "txt_ans_04_" + i.ToString();
        }
        Dialogo.Add("txt_ques_04", ans4);
        Dialogo.Add("txt_ques_04_1", ans4);
        yield return new WaitForFixedUpdate();
        string[] ans5 = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans5[i] = "txt_ans_05_" + i.ToString();
        }
        Dialogo.Add("txt_ques_05", ans5);
        Dialogo.Add("txt_ques_05_1", ans5);
        yield return new WaitForFixedUpdate();
        string[] ans8 = new string[5];
        for (int i = 0; i < 5; i++)
        {
            ans8[i] = "txt_ans_08_" + i.ToString();
        }
        Dialogo.Add("txt_ques_08", ans8);
        yield return new WaitForFixedUpdate();
        string[] ansp = new string[1] {"P"};
        for (int i=0; i<10; i++)
        {
            Dialogo.Add("txt_afi_"+i.ToString(), ansp);
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
            if (Dorito.indekso>=0)
                T_Respuesta.text = Dorito.vortoj.Substring(0, Dorito.indekso);
        } else
        {
            T_Respuesta.text = CurrentAnsw;
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
        as_Start.Play();
    }

    public void SelectQuest(int _id)
    {
        string idstring = Preguntas[_id].transform.parent.GetComponent<scr_PhyButton>().idQs;
        string idresp = Dialogo[idstring][Random.Range(0, Dialogo[idstring].Length)];

        if (idresp == "txt_ans_01_0")
        {
            if (Dorito)
                Dorito.SkribuYes();
            CurrentAnsw = scr_Lang.GetText(idresp);
        }
        else if (idresp == "txt_ans_01_2")
        {
            if (Dorito)
                Dorito.SkribuNo();
            CurrentAnsw = scr_Lang.GetText(idresp);
        }
        else
        {
            if (idresp == "txt_ans_05_0")
            {
                int rn = Random.Range(30, 60);
                if (Dorito)
                    Dorito.SkribuString(rn.ToString());
                CurrentAnsw = rn.ToString();
            }
            else if (idresp != "P")
            {
                if (Dorito)
                    Dorito.SkribuString(scr_Lang.GetText(idresp));
                CurrentAnsw = scr_Lang.GetText(idresp);
            }
        }
        if (idstring.Contains("afi"))
        {
            SCR_DemonLevel.malboneco += 20;
            if (Monika)
            {
                Monika.DoParanormalActivity();
            }
        }
        else
        {
            SCR_DemonLevel.malboneco += 10;
            int r = Random.Range(0, 2);
            if (Monika && r == 0)
            {
                Monika.DoParanormalActivity();
            }
        }
         
        if (SCR_DemonLevel.malboneco>20)
        {
            AmbientSounds.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        if (SCR_DemonLevel.malboneco > 40)
        {
            AmbientSounds.transform.GetChild(1).GetComponent<AudioSource>().Play();
        }
        if (SCR_DemonLevel.malboneco > 60)
        {
            AmbientSounds.transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
        if (SCR_DemonLevel.malboneco > 80)
        {
            AmbientSounds.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            AmbientSounds.transform.GetChild(3).GetComponent<AudioSource>().Play();
        }

        SetQuestion(_id);
    }

    public void SetQuestions()
    {
        AllQues.Remove("txt_ques_01_0");
        AllQues.Remove("txt_ques_02");
        AllQues.Remove("txt_ques_06");

        Preguntas[0].text = scr_Lang.GetText("txt_ques_01_0");
        Preguntas[0].transform.parent.GetComponent<scr_PhyButton>().idQs = "txt_ques_01_0";

        Preguntas[1].text = scr_Lang.GetText("txt_ques_02");
        Preguntas[1].transform.parent.GetComponent<scr_PhyButton>().idQs = "txt_ques_02";

        Preguntas[2].text = scr_Lang.GetText("txt_ques_06");
        Preguntas[2].transform.parent.GetComponent<scr_PhyButton>().idQs = "txt_ques_06";
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
