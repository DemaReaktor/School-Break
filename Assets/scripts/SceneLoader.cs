using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject pupil;
    [SerializeField] private GameObject pupilFolder;
    private void Start()
    {
        Leveler.Start();
        for (int index = 0; index < Leveler.PupilCount; index++)
        {
            Vector3 position = new Vector3(Random.Range(0, Leveler.Lenth),0,
                    Random.Range(0, Leveler.Width));

            for (int pupilIndex = 0; pupilIndex < index; pupilIndex++)
            {
                if (position.Equals(pupilFolder.transform.
                    GetChild(pupilIndex).transform.position))
                {
                    position = new Vector3(Random.Range(0, Leveler.Lenth),0,
                        Random.Range(0, Leveler.Width));
                    pupilIndex = 0;
                }
            }
            Instantiate(pupil, position, new Quaternion(), pupilFolder.transform);
        }
    }
}
