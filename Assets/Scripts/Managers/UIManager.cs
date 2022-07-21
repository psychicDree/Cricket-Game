using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManager : BaseManager
{
    public UIManager(GameFacade facade) : base(facade)
    {
        ParseUIPanelTypeJson();
    }
    
    private static UIManager _instance;
    private MessagePanel _msgPanel;
    
    public override void OnInit()
    {
       PushPanel(UIPanelType.Start);
       PushPanel(UIPanelType.Message);
    }

    public override void OnDestroy()
    {
        
    }
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;
    private Dictionary<UIPanelType, BasePanel> panelDict;
    private Stack<BasePanel> panelStack;
  


   

    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
        
    }

    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

    }
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
          
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            instPanel.GetComponent<BasePanel>().UIManager = this;
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }

    }

    public void ShowMessage(string msg)
    {
        if (string.IsNullOrWhiteSpace(msg))
        {
            Debug.Log("Message cannot be Empty...");
            return;
        }
        _msgPanel.ShowMessage(msg);
    }

    public void InjectMsgPanel(MessagePanel msgPanel)
    {
        this._msgPanel = msgPanel;
    }
    
    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList) 
        {
            //Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }
    }
   
}
