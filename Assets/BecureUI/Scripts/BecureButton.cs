using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PanelType
{
    PopupPanel,
    L2RPanel
}

public class BecureButton : MonoBehaviour
{
    public PanelType panelType;

    public void ButtonHover()
    {
        UIManager.Instance.ButtonHover();
    }
    public void ButtonClick()
    {
        UIManager.Instance.ButtonClick();
    }

    public void OpenPanel(GameObject Panel)
    {
        if (panelType == PanelType.L2RPanel)
        {
            UIManager.Instance.OpenPanelL2R(Panel);
            return;
        }
        UIManager.Instance.OpenPanel(Panel);
    }

    public void ClosePanel(GameObject Panel)
    {
        if (panelType == PanelType.L2RPanel)
        {
            UIManager.Instance.ClosePanelL2R(Panel);
            return;
        }
        UIManager.Instance.ClosePanel(Panel);
    }
}
