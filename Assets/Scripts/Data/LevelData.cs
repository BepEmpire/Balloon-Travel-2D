using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int[] scoresForStars = { 500, 1000, 1500 };
    public bool isUnlocked;
    public int starsEarned;
    
    public int CalculateStars(int score)
    {
        if (score >= scoresForStars[2]) return 3;
        if (score >= scoresForStars[1]) return 2;
        if (score >= scoresForStars[0]) return 1;
        return 0;
    }
}
