using UnityEngine;

public class playerController : MonoBehaviour
{
   [SerializeField] [Range(0.05f,10)]
    private float speed;
    void FixedUpdate()
    {
        Vector3 move=new Vector3();
        if (Input.GetKey(KeyCode.A))
            move+= new Vector3(-speed,0,0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            move += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            move += new Vector3(0, 0, speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            move += new Vector3( 0, 0,-speed) * Time.deltaTime;
      
        PupilFisics.PushAll(this.transform,move);

    }

}
