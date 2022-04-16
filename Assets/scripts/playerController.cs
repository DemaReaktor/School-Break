using UnityEngine;

public class playerController : MonoBehaviour
{
   [SerializeField] [Range(0.05f,10)]
    private float speed;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-speed,0,0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3( 0, 0,-speed) * Time.deltaTime;
        if (transform.position.x < 0)
            transform.position = new Vector3(0,0,transform.position.z);
        if (transform.position.x > Leveler.Lenth)
            transform.position = new Vector3(Leveler.Lenth,0, transform.position.z);
        if (transform.position.z < -Leveler.Width)
            transform.position = new Vector3(transform.position.x,0,-Leveler.Width);
        if (transform.position.z > Leveler.Width)
            transform.position = new Vector3(transform.position.x, 0, Leveler.Width);
        for (int index = 0; index < Leveler.SceneLoader.
            PupilFolder.transform.childCount; index++)
            if (Vector3.Distance(Leveler.SceneLoader.PupilFolder.transform.
                GetChild(index).position, transform.position) < 1)
            {
                Vector3 distance = transform.position - Leveler.SceneLoader
                    .PupilFolder.transform.GetChild(index).position;
                transform.position += distance * (1 - distance.magnitude)
                        / (distance.magnitude + 0.01f);
            }
    }

}
