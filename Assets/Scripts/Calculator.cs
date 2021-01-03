using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Calculator : MonoBehaviour
{
    private List<string> operations;
    private string currentValue;

    private int currentTotal = 0;
    private char currentOp = '+';

    private bool midcalculation = false;

    public GameObject CalculatorWindow;

    public TMP_Text Workspace;
    public TMP_Text Total;

    public Calculator()
    {
        Reset();
    }

    public void Update()
    {
        Workspace.SetText(ToString());
        Total.SetText($"{FutureTotal}");
    }

    public void Reset()
    {
        operations = new List<string>();
        currentValue = "";
        currentTotal = 0;
        currentOp = '+';
        midcalculation = false;
    }

    public void ShowCalculator()
    {
        CalculatorWindow.SetActive(true);
    }

    public void HideCalculator()
    {
        CalculatorWindow.SetActive(false);
    }

    private int FutureTotal
    {
        get
        {
            int newTotal = 0;
            int newValue = int.Parse($"0{currentValue}");

            if (newValue == 0)
            {
                newTotal = currentTotal;
            }
            else
                switch (currentOp)
                {
                    case '+': newTotal = currentTotal + newValue; break;
                    case '-': newTotal = currentTotal - newValue; break;
                    case '*': newTotal = currentTotal * newValue; break;
                    case '/': newTotal = currentTotal / newValue; break;
                }

            return newTotal;
        }
    }

    private void calculate()
    {
        if (midcalculation) operations.Add($"{currentOp}");
        operations.Add($"{currentValue}");

        currentTotal = FutureTotal;
        currentValue = "";

        midcalculation = true;
    }

    public override string ToString()
    {
        string ret = "";

        operations.ForEach(oper => ret += $"{oper}\n");

        if (midcalculation)
        {
            ret += $"{currentOp}\n";
        }
        ret += $"{currentValue}\n";

        return ret;
    }

    public void numKey(string num)
    {
        try {
            var newValue = currentValue + num;
            var newInt = int.Parse(newValue);
            currentValue += num;
        } catch (Exception) {}
        
    }

    public void opKey(string operation)
    {
        if (currentValue != "")
            calculate();

        currentOp = operation[0];
    }

    public void backKey()
    {
        if (currentValue == "") return;
        currentValue = currentValue.Substring(0, currentValue.Length - 1);
    }

    public void clearKey()
    {
        Reset();
    }
}
