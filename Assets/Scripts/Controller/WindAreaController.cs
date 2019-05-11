using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAreaController : MonoBehaviour
{
    public float windPower;

    private GameController gameController;
    private Vector2 windPowerVec2;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        var parentRad = (transform.root.gameObject.transform.localEulerAngles.z + 90) * Mathf.Deg2Rad;
        windPowerVec2.x = Mathf.Cos(parentRad) * windPower;
        windPowerVec2.y = Mathf.Sin(parentRad) * windPower;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!gameController.isJumped&&other.tag=="Player") return;
        if (other.gameObject.layer == 9) return;
        var rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody == null) return;
        rigidbody.AddForce(new Vector3(windPowerVec2.x, windPowerVec2.y, 0));
    }
}
