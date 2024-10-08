﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singleton/MasterManger")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings {get{return Instance._gameSettings;}}
}
