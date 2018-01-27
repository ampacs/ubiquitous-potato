using UnityEngine;

public abstract class BaseAction : MonoBehaviour {

    public float actionMoment;
    public float actionTime;
    public float positionOffsetMultiplier;
    public Vector3 actionPositionOffset;
    public ParticleSystem particles;
    public string[] soundEffects;

    public abstract bool Condition ();

    public abstract void Activate ();

    public abstract void Deactivate ();

}
