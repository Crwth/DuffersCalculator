using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Par : MonoBehaviour
{
    public Players players;
    public TMP_InputField[] ParFields;
    private int numRounds {  get { return players.NumRounds; } }
    private int[] pars;
    public int[] Pars { get { return pars; } }

    private bool initialized = false;

    void Update()
    {
        if (!initialized)
        {
            if (players == null)
            {
                players = GameObject.Find("Players").GetComponent<Players>();
            }
            if (players != null)
            {
                pars = new int[numRounds];
                for (int i = 0; i < numRounds; i++)
                {
                    ParFields[i].interactable = true;
                }
                for (int i = numRounds; i < 9; i++)
                {
                    ParFields[i].interactable = false;
                }

                initialized = true;
            }
        }
        
    }

    public void UpdatePars()
    {
        for (int i = 0; i < numRounds; i++)
        {
            string score = ParFields[i].text;
            try
            {
                int scorevalue = int.Parse($"0{score}");
                if (scorevalue == 0)
                {
                    if (Pars[i] != 0)
                        ParFields[i].text = $"{Pars[i]}";
                    else
                        ParFields[i].text = "";
                }
                else
                {
                    Pars[i] = scorevalue;
                    ParFields[i].text = $"{Pars[i]}";
                }
            }
            catch (Exception)
            {
                if (Pars[i] != 0)
                    ParFields[i].text = $"{Pars[i]}";
                else
                    ParFields[i].text = "";
            }
        }
    }

    public bool FilledIn
    {
        get
        {
            if (Pars == null) return false;
            return Pars.ToList().All(par => par != 0);
        }
    }

    public void LockPars()
    {
        for (int i = numRounds; i < 9; i++)
        {
            ParFields[i].interactable = false;
        }
    }
}
