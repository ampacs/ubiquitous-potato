using UnityEngine;

public class ActionElementShield : BaseAction {

    GameObject other;
    BaseInteractable interactable;

    public override bool Condition () {
        interactable = other.GetComponent<BaseInteractable>();
        if (interactable != null && interactable.interaction == BaseInteractable.GameInteraction.Shieldable)
            return true;
        return false;
    }

    public override void Activate () {
    }

    public override void Deactivate () {
    }

    void Awake() {
        //particles.Play();
        actionMoment = Time.time;
        AudioManager.instance.Play(soundEffects[0]);
    }

    void Update() {
        if (Time.time - actionMoment > actionTime) {
            AudioManager.instance.Stop(soundEffects[0]);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        this.other = other.gameObject;
        if (Condition()) {
            interactable.Activate();
        }
    }
}
