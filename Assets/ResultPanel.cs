using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : BasePanel
{
    private TMP_Text gameOverText;
    public override void OnEnter()
    {
        gameObject.SetActive(true);
        gameOverText = transform.Find("GameOverText").GetComponent<TMP_Text>();
        gameOverText.text = GameFacade.Instance.GetResultText();
        base.OnEnter();
    }
}
