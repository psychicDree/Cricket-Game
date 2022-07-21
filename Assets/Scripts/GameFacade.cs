using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private AudioManager _audioManager;
    private CameraManager _cameraManager;
    private PlayerManager _playerManager;
    private UIManager _uiManager;
    private GameplayManager _gameplayManager;
    
    private static GameFacade _instance;
    public static GameFacade Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
    private void Start()
    {
        OnInitManager();
    }

    private void OnInitManager()
    {
        _audioManager = new AudioManager(this);
        _cameraManager = new CameraManager(this);
        _playerManager = new PlayerManager(this);
        _uiManager = new UIManager(this);
        _gameplayManager = new GameplayManager(this);
        
        _audioManager.OnInit();
        _cameraManager.OnInit();
        _playerManager.OnInit();
        _uiManager.OnInit();
        _gameplayManager.OnInit();
    }

    private void Update()
    {
        _audioManager.OnUpdate();
        _cameraManager.OnUpdate();
        _playerManager.OnUpdate();
        _uiManager.OnUpdate();
        _gameplayManager.OnUpdate();
    }
    private void OnDestroy()
    {
        OnDestroyManager();
    }
    private void OnDestroyManager()
    {
        _audioManager.OnDestroy();
        _cameraManager.OnDestroy();
        _playerManager.OnDestroy();
        _uiManager.OnDestroy();
        _gameplayManager.OnDestroy();
    }

    public void SetGameData(int over, int ballPerOver, int totalBatsmen, int totalBowler, int targetScore)
    {
        _gameplayManager.SetGameData(over, ballPerOver, totalBatsmen, totalBowler, targetScore);
    }

    public GameData GetGameData()
    {
        return _gameplayManager.GetGameData();
    }
}
