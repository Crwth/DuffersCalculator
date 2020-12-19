using System;
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
    public RectTransform CustomPanel;
    public TMP_Text Title;

    public TMP_Text StandardText;
    public TMP_Text FullText;
    public TMP_Text CustomText;

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

    void Update() {
        var baseSize = StandardText.fontSize;
        FullText.fontSize = baseSize;
        CustomText.fontSize = baseSize;
    }

    void FirstToSecond()
    {
        FirstPanel.gameObject.SetActive(false);
        SecondPanel.gameObject.SetActive(true);
        PopUp.gameObject.SetActive(true);

        playerNames.ToList().ForEach(playerName => playerName.SetActive(false));
        Create.gameObject.SetActive(false);
    }

    public void OnStandard()
    {
        Title.SetText("New Round: Standard 6 Holes");
        FirstToSecond();

        Players.SetNumRounds(6);
    }

    public void OnFull()
    {
        Title.SetText("New Round: Full 9 Holes");
        FirstToSecond();

        Players.SetNumRounds(9);
    }

    public void OnCustom()
    {
        CustomPanel.gameObject.SetActive(true);
    }

    public void OnCustomCount(int rounds) {
        Title.SetText($"New Round: Custom {rounds} Holes");
        FirstToSecond();

        Players.SetNumRounds(rounds);
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
        var button = GameObject.Find(num + "").GetComponent<Button>();
        if (button)
        {
            button.Select();
            button.OnSelect(null);
        }
        Players.SetNumPlayers(num);
    }
    public void ChoosePlayers()
    {
        if (Players.NumPlayers > 0) {
            ActivatePlayerNames();
            PopUp.gameObject.SetActive(false);
        }
    }

    public void SetPlayerName(int player)
    {
        string name = playerNames[player].GetComponent<TMP_InputField>().text;
        Players.SetPlayerName(player, name);
    }

    public void CreateScorecard()
    {
        bool allDone = true;

        for (int i = 0; i < numPlayers; i++)
        {
            string name = playerNames[i].GetComponent<TMP_InputField>().text;
            allDone = allDone && name != null && name != "";
        }

        if (allDone) Overlay.CreateScorecard();
    }
}
