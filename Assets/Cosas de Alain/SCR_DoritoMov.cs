﻿using UnityEngine;

public class SCR_DoritoMov : MonoBehaviour
{
    private bool estasFinita;
    private bool estasTusita;
    public int indekso;
    public string vortoj;
    private float atendoTempon;
    private Transform aktualaPozicio, sekvaPozicio;
    private Transform[] leteroPozicio;

    private enum TABULO
    {
        yes = 1,
        no,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        num0,
        num1,
        num2,
        num3,
        num4,
        num5,
        num6,
        num7,
        num8,
        num9,
        goodBye
    }

    public void SkribuGoodBye()
    {
        sekvaPozicio = leteroPozicio[(int)TABULO.goodBye];
        estasFinita = false;
    }

    public void SkribuNo()
    {
        sekvaPozicio = leteroPozicio[(int)TABULO.no];
        estasFinita = false;
    }

    public void SkribuYes()
    {
        sekvaPozicio = leteroPozicio[(int)TABULO.yes];
        estasFinita = false;
    }

    public void SkribuString(string _vortoj)
    {
        vortoj = _vortoj;
        indekso = 0;
        atendoTempon = 1.0f;
        estasFinita = false;
        vortoj = vortoj.ToLower();
        Debug.Log(vortoj);
        if ((int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] > 90)
            sekvaPozicio = leteroPozicio[(int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] - 94];
        else
            sekvaPozicio = leteroPozicio[(int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] - 47 + (int)TABULO.Z];
    }

    private void SekvaLetero()
    {
        if (indekso == vortoj.Length)
        {
            estasFinita = true;
            return;
        }

        if (Vector3.Distance(this.transform.position, sekvaPozicio.position) < 0.01f)
        {
            int nombro;
            atendoTempon = 0.0f;
            aktualaPozicio = sekvaPozicio;
            indekso++;
            if (indekso < vortoj.Length)
            {
                if ((int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] > 90)
                    nombro = (int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] - 94;
                else
                    nombro = (int)System.Text.Encoding.UTF8.GetBytes(vortoj)[indekso] - 47 + (int)TABULO.Z;

                sekvaPozicio = leteroPozicio[nombro];
            }
        }
        else
        {
            if (atendoTempon < 1)
                atendoTempon += Time.deltaTime;
            else
                this.transform.position = Vector3.MoveTowards(this.transform.position, sekvaPozicio.position, 0.5f * Time.deltaTime);
        }
    }

    private void MovigiAlPozicio()
    {
        if (Vector3.Distance(this.transform.position, sekvaPozicio.position) < 0.01f)
        {
            estasFinita = true;
            aktualaPozicio = sekvaPozicio;
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, sekvaPozicio.position, 0.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estasTusita = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estasTusita = false;
        }
    }

    private void Start()
    {
        aktualaPozicio = sekvaPozicio = this.transform;
        estasFinita = true;
        vortoj = "";
        atendoTempon = 0.0f;
        estasTusita = false;
        indekso = 0;
        leteroPozicio = GameObject.Find("positions").GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Y))
            SkribuYes();
        else if (Input.GetKeyDown(KeyCode.N))
            SkribuNo();
        else if (Input.GetKeyDown(KeyCode.G))
            SkribuGoodBye();
        else if (Input.GetKeyDown(KeyCode.W))
            SkribuString("Prueba");
        else if (Input.GetKeyDown(KeyCode.Alpha0))
            SkribuString("P5429");
#endif

        SekvaLetero();
        if (estasFinita)
            MovigiAlPozicio();
    }
}