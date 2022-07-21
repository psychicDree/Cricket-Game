using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class UIPanelInfo :ISerializationCallbackReceiver {
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;

    public string path;

    public void OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
