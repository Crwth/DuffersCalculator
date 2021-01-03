using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Players players;
    public PlayerCard[] playerCards;
    public Par par;
    public Button button;
    public RectTransform BannerCanvas;
    public RectTransform ConfirmWindow;

    private bool gameStarted = false;

    private int numPlayers { get { return players.NumPlayers; } }
    private int numRounds { get { return players.NumRounds; } }

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players").GetComponent<Players>();
        for (int i = 0; i < numPlayers; i++)
        {
            playerCards[i].player = players.players[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

        string text = gameStarted ? "Finish" : "Start game";
        button.GetComponentInChildren<TMP_Text>().SetText(text);
        button.interactable = ParFilledIn;

    }

    public bool ShouldEnable(int player)
    {
        if (!ParFilledIn) return false;
        if (player > numPlayers) return false;

        return true;
    }

    public bool ParFilledIn
    {
        get
        {
            return par.FilledIn;
        }
    }

    public void ButtonPressed()
    {
        if (!gameStarted)
        {
            par.LockPars();
            gameStarted = true;
            playerCards.ToList().ForEach(pc => pc.EnableScores());
        }
        else
        {
            ConfirmWindow.gameObject.SetActive(true);
        }
    }

    public void Yes() {
        ConfirmWindow.gameObject.SetActive(false);
        Score();
    }

    public void No() {
        ConfirmWindow.gameObject.SetActive(false);
    }


    public void UpdateScores()
    {
        playerCards.ToList().ForEach(pc => pc.UpdateScores());
    }

    public void Score()
    {
        int lowestScore = 10000;

        for (int player = 0; player < numPlayers; player++)
        {
            var playerCard = playerCards[player];
            playerCard.Finished = true;
            playerCard.DisableScores();
            playerCard.UpdateWithPars(par.Pars);

            if (playerCard.player.Total < lowestScore)
            {
                lowestScore = playerCard.player.Total;
            }
        }

        for (int player = 0; player < numPlayers; player++)
        {
            if (playerCards[player].player.Total == lowestScore)
            {
                playerCards[player].Totalfield.GetComponentInChildren<TMP_Text>().color = Color.green;
            }
        }

        BannerCanvas.gameObject.SetActive(true);
        BannerCanvas.GetComponent<Banner>().WinningScore = lowestScore;
        button.gameObject.SetActive(false);
    }
}
