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
        
        _audioManager.OnInit();
        _cameraManager.OnInit();
        _playerManager.OnInit();
        _uiManager.OnInit();
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
    }
}
