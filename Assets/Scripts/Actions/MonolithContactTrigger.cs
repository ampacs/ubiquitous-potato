using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithContactTrigger : MonoBehaviour {

    public MonolithController monolithController;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Jump")) {
            if (monolithController.activated) {
                monolithController.keystone.GetComponent<KeystoneManager>().Deactivate();
                other.gameObject.GetComponent<PlayerController>().keystone = monolithController.keystone;
                monolithController.keystone.GetComponent<KeystoneManager>().RemoveElementFromPlayer();
                monolithController.keystone = null;
                monolithController.Deactivate();
            } else if (other.gameObject.GetComponent<PlayerController>().keystone != null) {
                monolithController.keystone = other.gameObject.GetComponent<PlayerController>().keystone;
                other.gameObject.GetComponent<PlayerController>().keystone = null;
                monolithController.keystone.transform.position = transform.position + monolithController.keystoneOffset;
                monolithController.keystone.GetComponent<KeystoneManager>().Activate();
                monolithController.Activate();
            }
        }
    }
}
