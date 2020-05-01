using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    private static int player_count;

    //This method deals with creating the number of players in the game.  the value is grabbed from the user selecting in menu.
    public static int PlayerCount {
        get {
            return player_count;
        }
        set {
            player_count = value;
        }
    }
}
