using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private Button _loginButton;
    public override void OnEnter()
    {
        _loginButton = GameObject.Find("LoginButton").GetComponent<Button>();
        _loginButton.onClick.AddListener(OnLoginClick);

    }

    private void OnLoginClick()
    {
        uiManager.PushPanel(UIPanelType.Login);
    }
}
