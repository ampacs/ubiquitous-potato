#define DRAWRAYS
using UnityEngine;

public class PlayerCollisionsManager : MonoBehaviour {

    [System.Serializable]
    private struct Rays {
        public enum Direction { Forward, Backward, Right, Left, Up, Down }
        public Direction direction;
        public float length;
        public float centerOffset;
        public float minimumHitRatio;
        public Vector3[] positionOffset;

        private Vector3 _direction;
        private Vector3[] _positions;

        /**/[HideInInspector]/**/ public RaycastHit[] hits;
        /**/[HideInInspector]/**/ public bool[] hasHit;
        public void Start () {
            _positions = new Vector3[positionOffset.Length];
            hits = new RaycastHit[positionOffset.Length];
            hasHit = new bool[positionOffset.Length];
            switch (direction) {
                case Direction.Forward:
                    _direction = Vector3.forward;
                    break;
                case Direction.Backward:
                    _direction = -Vector3.forward;
                    break;
                case Direction.Right:
                    _direction = Vector3.right;
                    break;
                case Direction.Left:
                    _direction = -Vector3.right;
                    break;
                case Direction.Up:
                    _direction = Vector3.up;
                    break;
                case Direction.Down:
                    _direction = -Vector3.up;
                    break;
            }
        }

        void CalculateRaysPositions () {
            for (int i = 0; i < positionOffset.Length; i++) {
                _positions[i] = positionOffset[i];
                _positions[i].Scale(_direction);
                _positions[i] = PlayerController.instance.transform.TransformPoint(_positions[i]);
            }
        }

        public void CastRays () {
            Vector3 properDirection = PlayerController.instance.transform.TransformDirection(_direction) * Mathf.Sign(length);
            CalculateRaysPositions();
            Debug.Log(_positions[0]);
            for (int i = 0; i < positionOffset.Length; i++) {
                #region DRAWRAYS
                Debug.DrawRay(_positions[i], _direction * (length + centerOffset) * Mathf.Abs(length), Color.green);
                #endregion
                hasHit[i] = Physics.Raycast(_positions[i], _direction, out hits[i], (length + centerOffset) * Mathf.Abs(length));
            }
        }

        public bool IsHit () {
            return GetHitRatio() >= minimumHitRatio;
        }

        public float GetHitRatio () {
            int n = 0;
            for (int i = 0; i < positionOffset.Length; i++)
                if (hasHit[i]) n++;
            return n / (float)positionOffset.Length;
        }

        public float[] GetDistances () {
            float[] vectors = new float[positionOffset.Length];
            for (int i = 0; i < positionOffset.Length; i++)
                if (hasHit[i])
                    vectors[i] = hits[i].distance;
                else vectors[i] = 0;
            return vectors;
        }

        public Vector3[] GetNormals () {
            Vector3[] vectors = new Vector3[positionOffset.Length];
            for (int i = 0; i < positionOffset.Length; i++)
                if (hasHit[i])
                    vectors[i] = hits[i].normal;
                else vectors[i] = Vector3.zero;
            return vectors;
        }

        public Vector3[] GetPoints () {
            Vector3[] vectors = new Vector3[positionOffset.Length];
            for (int i = 0; i < positionOffset.Length; i++)
                if (hasHit[i])
                    vectors[i] = hits[i].point;
                else vectors[i] = Vector3.zero;
            return vectors;
        }
    }

    [SerializeField] Rays isGroundedRays;

    private CapsuleCollider _collider;

    public bool IsGrounded {
        get { return isGroundedRays.IsHit(); }
    }

    void Start() {
        isGroundedRays.Start();
    }

    void FixedUpdate() {
        isGroundedRays.CastRays();
    }
}
