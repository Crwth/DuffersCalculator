using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string myname;
    public string Name { get { return myname; } set { myname = value; } }
    [SerializeField]
    private int[] strokes;
    public int[] Strokes { get { return strokes; } }
    [SerializeField]
    private int tees;
    public int Tees { get { return tees; } set { tees = value < 0 ? value : -value; } }

    public int numRounds;

    public void setRounds(int numRounds)
    {
        this.numRounds = numRounds;
        this.strokes = new int[numRounds];
    }

    public int Subtotal
    {
        get { return Strokes.Sum(); }
    }

    public int Total
    {
        get { return Subtotal + Tees; }
    }
}
