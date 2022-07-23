using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private Button _startButton;
    public override void OnEnter()
    {
        _startButton = GameObject.Find("StartButton").GetComponent<Button>();
        _startButton.onClick.AddListener(OnStartClick);

    }

    public override void OnPause()
    {
        gameObject.SetActive(false);
    }

    private void OnStartClick()
    {
        GameFacade.Instance.SetGameData(5, 5*6,5,5,60);
        uiManager.PushPanel(UIPanelType.Bowler);
    }
}
