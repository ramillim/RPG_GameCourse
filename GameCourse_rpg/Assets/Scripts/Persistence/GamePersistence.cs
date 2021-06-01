using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    GameData _gameData;
    void Start() => LoadGameFlags();

    void OnDisable() => SaveGameFlags();

    void SaveGameFlags()
    {
        Debug.Log("Saving Game Flags");
        
        var json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving Game Flags Complete");
    }

    void LoadGameFlags()
    {
        var json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
            _gameData = new GameData();
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
    }
}