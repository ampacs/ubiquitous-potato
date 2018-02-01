using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithTransmitTrigger : MonoBehaviour {

    public MonolithController monolithController;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            monolithController.keystone.GetComponent<KeystoneManager>().AddElementToPlayer();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            monolithController.keystone.GetComponent<KeystoneManager>().RemoveElementFromPlayer();
        }
    }
}
