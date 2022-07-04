using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class CameraMoveController : MonoBehaviour
{
    private static CameraMoveController referance;

    public static float Position => referance.Camera.transform.localPosition.x;
    public static CameraMoveController Referance => referance;

    [SerializeField] private Camera Camera;
    [SerializeField] private UnityEvent unityEvent;

    private void Start()
    {
        referance = this;
        if (!Camera && !TryGetComponent<Camera>(out Camera))
            Debug.LogError("component camera is missing");
    }

    public static void MoveCamera(float position)
    {
        referance.Camera.transform.localPosition = new Vector3(position, referance.Camera.transform.localPosition.y, referance.Camera.transform.localPosition.z);
        referance.unityEvent?.Invoke();
    }
    public static void AddCameraMoveEvent(UnityAction unityAction) => referance.unityEvent.AddListener(unityAction);
    public static void RemoveCameraMoveEvent(UnityAction unityAction) => referance.unityEvent.RemoveListener(unityAction);
}
