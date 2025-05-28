using System.Collections.Generic;

public static class LevelSelector
{
    public static string selectedLevel = "Game2"; // Default level

    private static HashSet<string> unlockedLevels = new HashSet<string>() { "Game2" }; // Default unlocked

    public static bool IsLevelUnlocked(string levelName)
    {
        return unlockedLevels.Contains(levelName);
    }

    public static void UnlockLevel(string levelName)
    {
        if (!unlockedLevels.Contains(levelName))
            unlockedLevels.Add(levelName);
    }
}
