using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject pupil;
    [SerializeField] private GameObject pupilFolder;
    [SerializeField] private GameObject player;
    [ Range(0f,10f)][SerializeField] private float distance;
    public GameObject PupilFolder => pupilFolder; 
    public GameObject Player => player; 
    public float Distance => distance;
    private void Start()
    {
        Leveler.Start(this);
        for (int index = 0; index < Leveler.PupilCount; index++)
        {
            Vector3 position = new Vector3(Random.Range(1, Leveler.Lenth),0,
                    Random.Range(-Leveler.Width, Leveler.Width)+0.5f);

            for (int pupilIndex = 0; pupilIndex < index; pupilIndex++)
            {
                if (position.Equals(pupilFolder.transform.
                    GetChild(pupilIndex).transform.position))
                {
                    position = new Vector3(Random.Range(1, Leveler.Lenth),0,
                        Random.Range(- Leveler.Width, Leveler.Width)+0.5f);
                    pupilIndex = 0;
                }
            }
            Instantiate(pupil, position, new Quaternion(), pupilFolder.transform);
        }
        Timer.Start(Leveler.Time);
        PupilsOpacities.ChangeOpacitiesForAll(player.transform);
    }
}
