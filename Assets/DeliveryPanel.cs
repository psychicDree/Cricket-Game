using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPanel : BasePanel
{
    private Button fastType;
    private Button spinType;
    public override void OnEnter()
    {
        fastType = transform.Find("DeliveryType/Type1").GetComponent<Button>();
        spinType = transform.Find("DeliveryType/Type2").GetComponent<Button>();
        fastType.onClick.RemoveAllListeners();
        spinType.onClick.RemoveAllListeners();
        fastType.onClick.AddListener(OnFastTypeClicked);
        spinType.onClick.AddListener(OnSpinTypeClicked);
        SetTypeText();
        base.OnEnter();
    }

    private void OnSpinTypeClicked()
    {
        GameFacade.Instance.GetGameData().currentDeliveryType = DeliveryType.Spin;
        uiManager.ShowMessage($"Bowler Choose {DeliveryType.Spin.ToString()}");
        uiManager.PushPanelSync(UIPanelType.Location);
    }

    private void OnFastTypeClicked()
    {
        GameFacade.Instance.GetGameData().currentDeliveryType = DeliveryType.Fast;
        uiManager.ShowMessage($"Bowler Choose {DeliveryType.Fast.ToString()}");
        uiManager.PushPanelSync(UIPanelType.Location);
    }

    private void SetTypeText()
    {
        fastType.transform.GetChild(0).GetComponent<TMP_Text>().text = DeliveryType.Fast.ToString();
        spinType.transform.GetChild(0).GetComponent<TMP_Text>().text = DeliveryType.Spin.ToString();
    }
    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnPause()
    {
        gameObject.SetActive(false);
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
}
