using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public static class Reflesher{
    public static Subject<int> refleshSubject=new Subject<int>();
    public static void Reflesh()
    {
        refleshSubject.OnNext(0);
        Debug.Log("Refleshed objects.");
    }
}
