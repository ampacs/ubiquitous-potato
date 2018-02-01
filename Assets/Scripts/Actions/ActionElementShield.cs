using UnityEngine;

public class ActionElementShield : BaseAction {

    GameObject other;
    BaseInteractable interactable;
    Rigidbody _rigidbody;
    Rigidbody _playerRigidbody;

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

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _playerRigidbody = PlayerController.instance.gameObject.GetComponent<Rigidbody>();
    }

    void Update() {
        if (Time.time - actionMoment > actionTime) {
            if (audioSource != null)
                audioSource.Stop();
            Destroy(this.gameObject);
        }
        _rigidbody.velocity = _playerRigidbody.velocity;
    }

    void OnTriggerEnter(Collider other) {
        this.other = other.gameObject;
        if (Condition()) {
            interactable.Activate();
        }
    }
}
