using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Players : MonoBehaviour
{
    public GameObject playerPrefab;
    [SerializeField]
    private int numPlayers;
    public int NumPlayers { get { return numPlayers; } set { numPlayers = value; } }

    [SerializeField]
    private int numRounds;
    public int NumRounds { get { return numRounds; } set { numRounds = value; } }

    public Player[] players;
    private List<Player> Allplayers { get { return players.ToList(); } }


    [ContextMenu("Set 1 Player")]
    void OnePlayer() { SetNumPlayers(1); }
    [ContextMenu("Set 2 Players")]
    void TwoPlayers() { SetNumPlayers(2); }
    [ContextMenu("Set 3 Players")]
    void ThreePlayers() { SetNumPlayers(3); }
    [ContextMenu("Set 4 Players")]
    void FourPlayers() { SetNumPlayers(4); }

    public void SetNumPlayers(int numPlayers)
    {
        NumPlayers = numPlayers;
        players = new Player[numPlayers];
        for (int i = 0; i < numPlayers; i++)
        {
            Player player;
            GameObject go = GameObject.Find("Player" + i);
            if (go == null)
            {
                go = Instantiate(playerPrefab);
            }
            player = go.GetComponent<Player>();
            player.name = $"Player{i}";
            player.gameObject.name = $"Player{i}";
            players[i] = player;
        }
        Allplayers.ForEach(player => player.setRounds(numRounds));
    }

    public void SetNumRounds(int numRounds)
    {
        NumRounds = numRounds;
    }

    public Player GetPlayer(int player)
    {
        return players[player];
    }
    public int PlayerSub(int player)
    {
        return players[player].Subtotal;
    }

    public void SetPlayerTees(int player, int tees)
    {
        players[player].Tees = tees;
    }

    public int PlayerTotal(int player)
    {
        return players[player].Total;
    }

    public void SetPlayerName(int player, string name)
    {
        players[player].Name = name;
    }
}
