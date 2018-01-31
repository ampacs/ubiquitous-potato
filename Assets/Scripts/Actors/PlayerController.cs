using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor {

    public static PlayerController instance { get; private set; }
    public GameObject model;

    public bool teleported;

    [Header("Movement Values")]
    public float topSpeed;
    public float maxSpeedChange;

    public BaseElement element;
    private Animator _animator;

    private Vector3 _targetVelocity;
    private Vector3 _lookDirection;
    private Rigidbody _rigidbody;

    void Awake () {
        if (instance == null) {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start () {
        if (model != null)
            _animator = model.GetComponent<Animator>();
        //topSpeed = 5f;
        _rigidbody = GetComponent<Rigidbody>();
        //keystones = new List<Keystone>();
        //elements  = new List<BaseElement>();
    }

    void Update () {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        int standingAnimIDs = Animator.StringToHash("Player_Standing");
        int runningAnimIDs = Animator.StringToHash("Player_Running");

        if (element != null && Input.GetButtonDown("Submit")) {
            element.Activate();
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            if (stateInfo.shortNameHash == standingAnimIDs) {
                _animator.SetTrigger("StartMoving");
            }
        } else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
            if (stateInfo.shortNameHash == runningAnimIDs) {
                _animator.SetTrigger("StopMoving");
            }
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
