using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBullet : BaseHazard {

    public Vector3 directionOfMovement;
    public float speed;
    public float lifetime;

    private Rigidbody _rigidbody;
    private float _momentOfBirth;

    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _momentOfBirth = Time.time;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        if (gameObject != null) {
            if (triggered && _other != null && _other.tag == "Prop") {
                InteractableBody body = _other.GetComponent<InteractableBody>();
                body.directionOfInteraction = directionOfMovement * 2;
                body.centerOfInteraction = transform.position;
                body.Activate();
                triggered = false;
            }
            _rigidbody.MovePosition(transform.position + directionOfMovement*speed*Time.deltaTime);
            if (Time.time - _momentOfBirth > lifetime || triggered)
                Destroy(this.gameObject);
        }
    }
}
