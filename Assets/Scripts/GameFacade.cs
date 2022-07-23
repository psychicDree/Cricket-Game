using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFacade : MonoBehaviour
{
    private AudioManager _audioManager;
    private CameraManager _cameraManager;
    private PlayerManager _playerManager;
    private UIManager _uiManager;
    
    private static GameFacade _instance;
    public static GameFacade Instance => _instance;
    private Vector3 _BallPosition;
    private Button restart;
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
        GameObject.Find("RESTART").GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private void Update()
    {
        _audioManager.OnUpdate();
        _cameraManager.OnUpdate();
        _playerManager.OnUpdate();
        _uiManager.OnUpdate();
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

    public void SetGameData(int over, int totalBalls, int totalBatsmen, int totalBowler, int targetScore)
    {
        _playerManager.SetGameData(over, totalBalls, totalBatsmen, totalBowler, targetScore);
    }

    public GameData GetGameData()
    {
        return _playerManager.GetGameData();
    }
    public int OnBatsmenHit(int run, int hitChance)
    {
        return _playerManager.OnBatsmenHit(run, hitChance);
    }

    public void SetBallPosition(Vector3 hitInfoPoint)
    {
        _BallPosition = hitInfoPoint;
    }

    public Vector3 GetBallPosition()
    {
        return _BallPosition;
    }

    public void OnNextBall()
    {
        _uiManager.PushPanelSync(UIPanelType.Location);
    }

    public string GetResultText()
    {
        return GetGameData().TargetScore < GetGameData().TotalScore ? "Batsmen win": "Bowlers Win" ;
    }
}
