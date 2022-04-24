using UnityEngine;
using System;

public static class PupilsOpacities
{
    public static void ChangeOpacitiesForAll(Transform player)
    {
        for (int index = 0; index < Leveler.SceneLoader.PupilFolder.
            transform.childCount; index++)
                Leveler.SceneLoader.PupilFolder.
             transform.GetChild(index).GetComponent<Pupil>().ChangeOpacity(
                    1f - Mathf.Abs(player.position.z - Leveler.SceneLoader.
                    PupilFolder.transform.GetChild(index).position.z) /
                    Leveler.SceneLoader.Distance,
                    player.position.z - Leveler.SceneLoader.PupilFolder.
            transform.GetChild(index).position.z > 0f);
    }
    public static void ChangeOpacities(Transform player)
    {
        for (int index=0;index< Leveler.SceneLoader.PupilFolder.
            transform.childCount;index++)
        if(Mathf.Abs(player.position.z-Leveler.SceneLoader.PupilFolder.
            transform.GetChild(index).position.z)<Leveler.SceneLoader.Distance&&
            Mathf.Abs(player.position.x - Leveler.SceneLoader.PupilFolder.
            transform.GetChild(index).position.x)<18f){
                Leveler.SceneLoader.PupilFolder.
             transform.GetChild(index).GetComponent<Pupil>().ChangeOpacity(
                    1f-Mathf.Abs(player.position.z - Leveler.SceneLoader.
                    PupilFolder.transform.GetChild(index).position.z)/
                    Leveler.SceneLoader.Distance, 
                    player.position.z - Leveler.SceneLoader.PupilFolder.
            transform.GetChild(index).position.z>0f);
        }
    }
}
