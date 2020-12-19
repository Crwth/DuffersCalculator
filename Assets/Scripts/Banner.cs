using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    public Players players;
    public Button button;
    public TMP_Text BannerText;

    public int WinningScore { get; set; }

    private int numPlayers { get { return players.NumPlayers; } }
    private int numRounds { get { return players.NumRounds; } }

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players").GetComponent<Players>();
    }

    // Update is called once per frame
    void Update()
    {
        int numWinners = players.players.Count(p => p.Total == WinningScore);

        if (numWinners == 1)
        {
            Player winner = players.players.Single(p => p.Total == WinningScore);
            BannerText.SetText($"{winner.Name.ToUpper()} WINS!");
        }
        else if (numWinners > 1)
        {
            BannerText.SetText($"IT'S A TIE!");
        }
        else
        {
            BannerText.SetText($"I couldn't figure out who won (I'm only a computer)");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Overlay");
    }
}
