using UnityEngine;
using UnityEngine.UI;

public class LoopBetweenColors : MonoBehaviour {

    public Text text;
    public Color[] colors;
    public float multiplier;
    public AnimationCurve colorOverTime;
    private Color _currentTargetColor;
    private Color _currentColor;
    private int _currentColorIndex;
    private float _time;

    private Color GetNextTargetColor() {
        _currentColorIndex++;
        if (_currentColorIndex >= colors.Length )
            _currentColorIndex = 0;
        return colors[_currentColorIndex];
    }

    void Start() {
        _currentTargetColor = colors[1];
        text.color = colors[0];
    }

    // Update is called once per frame
    void Update () {
        _time += multiplier * Time.fixedDeltaTime;
        if (_time > 1f) {
            _time -= 1f;
            _currentTargetColor = GetNextTargetColor();
        }
        _currentColor = Color.Lerp(_currentColor, _currentTargetColor, colorOverTime.Evaluate(_time));
        text.color = _currentColor;
    }
}
