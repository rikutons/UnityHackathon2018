using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PowerArrowController : MonoBehaviour {

    public void JumpArrow(float jumpRad,float jumpPower,float stopTime)
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        var powerX = Mathf.Cos(jumpRad);
        var powerY = Mathf.Sin(jumpRad);
        rigidbody.velocity = new Vector3(jumpPower * powerX, jumpPower * powerY, 0);
        Observable.Timer(TimeSpan.FromMilliseconds(stopTime)).Subscribe(_ =>
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
        }).AddTo(this);
    }
}
