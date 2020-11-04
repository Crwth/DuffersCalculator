using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewRound : MonoBehaviour
{
    int numPlayers;

    public RectTransform FirstPanel;
    public RectTransform SecondPanel;
    public TMP_Text Title;

    public RectTransform PopUp;

    public GameObject[] playerNames;

    public Button Create;

    public Players Players;
    public Overlay Overlay;

    // Start is called before the first frame update
    void Start()
    {
        FirstPanel.gameObject.SetActive(true);
        SecondPanel.gameObject.SetActive(false);
        PopUp.gameObject.SetActive(false);

        Players = GameObject.Find("Players").GetComponent<Players>();
        Overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
    }

    void FirstToSecond()
    {
        FirstPanel.gameObject.SetActive(false);
        SecondPanel.gameObject.SetActive(true);
        PopUp.gameObject.SetActive(true);

        playerNames.ToList().ForEach(playerName => playerName.SetActive(false));
        Create.gameObject.SetActive(false);
    }

    public void OnStandard() {
        Title.SetText("New Round: Standard 6 Holes");
        FirstToSecond();

        Players.SetNumRounds(6);
    }

    public void OnFull() {
        Title.SetText("New Round: Full 9 Holes");
        FirstToSecond();

        Players.SetNumRounds(9);
    }

    public void OnCustom() {
        Title.SetText("New Round: Custom X Holes");
        // XXX
        FirstToSecond();
        //Players.setNumRounds(x);
    }

    void ActivatePlayerNames()
    {
        for (int i = 0; i < numPlayers; i++)
            playerNames[i].SetActive(true);

        Create.gameObject.SetActive(true);
    }

    public void NumPlayers(int num)
    {
        numPlayers = num;

        Players.SetNumPlayers(num);
    }
    public void ChoosePlayers() {
        ActivatePlayerNames();
        PopUp.gameObject.SetActive(false);
    }

    public void SetPlayerName(int player)
    {
        string name = playerNames[player].GetComponent<TMP_InputField>().text;
        Players.SetPlayerName(player, name);
    }

    public void CreateScorecard()
    {
        Overlay.CreateScorecard();
    }
}
