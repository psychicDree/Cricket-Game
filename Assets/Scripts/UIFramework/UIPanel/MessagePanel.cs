using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : BasePanel
{
    private TMP_Text _text;
    private int showTime = 2;
    private string message = null;
    public override void OnEnter()
    {
        _text = GetComponent<TMP_Text>();
        _text.enabled = false;
        uiManager.InjectMsgPanel(this);
    }

    private void Update()
    {
        if (message != null)
        {
            ShowMessage(message);
            message = null;
        }
    }

    public void ShowMessageSync(string msg)
    {
        message = msg;
    }
    public void ShowMessage(string msg)
    {
        _text.CrossFadeAlpha(1, 0.2f, false);
        _text.text = msg;
        _text.enabled = true;
        Invoke(nameof(Hide),showTime);
    }

    private void Hide()
    {
        _text.CrossFadeAlpha(0, 1, false);
    }
}
