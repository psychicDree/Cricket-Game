using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour
{

    protected UIManager uiManager;

    public UIManager UIManager
    {
        set => uiManager = value;
    }
    public virtual void OnEnter()
    {

    }

    public virtual void OnPause()
    {

    }

    public virtual void OnResume()
    {

    }

    public virtual void OnExit()
    {

    }
}
