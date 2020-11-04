using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadInXSeconds(5));
    }

    IEnumerator LoadInXSeconds(int x)
    {
        int counter = x;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        SceneManager.LoadScene("Overlay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
