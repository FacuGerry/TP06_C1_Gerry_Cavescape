using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "PlayerPrefs/PlayerSettings")]

public class PlayerPrefsSo : ScriptableObject
{
    [Header("Stats")]
    public int maxCoinsCollected;
    public int gamesPlayed;
    public int gamesWon;

    [Header("Mini Map")]
    public int miniMapColorR;
    public int miniMapColorG;
    public int miniMapColorB;
}
