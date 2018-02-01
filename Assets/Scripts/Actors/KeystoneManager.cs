using UnityEngine;

public class KeystoneManager : MonoBehaviour {

    public bool activated;
    public bool rotate;
    public float angularSpeed = 1f;
    public float spacing = 1f;
    public Vector3 offset;
    public BaseElement element;
    public MeshRenderer meshRenderer;
    public ParticleSystem particlesSystem;
    private SphereCollider _collider;

    private Rigidbody _rigidbody;
    private Transform _transform;
    public Transform target;


    public void Activate () {
        //if (particlesSystem != null) particlesSystem.Play();
        //meshRenderer.enabled = true;
        activated = true;
    }

    public void Deactivate () {
        //if (particlesSystem != null) particlesSystem.Stop();
        //meshRenderer.enabled = false;
        activated = false;
    }

    public void AddElementToPlayer () {
        if (!PlayerController.instance.GetComponent<PlayerController>().elements.Contains(element))
            PlayerController.instance.GetComponent<PlayerController>().elements.Add(element);
    }

    public void RemoveElementFromPlayer () {
        if (PlayerController.instance.GetComponent<PlayerController>().elements.Contains(element))
            PlayerController.instance.GetComponent<PlayerController>().elements.Remove(element);
    }

    void Start() {
        _collider = GetComponent<SphereCollider>();
        _transform = transform;
        if (activated)
            Activate();
        else Deactivate();
    }

    void LateUpdate() {
        if (target != null) {
            if (rotate) {
                Vector3 v = Quaternion.AngleAxis(Time.fixedTime * angularSpeed * -10, Vector3.up) * new Vector3(spacing, 0, 0);
                _transform.position = Vector3.Lerp(_transform.position, target.position + v, 20 * Time.fixedDeltaTime);
            } else if (!Mathf.Approximately(_transform.position.sqrMagnitude - target.position.sqrMagnitude, 0f)) {
                _transform.position = Vector3.Lerp(_transform.position, target.position + offset, 10 * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player" && other.GetComponent<PlayerController>().keystone == null) {
            target = PlayerController.instance.gameObject.transform;
            rotate = true;
            other.GetComponent<PlayerController>().keystone = this.gameObject;
            _collider.enabled = false;
            Deactivate();
        }
    }
}
