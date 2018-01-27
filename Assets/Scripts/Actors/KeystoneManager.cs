using UnityEngine;

public class KeystoneManager : MonoBehaviour {

    public BaseElement element;
    public MeshRenderer meshRenderer;
    private SphereCollider _collider;
    private ParticleSystem _particleSystem;

    void Start() {
        _collider = GetComponent<SphereCollider>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            Debug.Log("here");
            other.GetComponent<PlayerController>().keystones.Add(this.gameObject);
            _particleSystem.Stop();
            _collider.enabled = false;
            meshRenderer.enabled = false;
        }
    }
}
