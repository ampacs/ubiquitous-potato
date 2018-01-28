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
    }

    public override void Deactivate () {
    }

    void Awake() {
        //particles.Play();
        actionMoment = Time.time;
        AudioManager.instance.Play(soundEffects[0]);
    }

    void OnTriggerEnter(Collider other) {
        this.other = other.gameObject;
        if (Condition()) {
            interactable.directionOfInteraction = PlayerController.instance.transform.forward;
            interactable.centerOfInteraction = PlayerController.instance.transform.position;
            interactable.Activate();
        }
    }

    void Update() {
        if (Time.time - actionMoment > actionTime) {
            AudioManager.instance.Stop(soundEffects[0]);
            Destroy(this.gameObject);
        }
    }
}
