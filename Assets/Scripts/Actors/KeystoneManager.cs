using UnityEngine;

public class KeystoneManager : MonoBehaviour {

    public bool activated;
    public BaseElement element;
    public MeshRenderer meshRenderer;
    public ParticleSystem particlesSystem;
    private SphereCollider _collider;

    public void Activate () {
        if (particlesSystem != null) particlesSystem.Play();
        _collider.enabled = true;
        meshRenderer.enabled = true;
        activated = true;
    }

    public void Deactivate () {
        particlesSystem.Stop();
        _collider.enabled = false;
        meshRenderer.enabled = false;
        activated = false;
    }

    public void AddElementToPlayer () {
        if (!PlayerController.instance.GetComponent<PlayerController>().element == element)
            PlayerController.instance.GetComponent<PlayerController>().element = element;
    }

    public void RemoveElementFromPlayer () {
        if (PlayerController.instance.GetComponent<PlayerController>().element == element)
            PlayerController.instance.GetComponent<PlayerController>().element = null;
    }

    void Start() {
        _collider = GetComponent<SphereCollider>();
        if (activated)
            Activate();
        else Deactivate();
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player" && other.GetComponent<PlayerController>().keystone == null) {
            Debug.Log("here");
            other.GetComponent<PlayerController>().keystone = this.gameObject;
            Deactivate();
        }
    }
}
