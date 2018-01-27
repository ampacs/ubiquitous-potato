using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float playerFollowSpeed = 1;
    public Vector3 offset;
    Transform _playerTransform;

    void Start () {
        _playerTransform = PlayerController.instance.transform;
        transform.position = _playerTransform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 position;
        transform.position -= offset;
        position = Vector3.Lerp(transform.position, _playerTransform.position, playerFollowSpeed * Time.fixedDeltaTime);
        transform.position = position + offset;
    }
}
