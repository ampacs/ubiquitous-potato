using UnityEngine;

public class BaseElement : MonoBehaviour {

    public enum ElementType {
        None,Air,Earth,Fire,Water
    }

    public GameObject action;

    public ElementType type { get; protected set; }
    [SerializeField]
    protected ElementType _type;

    static public ElementType getCounterType (ElementType type) {
        ElementType counter;
        switch (type) {
            case ElementType.Air:
                counter = ElementType.Earth;
                break;
            case ElementType.Earth:
                counter = ElementType.Air;
                break;
            case ElementType.Fire:
                counter = ElementType.Water;
                break;
            case ElementType.Water:
                counter = ElementType.Fire;
                break;
            default:
                counter = ElementType.None;
                break;
        }
        return counter;
    }

    public ElementType getCounterType () {
        return BaseElement.getCounterType(type);
    }

    public void Activate () {
        BaseAction baseAction = action.GetComponent<BaseAction>();
        GameObject currentAction = (GameObject)Instantiate(action, PlayerController.instance.transform.position + baseAction.positionOffsetMultiplier * PlayerController.instance.transform.forward, Quaternion.LookRotation(PlayerController.instance.transform.forward));
    }

    void Awake() {
        type = _type;
    }
    void OnValidate() {
        type = _type;
    }
}
