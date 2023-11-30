using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    protected int level { get; private set; }

    public void Init(int level)
    {
        this.level = level;
        OnInit();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        OnHide();
    }

    protected virtual void OnInit() { }

    protected virtual void OnShow() { }

    protected virtual void OnHide() { }
}