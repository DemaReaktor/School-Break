using System.Collections;
using System.Collections.Generic;
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
    }
}
