using UnityEngine;

public class ActionElementDestroy : BaseAction {

    GameObject other;
    BaseInteractable interactable;

    public override bool Condition () {
        interactable = other.GetComponent<BaseInteractable>();
        if (interactable != null && interactable.interaction == BaseInteractable.GameInteraction.Burnable)
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
