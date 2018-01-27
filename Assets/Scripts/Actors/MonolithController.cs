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
        keystone.GetComponent<KeystoneManager>().AddElementToPlayer();
        activated = true;
    }

    public void Deactivate () {
        _sphereCollider.enabled = false;
        if (keystone != null)
            keystone.GetComponent<KeystoneManager>().RemoveElementFromPlayer();
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
