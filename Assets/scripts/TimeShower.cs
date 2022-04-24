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
            float realSeconds = (e as GeneralEventArgs<float>).Value;
            int seconds = (int)realSeconds;
            if (TryGetComponent<Text>(out Text textComponent))
            {
                textComponent.text = seconds == 0 ? "Lesson!!!" :
                    (seconds / 60).ToString() + ":" + (seconds % 60).ToString();
                textComponent.color = new Color(7f - realSeconds / 5f
                    , realSeconds / 5f - 3f, 0);
                float scale = realSeconds > 15f ? 1f :
                    1.5f + 0.5f * Mathf.Sin((realSeconds - 15f) /
                    (realSeconds + 1f) * Mathf.PI * 6.5f - Mathf.PI / 2f);
                transform.localScale = new Vector3(scale, scale, scale);
            }
            else
                throw new Exception("gameobject with srcipt 'TimeShower' " +
                "should have Componet 'Text'");
        }
    }
}
