using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class WorkerController : MonoBehaviour
{
    [HideInInspector]
    public float jumpAngle;
    [HideInInspector]
    public float jumpPower;
    new public Rigidbody rigidbody;
    public GameObject powerArrowPrafab;
    public float powerArrowInterval;
    public int powerArrowCount;

    private GameObject powerArrowParent;
    private float jumpRad;
    private GameController gameController;

    private void Start()
    {
        powerArrowParent = GameObject.Find("PowerArrowParent");
        jumpRad = jumpAngle * Mathf.Deg2Rad;
        for (int i = 0; i < powerArrowCount; i++)
        {
            var powerArrowObject = Instantiate(powerArrowPrafab);
            powerArrowObject.transform.position = transform.position;
            powerArrowObject.transform.parent = powerArrowParent.transform;
            var powerArrowController = powerArrowObject.GetComponent<PowerArrowController>();
            powerArrowController.JumpArrow(jumpRad, jumpPower, i * powerArrowInterval);
        }
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (gameController.isCleared)
            rigidbody.isKinematic = true;
    }
    public void SubscribeJumpSubject(Subject<int> jumpSubject)
    {
        jumpSubject.Subscribe(_ =>
        {
            Jump();
        }).AddTo(this);
    }

    public void Jump()
    {
        gameObject.layer = 1;
        var powerX = Mathf.Cos(jumpRad);
        var powerY = Mathf.Sin(jumpRad);
        rigidbody.velocity = new Vector3(jumpPower * powerX, jumpPower * powerY, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
            gameController.GameOver();
    }
}
