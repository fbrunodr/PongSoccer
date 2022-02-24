using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 impulse = new Vector3(0, 0, 50);
        rigidbody.AddForce(impulse, ForceMode.Impulse);
    }
}
