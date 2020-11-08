using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public Player player;
    public TMP_Text PlayerName;
    public TMP_InputField[] scores;
    public TMP_Text Subtotalfield;
    public TMP_InputField Teesfield;
    public TMP_Text Totalfield;

    public int Subtotal { get { return player.Subtotal; } }
    public int Tees { get { return player.Tees; } }
    public int Total { get { return player.Total; } }

    public bool Finished { get; set; }

    private bool firstSet = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].interactable = false;
        }
        Teesfield.interactable = false;
        PlayerName.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Subtotal != 0) Subtotalfield.SetText($"{Subtotal}");
            if (Finished && Total != 0) Totalfield.SetText($"{Total}");

            if (!firstSet)
            {
                PlayerName.text = player.Name;

                firstSet = true;
            }
        }
    }

    public void EnableScores()
    {
        if (player)
        {
            for (int i = 0; i < player.numRounds; i++)
            {
                scores[i].interactable = true;
            }
            for (int i = player.numRounds; i < scores.Length; i++)
            {
                scores[i].interactable = false;
            }
            Teesfield.interactable = true;
        }
    }

    public void DisableScores()
    {
        if (player)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i].interactable = false;
            }
            Teesfield.interactable = false;
        }
    }

    public void UpdateScores()
    {
        if (player)
        {
            for (int i = 0; i < player.numRounds; i++)
            {
                string score = scores[i].text;
                try
                {
                    int scorevalue = int.Parse($"0{score}");
                    if (scorevalue == 0)
                    {
                        if (player.Strokes[i] != 0)
                            scores[i].text = $"{player.Strokes[i]}";
                        else
                            scores[i].text = "";
                    }
                    else
                    {
                        player.Strokes[i] = scorevalue;
                        scores[i].text = $"{player.Strokes[i]}";
                    }
                }
                catch (Exception)
                {
                    if (player.Strokes[i] != 0)
                        scores[i].text = $"{player.Strokes[i]}";
                    else
                        scores[i].text = "";
                }
            }

            /* Tees */
            string tees = Teesfield.text;
            try
            {
                int teesvalue = int.Parse($"{tees}");
                if (teesvalue == 0)
                {
                    if (player.Tees != 0)
                        Teesfield.text = $"{player.Tees}";
                    else
                        Teesfield.text = "";
                }
                else
                {
                    player.Tees = teesvalue;
                    Teesfield.text = $"{player.Tees}";
                }
            }
            catch (Exception)
            {
                if (player.Tees != 0)
                    Teesfield.text = $"{player.Tees}";
                else
                    Teesfield.text = "";
            }
        }
    }

    public void UpdateWithPars(int[] Pars)
    {
        for (int i=0;i<player.numRounds;i++)
        {
            var score = scores[i].text;
            if (score == "" || score == "0")
            {
                var strokes = Pars[i] * 2;
                player.Strokes[i] = strokes;
                scores[i].text = $"{strokes}";
                var text = scores[i].GetComponentInChildren<TMP_Text>();
                text.color = Color.red;
            }
        }
    }
}
