using UnityEngine;

public class Decor : MonoBehaviour
{
    private GameObject brother;
    private float distance;

    private void Start()
    {

        brother = new GameObject();
        brother.transform.SetParent(transform);

        brother.AddComponent(typeof(RectTransform));
        brother.transform.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        distance = transform.GetComponent<SpriteRenderer>().size.x;
        brother.transform.GetComponent<RectTransform>().localPosition = new Vector3(distance, 0,0);

        brother.AddComponent(typeof(SpriteRenderer));
        brother.transform.GetComponent<SpriteRenderer>().material = transform.GetComponent<SpriteRenderer>().material;
        brother.transform.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteRenderer>().sprite;
        brother.transform.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder;
        brother.transform.GetComponent<SpriteRenderer>().drawMode = transform.GetComponent<SpriteRenderer>().drawMode;
        brother.transform.GetComponent<SpriteRenderer>().size = transform.GetComponent<SpriteRenderer>().size;

        CameraMoveController.AddCameraMoveEvent(CameraMove);
    }

    public void CameraMove()
    {
        float x = transform.GetComponent<RectTransform>().localPosition.x;
        float camera = CameraMoveController.Position;
        float player = PlayerController.Referance.transform.position.x;

        transform.GetComponent<RectTransform>().localPosition = new Vector3(
            (int)((player + camera)/distance)* distance,
             transform.GetComponent<RectTransform>().localPosition.y, transform.GetComponent<RectTransform>().localPosition.z);
    }
}
