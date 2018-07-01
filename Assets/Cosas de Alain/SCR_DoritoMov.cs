using UnityEngine;

public class SCR_DoritoMov : MonoBehaviour
{
    private bool isDone;
    private bool isTouched;
    private string words;
    private Transform currentPos, nextPos;
    private Transform[] letterPos;

    private enum TABLA
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
        num0 ,
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

    public void WriteGoodBye()
    {
        nextPos = letterPos[(int)TABLA.goodBye];
        isDone = false;
    }

    public void WriteNo()
    {
        nextPos = letterPos[(int)TABLA.no];
        isDone = false;
    }

    public void WriteYes()
    {
        nextPos = letterPos[(int)TABLA.yes];
        isDone = false;
    }

    private void MoveToPosition()
    {
        if (Vector3.Distance(this.transform.position, nextPos.position) < 0.01f)
        {
            isDone = true;
            currentPos = nextPos;
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nextPos.position, 0.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouched = false;
        }
    }

    private void Start()
    {
        currentPos = this.transform;
        isDone = true;
        isTouched = false;
        letterPos = GameObject.Find("positions").GetComponentsInChildren<Transform>();
        for (int i = 0; i < letterPos.Length; i++)
        {
            Debug.Log(i + ": " + letterPos[i].name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            WriteYes();
        else if (Input.GetKeyDown(KeyCode.N))
            WriteNo();
        else if (Input.GetKeyDown(KeyCode.G))
            WriteGoodBye();

        if (!isDone)
            MoveToPosition();
    }
}
