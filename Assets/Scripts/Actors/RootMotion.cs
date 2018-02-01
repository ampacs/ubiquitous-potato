using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotion : MonoBehaviour {

    Animator _animator;
    public AnimationCurve yAxisMovement = new AnimationCurve(new Keyframe(0f, 1f, 0f, 0f),
                                                             new Keyframe(0.083333336f, 1.0273799f, 0.08622714f, 0.08622714f),
                                                             new Keyframe(0.21666667f, 1.6624415f, 2.5605114f, 2.5605114f),
                                                             new Keyframe(0.23333333f, 1.6844051f, -0.032360163f, -0.032360163f),
                                                             new Keyframe(0.36666667f, 1.3173335f, -2.92383f, -2.92383f),
                                                             new Keyframe(0.4f, 1.209086f, -3.3967369f, -3.3967369f),
                                                             new Keyframe(0.48333332f, 1.021999f, -0.0040823813f, -0.0040823813f),
                                                             new Keyframe(0.53333336f, 1.019834f, -0.0768578f, -0.0768578f),
                                                             new Keyframe(0.6333333f, 1.0088307f, -0.12058272f, -0.12058272f),
                                                             new Keyframe(0.75f, 1f, 0f, 0f));
    public AnimationCurve xRotationAxis = new AnimationCurve(new Keyframe(0f, -0.3618946f, 48.749954f, 48.749954f),
                                                             new Keyframe(0.16666667f, 24.961237f, 53.63603f, 53.63603f),
                                                             new Keyframe(0.21666667f, 26.48425f, 7.622776f, 7.622776f),
                                                             new Keyframe(0.36666667f, 17.959751f, -118.23804f, -118.23804f),
                                                             new Keyframe(0.4f, 10.141097f, -337.6347f, -337.6347f),
                                                             new Keyframe(0.43333334f, -3.6661277f, -477.5523f, -477.5523f),
                                                             new Keyframe(0.53333336f, -21.545593f, 19.85151f, 19.85151f),
                                                             new Keyframe(0.55f, -20.987375f, 44.353783f, 44.353783f),
                                                             new Keyframe(0.6333333f, -15.230001f, 91.07067f, 91.07067f),
                                                             new Keyframe(0.7f, -8.250481f, 116.55334f, 116.55334f),
                                                             new Keyframe(0.75f, -0.3618946f, 154.89777f, 154.89777f));
    public AnimationCurve zRotationAxis = new AnimationCurve(new Keyframe(0f, -0.23612976f, 0f, 0f),
                                                             new Keyframe(0.16666667f, -0.031921063f, 1.1607653f, 1.1607653f),
                                                             new Keyframe(0.21666667f, 0f, 0f, 0f),
                                                             new Keyframe(0.36666667f, 0f, 0f, 0f),
                                                             new Keyframe(0.4f, 0f, 0f, 0f),
                                                             new Keyframe(0.43333334f, 0f, 0f, 0f),
                                                             new Keyframe(0.53333336f, 0f, 0f, 0f),
                                                             new Keyframe(0.55f, 0f, 0f, 0f),
                                                             new Keyframe(0.6333333f, 0f, 0f, 0f),
                                                             new Keyframe(0.7f, -0.14319238f, -2.973996f, -2.973996f),
                                                             new Keyframe(0.75f, -0.2361298f, 0f, 0f));


    void Start () {
        _animator = GetComponent<Animator>();
    }

    void OnAnimatorMove() {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        //int standingAnimIDs = Animator.StringToHash("Player_Standing");
        int runningAnimIDs = Animator.StringToHash("Player_Running");


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            if (stateInfo.shortNameHash == runningAnimIDs) {
                transform.rotation = Quaternion.Euler(xRotationAxis.Evaluate(stateInfo.normalizedTime), transform.rotation.eulerAngles.y, zRotationAxis.Evaluate(stateInfo.normalizedTime));
                transform.position = PlayerController.instance.transform.position + new Vector3(0f, yAxisMovement.Evaluate(stateInfo.normalizedTime) - 1, 0f);
            } else {
                transform.rotation = Quaternion.Slerp(transform.rotation, PlayerController.instance.transform.rotation, 10*Time.fixedDeltaTime);
                transform.position = Vector3.Slerp(transform.position, PlayerController.instance.transform.position, 10*Time.fixedDeltaTime);
            }
        } else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
            if (stateInfo.shortNameHash == runningAnimIDs) {
                transform.rotation = Quaternion.Euler(xRotationAxis.Evaluate(stateInfo.normalizedTime), transform.rotation.eulerAngles.y, zRotationAxis.Evaluate(stateInfo.normalizedTime));
                transform.position = PlayerController.instance.transform.position + new Vector3(0f, yAxisMovement.Evaluate(stateInfo.normalizedTime) - 1, 0f);
            } else {
                transform.rotation = Quaternion.Slerp(transform.rotation, PlayerController.instance.transform.rotation, 10*Time.fixedDeltaTime);
                transform.position = Vector3.Slerp(transform.position, PlayerController.instance.transform.position, 10*Time.fixedDeltaTime);
            }
        }
    }
}
