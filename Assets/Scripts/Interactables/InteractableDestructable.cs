using UnityEngine;

public class InteractableDestructable : BaseInteractable {

    public bool activateStateChange;

    public float enabledTime = 2f;
    public float respawnTime = 3f;
    private bool _alive;
    private float _momentOfBirth;
    private float _momentOfDeath;
    private Animator _animator;
    private Collider _collider;
    private bool updateOn;


    public override void Activate () {
        activated = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        updateOn = true;
        //enabled = true;
        //AudioManager.instance.Play(soundEffects[0]);
    }

    void Start() {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        _momentOfBirth = Time.time;
        _alive = true;
        activated = false;
        updateOn = true;
    }

    void Update() {
        if (updateOn) {
            //AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            //int growingAnimID = Animator.StringToHash("Grass_Growing");
            //int dyingAnimID   = Animator.StringToHash("Grass_Dying");
            //int deadAnimID    = Animator.StringToHash("Grass_Dead");
            //int normalAnimID  = Animator.StringToHash("Grass_Normal");

            if (activateStateChange) {
                Activate();
                activateStateChange = false;
            }

            if (activated) {
                if (Time.time - momentOfInteration > interationTime) {
                    _alive = false;
                    activated = false;
                    _momentOfDeath = Time.time;
                }
            } else if (!_alive && Time.time - _momentOfDeath > respawnTime) {
                _alive = true;
                _momentOfBirth = Time.time;
            }

            if (!_alive) {
                _animator.SetBool("Alive", false);
                _collider.enabled = false;
            } else {
                //Debug.Log("Growing up!");
                _animator.SetBool("Alive", true);
                _collider.enabled = true;
            }

            if (_alive && !activated && Time.time - _momentOfBirth > enabledTime && Time.time - momentOfInteration > enabledTime) {
                //this.enabled = false;
                updateOn = false;
            }
        }
    }
}
