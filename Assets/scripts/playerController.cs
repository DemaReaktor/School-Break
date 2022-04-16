using UnityEngine;

public class playerController : MonoBehaviour
{
   [SerializeField] [Range(0.05f,10)]
    private float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.position+=new Vector3(-speed,0,0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < 0)
            transform.position = new Vector3();
        if (transform.position.x > Leveler.Lenth)
            transform.position = new Vector3(Leveler.Lenth,0,0);
    }
}
