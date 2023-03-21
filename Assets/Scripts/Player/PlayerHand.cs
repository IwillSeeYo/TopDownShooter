using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private const float _defaultScale = 1f;
    private const float _reflectionAngle = 90f;

    [SerializeField] private Transform _handPosition;

    private void Update()
    {
        HandleAim();
    }

    private void HandleAim()
    {
        Vector3 moucePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 handDirection = moucePosition - transform.position;
        float angle = Mathf.Atan2(handDirection.y, handDirection.x) * Mathf.Rad2Deg;
        _handPosition.eulerAngles = new Vector3(0, 0, angle);
        float scaleY = Mathf.Abs(angle) > _reflectionAngle ? -_defaultScale : _defaultScale;
        _handPosition.localScale = new Vector3(_defaultScale, scaleY, _defaultScale);
    }
}