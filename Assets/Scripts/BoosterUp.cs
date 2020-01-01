using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterUp : MonoBehaviour
{
    public float ImpulseForce = 10000;
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player"){
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * ImpulseForce, ForceMode.Impulse);
        }
    }
}
