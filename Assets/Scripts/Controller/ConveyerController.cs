using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerController : MonoBehaviour
{
    public float power;

    // Update is called once per frame
    void OnCollisionStay(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(power, 0.0f, 0.0f));
    }


}
