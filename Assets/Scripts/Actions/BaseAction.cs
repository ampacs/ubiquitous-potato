using UnityEngine;

public abstract class BaseAction : MonoBehaviour {

    public ParticleSystem particleSystem;
    public string[] soundEffects;

    public abstract bool Condition ();

    public abstract void Activate ();

    public abstract void Deactivate ();

}
