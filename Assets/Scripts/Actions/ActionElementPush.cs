using UnityEngine;

public class ActionElementPush : BaseAction {

    GameObject other;
    BaseInteractable interactable;

    public override bool Condition () {
        interactable = other.GetComponent<BaseInteractable>();
        if (interactable != null && interactable.interaction == BaseInteractable.GameInteraction.Pushable)
            return true;
        return false;
    }

    public override void Activate () {
        particles.Play();
    }

    public override void Deactivate () {

    }

    void OnTriggerEnter(Collider other) {
        this.other = other.gameObject;
        if (Condition()) {
            interactable.Activate();
        }
    }
}
