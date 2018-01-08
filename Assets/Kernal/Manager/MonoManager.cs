/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: MonoManager
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: ����������ҪMono��Manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoManager : MonoBehaviour
{
    //��������Timer,�����Ĵ�TimerManager�е���
    public Callback_0 onUpdate;
    //��������GUI,�����Ĵ�GUIManager�е���
    public Callback_0 onDraw;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (onUpdate != null)
            onUpdate();
    }

    void OnGUI()
    {
        if (onDraw != null)
            onDraw();
    }
}
