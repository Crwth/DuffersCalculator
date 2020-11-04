using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Headers : MonoBehaviour
{
    public Players players;
    public TMP_Text[] headers;

    private int numRounds {  get { return players.NumRounds; } }

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players").GetComponent<Players>();    
        for (int i=0; i<=numRounds;i++) 
        {
            headers[i].SetText($"{i}");
        }
        headers[10].SetText("Sub");
        headers[11].SetText("Tees");
        headers[12].SetText("Total");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
