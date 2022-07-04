using UnityEngine;
using UnityEngine.UI;
using System;

public class Pupil : MonoBehaviour
{
    [SerializeField] private SpriteRenderer view;
    public void ChangeOpacity(float opacity, bool isForward)
    {
        if (view == null)
            throw new Exception("field 'view' should have object with " +
                "Component 'Sprite Renderer'");
        float opacitySpecial = opacity*opacity;
        view.color = isForward ? new Color(1, 1, 1, opacity) :
            new Color(opacitySpecial, opacitySpecial, opacitySpecial, opacity);
    }
}
