using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlay : MonoBehaviour
{
    public GameObject CalculatorButton;
    public GameObject Calculator;
    // Start is called before the first frame update
    void Start()
    {
        CalculatorButton.gameObject.SetActive(true);
        Calculator.gameObject.SetActive(false);

        SceneManager.LoadScene("NewRound", LoadSceneMode.Additive);
    }

    public void CreateScorecard()
    {
        SceneManager.UnloadSceneAsync("NewRound");
        SceneManager.LoadScene("Scorecard", LoadSceneMode.Additive);
    }

}
