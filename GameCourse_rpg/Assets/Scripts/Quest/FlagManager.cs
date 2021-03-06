using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlagManager:  MonoBehaviour
{
    [SerializeField] List<GameFlag> _allFlags;
    Dictionary<string, GameFlag> _flagsByName;
    public static FlagManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    #if UNITY_EDITOR
    void OnValidate()
    {
        Extensions.GetAllInstances<GameFlag>();
    }
    #endif
    void Start()
    {
        _flagsByName = _allFlags.ToDictionary(k => k.name.Replace(" ", ""),
            v => v);
    }

    public void Set(string flagName, string value)
    {
        if(_flagsByName.TryGetValue(flagName,out var flag) == false)
        {
            Debug.LogError($"Flag not found {flagName}");
        }

        if (flag is IntGameFlag intGameFlag)
        {
            if(int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
        else if( flag is BoolGameFlag boolGameFlag)
        {
            if(bool.TryParse(value, out var boolGameValue))
                boolGameFlag.Set(boolGameValue);
        }
        else if (flag is StringGameFlag stringGameFlag)
        {
            stringGameFlag.Set(value);
        }
        else if(flag is DecimalGameFlag decimalGameFlag)
        {
            if(decimal.TryParse(value, out var decimalGameValue))
                decimalGameFlag.Set(decimalGameValue);
                
        }
    }

    public void Bind(List<GameFlagData> gameFlagDatas)
    {
        foreach (var flag in _allFlags)
        {
            var data = gameFlagDatas.FirstOrDefault(t => t.Name == flag.name);
            if (data == null)
            {
                data = new GameFlagData() {Name = flag.name};
                gameFlagDatas.Add(data);
            }
            flag.Bind(data);
        }
    }
}