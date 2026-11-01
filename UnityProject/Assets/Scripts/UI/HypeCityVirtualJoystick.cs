using UnityEngine;
using UnityEngine.EventSystems;

public class HypeCityVirtualJoystick :
    MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [Header("Joystick")]
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float handleRange = 60f;

    [Header("Player")]
    [SerializeField] private HypeCityPlayerController player;

    private Vector2 input;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (background == null || handle == null)
            return;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
            return;

        Vector2 halfSize = background.rect.size * 0.5f;

        input = new Vector2(
            localPoint.x / halfSize.x,
            localPoint.y / halfSize.y
        );

        input = Vector2.ClampMagnitude(input, 1f);

        handle.anchoredPosition = input * handleRange;

        if (player != null)
            player.SetMoveInput(input);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;

        if (handle != null)
            handle.anchoredPosition = Vector2.zero;

        if (player != null)
            player.SetMoveInput(Vector2.zero);
    }
}
