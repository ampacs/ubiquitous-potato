using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor {

    public static PlayerController instance { get; private set; }

    [Header("Movement Values")]
    public float topSpeed;
    public float maxSpeedChange;

    public BaseElement element;

    private Vector3 _targetVelocity;
    private Vector3 _lookDirection;
    private Rigidbody _rigidbody;

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start () { 
        //topSpeed = 5f;
        _rigidbody = GetComponent<Rigidbody>();
        //keystones = new List<Keystone>();
        //elements  = new List<BaseElement>();
    }

    void Update () {
        if (element != null && Input.GetButtonDown("Submit")) {
            element.Activate();
        }
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        _targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * topSpeed;
        Vector3 velocityChange = Vector3.ClampMagnitude(_targetVelocity - new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z), maxSpeedChange);


        if (velocityChange.sqrMagnitude > 0.0001f)
            _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void LateUpdate() {
        if (_targetVelocity.sqrMagnitude > 0.001f) {
            Vector3 direction = _targetVelocity.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 20*Time.fixedDeltaTime);
        }
    }
}
