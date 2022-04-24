using UnityEngine;
using UnityEngine.UI;
using System;

public class Pupil : MonoBehaviour
{
    [SerializeField] private Transform view;
    public void ChangeOpacity(float opacity, bool isForward)
    {
        SpriteRenderer spriteRenderer;
        if (view == null || !view.TryGetComponent(out spriteRenderer))
            throw new Exception("field 'view' should have object with " +
                "Component 'Sprite Renderer'");
        float opacitySpecial = opacity*opacity;
        spriteRenderer.color = isForward ? new Color(1, 1, 1, opacity) :
            new Color(opacitySpecial, opacitySpecial, opacitySpecial, opacity);
    }
}
