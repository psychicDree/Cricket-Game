using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlerPanel : BasePanel
{
    private Transform bowlerHolder;
    private GameObject bowler;
    public override void OnEnter()
    {
        base.OnEnter();
        bowlerHolder = transform.Find("BowlersHolder");
        bowler = Resources.Load("Bowler/Bowler") as GameObject;
        SetBowlers();
    }

    private void SetBowlers()
    {
        for (int i = 0; i < GameFacade.Instance.GetGameData().TotalBowlers; ++i)
        {
            Bowler b = Instantiate(bowler, bowlerHolder).GetComponent<Bowler>();
            b.SetBowlerText($"B-{i}");
            b.EnableButton();
            b.OnItemClicked(i, OnBowlerSelected);
            b.gameObject.GetComponent<Image>().color =
                Color.Lerp(Color.blue, Color.grey, Random.Range(0f, 1.0f));
        }
    }
    private Bowler GetBowlerByIndex(int index)
    {
        return bowlerHolder.GetChild(index).GetComponent<Bowler>();
    }
    private void OnBowlerSelected(int selectedIndex)
    {
        Debug.Log($"Bowler- {selectedIndex}");
        uiManager.ShowMessage($"Bowler of Index {selectedIndex} selected");
        GameFacade.Instance.GetGameData().currentBowler = selectedIndex;
        foreach (var item in bowlerHolder.GetComponentsInChildren<Bowler>()) item.DisableButton();
        uiManager.PushPanel(UIPanelType.Delivery);
    }

    public override void OnPause()
    {
        gameObject.SetActive(false);
        base.OnPause();
    }
}
