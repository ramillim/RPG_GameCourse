using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    public GameData _gameData;
    void Start() => LoadGame();

    void OnDisable() => SaveGame();

    void SaveGame()
    {
        Debug.Log("Saving Game Flags");
        
        var json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving Game Flags Complete");
    }

    void LoadGame()
    {
        var json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
            _gameData = new GameData();
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
        InspectionManager.Bind(_gameData.InspectableDatas);
        Inventory.Instance.Bind(_gameData.SlotDatas);
    }
}