using UnityEngine;

public class PupilFisics : MonoBehaviour
{
    private const float distance = 0.95f;
    private const float pushCoefficient = 0.02f;
    public static void Go(Transform walker, Vector3 power)
    {
        float speed = power.magnitude;

        if (power.magnitude < 0.01f)  //ignore little power
            return;

        power *= 0.8f;// friction force

        int index;
        do
        {
            //check all pupils
            for (index = 0; index < Leveler.SceneLoader.
         PupilFolder.transform.childCount; index++)
            {

                if (Vector3.Distance(power + walker.position,
                    Leveler.SceneLoader.PupilFolder.transform.GetChild(index).
                    position) < distance && walker !=
                    Leveler.SceneLoader.PupilFolder.transform.GetChild(index))
                {
                    float kut, x, t;
                    Vector3 powerForPupil;

                    kut = Vector3.Angle(power,
                    Leveler.SceneLoader.PupilFolder.transform.
                        GetChild(index).position - walker.position)
                        * Mathf.PI / 180f;
                    x = Vector3.Distance(Leveler.SceneLoader.PupilFolder.transform.
                        GetChild(index).position, walker.transform.position);
                    t = x * Mathf.Cos(kut) - Mathf.Sqrt(distance *
                        distance - x * x * Mathf.Sin(kut) * Mathf.Sin(kut));
                    //d = x * Mathf.Sin(kut * Mathf.PI / 180f);
                    //y = Mathf.Sqrt(0.95f * 0.95f - d * d);
                    //p = x * Mathf.Cos(kut * Mathf.PI / 180f);
                    //t = p - y;

                    if (t > 0.015f)// move until touch pupil
                        Go(walker, power.normalized * t);

                    x = Vector3.Distance(Leveler.SceneLoader.PupilFolder.transform.
                        GetChild(index).position, walker.transform.position);
                    //check is pusher in pupil
                    if (x < 1)
                    {
                        Vector3 pushPower = (walker.position -
                            Leveler.SceneLoader.PupilFolder.transform.
                            GetChild(index).position).normalized
                            * pushCoefficient * speed / x;
                        power += pushPower;
                        Go(Leveler.SceneLoader.PupilFolder.transform.
                            GetChild(index), -pushPower);
                    }

                    power -= power.normalized * t;
                    powerForPupil = power * 0.8f;

                    kut = Vector3.Angle(power,
                    Leveler.SceneLoader.PupilFolder.transform.
                    GetChild(index).position - walker.position);

                    //power change normal across pupil
                    power = Quaternion.AngleAxis(Mathf.PI / 2 - kut, Vector3.up)
                        * power * Mathf.Tan(kut * Mathf.PI / 180f) /
                        (Mathf.Tan(kut * Mathf.PI / 180f) + 1);

                    //move pupil
                    Go(Leveler.SceneLoader.PupilFolder.transform.
                GetChild(index), Quaternion.AngleAxis(kut, Vector3.up)
                * powerForPupil / (Mathf.Tan(kut * Mathf.PI / 180f) + 1));

                    index = 0;
                }
            }
            index = -1;
            Vector3 newPos;
            newPos = power + walker.position;

            //check walls
            if (newPos.x < -0.5f)
            {
                float x, kut;

                kut = Vector3.Angle(-Vector3.right, power);
                x = -0.5f - newPos.x;
                Go(walker, power * (power.magnitude - x / Mathf.Cos
                    (kut * Mathf.PI / 180)));

                //pusher.position += power * (power.magnitude-x/Mathf.Cos
                //(kut*Mathf.PI/180));

                power = new Vector3(0, 0, (power.z > 0 ? 1 : -1) * x *
                    Mathf.Tan(kut * Mathf.PI / 180));

                index = 0;
            }
            if (newPos.x + 0.5f > Leveler.Lenth)
            {
                float x, kut;

                kut = Vector3.Angle(Vector3.right, power);
                x = newPos.x + 0.5f - Leveler.Lenth;
                Go(walker, power * (power.magnitude - x / Mathf.Cos
                    (kut * Mathf.PI / 180)));

                //pusher.position += power * (power.magnitude - x / Mathf.Cos
                //(kut * Mathf.PI / 180));

                power = new Vector3(0, 0, (power.z > 0 ? 1 : -1) * x *
                    Mathf.Tan(kut * Mathf.PI / 180));

                index = 0;
            }
            if (newPos.z + 0.5f > Leveler.Width)
            {
                float z, kut;

                kut = Vector3.Angle(Vector3.forward, power);
                z = newPos.z + 0.5f - Leveler.Width;
                Go(walker, power * (power.magnitude - z / Mathf.Cos
                    (kut * Mathf.PI / 180)));

                //pusher.position += power * (power.magnitude-x/Mathf.Cos
                //(kut*Mathf.PI/180));

                power = new Vector3((power.x > 0 ? 1 : -1) * z *
                    Mathf.Tan(kut * Mathf.PI / 180), 0, 0);

                index = 0;
            }
            if (newPos.z < 0.5f - Leveler.Width)
            {
                float z, kut;

                kut = Vector3.Angle(-Vector3.forward, power);
                z = 0.5f - Leveler.Width - newPos.z;
                Go(walker, power * (power.magnitude - z / Mathf.Cos
                    (kut * Mathf.PI / 180)));

                //pusher.position += power * (power.magnitude-x/Mathf.Cos
                //(kut*Mathf.PI/180));

                power = new Vector3((power.x > 0 ? 1 : -1) * z *
                    Mathf.Tan(kut * Mathf.PI / 180), 0, 0);

                index = 0;
            }
        } while (index == 0 && power.magnitude > 0.01f);
        walker.transform.position += power;
        if (walker.TryGetComponent<playerController>(out playerController nuller))
            PupilsOpacities.ChangeOpacities(walker);
    }
}
