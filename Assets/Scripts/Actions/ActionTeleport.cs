using UnityEngine;

public class ActionTeleport : MonoBehaviour {

    public Transform destination;
    public Vector3 offsetPosition = new Vector3(0, 1, 0);

    public bool activated;
    public string teleportSound;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !PlayerController.instance.teleported) {
            AudioManager.instance.Play(teleportSound);
            other.transform.position = destination.position + offsetPosition;
            PlayerController.instance.teleported = true;
            activated = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (!activated) {
            PlayerController.instance.teleported = false;
        } else activated = false;
    }
}
