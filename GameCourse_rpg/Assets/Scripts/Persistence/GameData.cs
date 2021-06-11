﻿using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<GameFlagData> GameFlagDatas;
    public List<InspectableData> InspectableDatas;

    public GameData()
    {
        GameFlagDatas = new List<GameFlagData>();
        //GameFlagDatas.Add(new GameFlagData(){Value = "crunchy 1", Name = "flagname"});
        InspectableDatas = new List<InspectableData>();
    }
}