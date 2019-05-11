using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DestroyByReflesher : MonoBehaviour {
    private void Start () {
        Reflesher.refleshSubject.Subscribe(l =>
        {
            Destroy(gameObject,l);
        }).AddTo(this);
	}
}
