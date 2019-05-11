using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorController : MonoBehaviour
{
    public float moveAngle;
    public float movePower;
    new public Rigidbody rigidbody;

    private float moveRad;
    private float time;
    private float nowPower;

    void Start()
    {
        moveRad = moveAngle * Mathf.Deg2Rad;
        time = 0;
        nowPower = movePower;
    }

    void Update()
    {
        time += Time.deltaTime;
        nowPower = -(Mathf.PingPong(time, movePower * 2) - movePower);
        var powerX = Mathf.Cos(moveRad) * nowPower;
        var powerY = Mathf.Sin(moveRad) * nowPower;

        rigidbody.velocity = new Vector3(powerX, powerY, 0);
    }
}
