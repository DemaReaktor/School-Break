using UnityEngine;
using UnityEngine.Events;

public class CameraMoveManager : MonoBehaviour
{
    private static CameraMoveManager referance;
    private static UnityEvent unityEvent;
    private static float y;

    public static float Position => y;
    public static CameraMoveManager Referance => referance;

    [SerializeField] private Camera Camera;

    private void Start()
    {
        referance = this;
        y = Camera.transform.position.y;
    }

    public static void AddCameraMoveEvent(UnityAction unityAction) => unityEvent.AddListener(unityAction);
    public static void RemoveCameraMoveEvent(UnityAction unityAction) => unityEvent.RemoveListener(unityAction);
}
