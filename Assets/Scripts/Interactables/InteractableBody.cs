 using UnityEngine;

public class InteractableBody : BaseInteractable {

    public float forceMultiplier;

    public override void Activate () {
        this.enabled = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddForceAtPosition(directionOfInteraction * forceMultiplier, centerOfInteraction, ForceMode.Impulse);
    }

    void Update() {
        if (Time.time - momentOfInteration > interationTime) {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.enabled = false;
        }
    }
}
