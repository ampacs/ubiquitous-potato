using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLook : MonoBehaviour {

    Transform parentTransform;
    // Use this for initialization
    void Start () {
        parentTransform = this.transform.parent;
    }
    
    // Update is called once per frame
    void LateUpdate () {
        //transform.rotation = Quaternion.LookRotation(parentTransform.forward);
    }
}
