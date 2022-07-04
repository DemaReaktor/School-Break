using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    [Range(0.05f, 10)]
    private float speed;
    [SerializeField]
    [Range(1f, 5f)]
    private float coefficientOfRun;
    [SerializeField]
    [Range(0.3f, 5f)]
    private float speedOfCameraRelativeToDistance;
    [SerializeField]
    [Range(0f, 1f)]
    private float coefficientOfCameraForward;
    const float distanceForCamera = 9f;

    private bool isRun;
    private float realSpeed;
    private float positionOfCamera;
    private float normalOfMove;
    private void Start()
    {
        positionOfCamera = 0f;
        isRun = false;
    }
    void FixedUpdate()
    {
        normalOfMove = 0f;

        //move of player
        Vector3 move = new Vector3();

        //run
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRun = !isRun;
        realSpeed = speed * (isRun ? coefficientOfRun : 1f);

        if (Input.GetKey(KeyCode.A))
        {
            move += new Vector3(-realSpeed, 0, 0) * Time.deltaTime;
            normalOfMove += -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += new Vector3(realSpeed, 0, 0) * Time.deltaTime;
            normalOfMove += 1f;
        }
        if (Input.GetKey(KeyCode.W))
            move += new Vector3(0, 0, realSpeed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            move += new Vector3(0, 0, -realSpeed) * Time.deltaTime;

        //player move and push all
        PupilFisics.Go(this.transform, move);

        //move of camera
        positionOfCamera = positionOfCamera + (normalOfMove - positionOfCamera) *
            Time.deltaTime * speedOfCameraRelativeToDistance;
        if (Mathf.Abs(positionOfCamera) < 0.1f * Time.deltaTime && normalOfMove == 0f)
            positionOfCamera = 0f;

        CameraMoveController.MoveCamera(positionOfCamera * distanceForCamera * coefficientOfCameraForward);
    }

}
