using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithController : Actor {

    public bool activated;
    public Vector3 keystoneOffset;

    public BoxCollider _boxCollider;
    public SphereCollider _sphereCollider;

    public void Activate () {
        _sphereCollider.enabled = true;
        activated = true;
    }

    public void Deactivate () {
        _sphereCollider.enabled = false;
        activated = false;
    }

    void Start () {
        if (activated) {
            Activate();
        } else {
            Deactivate();
        }
    }

    void FixedUpdate() {

    }
}
