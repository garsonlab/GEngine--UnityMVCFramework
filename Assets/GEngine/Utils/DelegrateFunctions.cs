/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: DelegrateFunctions
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */


using System.Collections;
using GEngine.Patterns;
using UnityEngine;


//��Ϣ����
public delegate void MessageHandler(MessageArgs messageArgs);

//��ʱ������
public delegate void TimerHandler(object parm);

//Э�̴���
public delegate Coroutine StartCoroutineHandler(IEnumerator routine);


public delegate void Callback_0();

public delegate void Callback_1<T>(T parm1);

public delegate T T_Callback<T>();