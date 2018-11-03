using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Ghost : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        StartCoroutine(Nextscene());
    }

    private IEnumerator Nextscene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * 5f);
    }
}