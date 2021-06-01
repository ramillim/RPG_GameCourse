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
        Debug.Log(json);
        Debug.Log("Saving Game Flags Complete");
    }

    void LoadGameFlags()
    {
        _gameData = new GameData();
    }
}