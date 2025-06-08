using UnityEngine;

public static class PlayerPrefsKeys
{
    public const string DifficultyMode = "DifficultyMode";
    public const string SelectedHero = "SelectedHero";
    public const string LevelAccess1 = "LevelAccess1";
    public const string LevelAccess2 = "LevelAccess2";
    public const string LevelAccess3 = "LevelAccess3";
    public const string LevelAccess4 = "LevelAccess4";
    public const string LevelAccess5 = "LevelAccess5";
    public const string LevelAccess6 = "LevelAccess6";
    public const string LevelAccess7 = "LevelAccess7";
    public const string LevelAccess8 = "LevelAccess8";
    public const string LevelAccess9 = "LevelAccess9";
    public const string LevelAccess10 = "LevelAccess10";
}

public static class GamePreferences
{

    public static int DifficultyMode
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.DifficultyMode, (int)GameKeys.DifficultyMode.Medium);
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.DifficultyMode, value);
            PlayerPrefs.Save();
        }
    }
    public static int SelectedHero
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.SelectedHero, -1);
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.SelectedHero, value);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess1
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess1, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess1, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess2
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess2, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess2, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess3
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess3, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess3, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess4
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess4, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess4, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess5
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess5, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess5, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess6
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess6, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess6, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess7
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess7, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess7, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess8
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess8, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess8, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess9
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess9, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess9, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess10
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelAccess10, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelAccess10, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

}