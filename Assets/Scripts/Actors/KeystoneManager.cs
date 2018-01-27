using UnityEngine;

public class KeystoneManager : MonoBehaviour {

    public bool activated;
    public BaseElement element;
    public MeshRenderer meshRenderer;
    private SphereCollider _collider;
    private ParticleSystem _particleSystem;

    public void Activate () {
        _particleSystem.Play();
        _collider.enabled = true;
        meshRenderer.enabled = true;
        activated = true;
    }

    public void Deactivate () {
        _particleSystem.Stop();
        _collider.enabled = false;
        meshRenderer.enabled = false;
        activated = false;
    }

    public void AddElementToPlayer () {
        PlayerController.instance.GetComponent<PlayerController>().elements.Add(element);
    }

    public void RemoveElementFromPlayer () {
        PlayerController.instance.GetComponent<PlayerController>().elements.Remove(element);
    }

    void Start() {
        _collider = GetComponent<SphereCollider>();
        _particleSystem = GetComponent<ParticleSystem>();
        if (activated)
            Activate();
        else Deactivate();
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            Debug.Log("here");
            other.GetComponent<PlayerController>().keystone = this.gameObject;
            Deactivate();
        }
    }
}
