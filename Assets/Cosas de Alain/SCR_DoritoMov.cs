using UnityEngine;

public class SCR_DoritoMov : MonoBehaviour
{
    private bool isDone;
    private bool isTouched;
    private int index;
    private string words;
    private float waitTime;
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

    public void WriteString(string _words)
    {
        words = _words;
        index = 0;
        waitTime = 1.0f;
        isDone = false;
        words = words.ToLower();
        Debug.Log(words);
        nextPos = letterPos[(int)System.Text.Encoding.UTF8.GetBytes(words)[index] - 94];
    }

    private void NextLetter()
    {
        if (index == words.Length)
        {
            isDone = true;
            return;
        }

        if (Vector3.Distance(this.transform.position, nextPos.position) < 0.01f)
        {
            waitTime = 0.0f;
            currentPos = nextPos;
            index++;
            if (index < words.Length)
                nextPos = letterPos[(int)System.Text.Encoding.UTF8.GetBytes(words)[index] - 94];
        }
        else
        {
            if (waitTime < 1)
                waitTime += Time.deltaTime;
            else
                this.transform.position = Vector3.MoveTowards(this.transform.position, nextPos.position, 0.5f * Time.deltaTime);
        }
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
        currentPos = nextPos = this.transform;
        isDone = true;
        words = "";
        waitTime = 0.0f;
        isTouched = false;
        index = 0;
        letterPos = GameObject.Find("positions").GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            WriteYes();
        else if (Input.GetKeyDown(KeyCode.N))
            WriteNo();
        else if (Input.GetKeyDown(KeyCode.G))
            WriteGoodBye();
        else if (Input.GetKeyDown(KeyCode.W))
            WriteString("palabra");

        NextLetter();
        if (isDone)
            MoveToPosition();
    }
}