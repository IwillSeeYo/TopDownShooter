using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Transform _handPosition;

    private void Update()
    {
        HandleAim();
    }

    private void HandleAim()
    {
        Vector3 moucePosition = GetAimPosition();
        Vector3 handDirection = (moucePosition - transform.position).normalized;
        float angle = Mathf.Atan2(handDirection.y, handDirection.x) * Mathf.Rad2Deg;
        _handPosition.eulerAngles = new Vector3(0, 0, angle);

        GetHandLocalScale(angle);
    }

    private void GetHandLocalScale(float angle)
    {
        int reflectionAngle = 90;
        float scaleX = 1;
        Vector3 handLocalScale = Vector3.one;
        handLocalScale.y = angle > reflectionAngle || angle < -reflectionAngle ? -scaleX : scaleX;
        _handPosition.localScale = handLocalScale;
    }

    private Vector3 GetAimPosition()
    {
        Vector3 handPosition = GetMousePosition(Input.mousePosition, Camera.main);
        handPosition.z = 0;
        return handPosition;
    }

    private Vector3 GetMousePosition(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
