using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeShower : MonoBehaviour
{
    private void Start() => Timer.AddActionToTick(Show);

    private void Show(object nuller, EventArgs e)
    {
        if (this != null)
        {
            int seconds = (int)(e as GeneralEventArgs<float>).Value;
            if (TryGetComponent<Text>(out Text textComponent))
                textComponent.text = seconds == 0 ? "Lesson!!!" :
                    (seconds / 60).ToString() + ":" + (seconds % 60).ToString();
            else
                throw new Exception("gameobject with srcipt 'TimeShower' " +
                "should have Componet 'Text'");
        }
    }
}
