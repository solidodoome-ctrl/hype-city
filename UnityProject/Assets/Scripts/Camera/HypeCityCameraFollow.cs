using UnityEngine;

/// <summary>
/// Third-person follow camera for HYPE CITY.
/// </summary>
public class HypeCityCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset =
        new Vector3(0f, 3.2f, -5.5f);

    [SerializeField] private float followSharpness = 10f;
    [SerializeField] private float lookHeight = 1.5f;

    public Transform Target
    {
        get => target;
        set => target = value;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition =
            target.position + target.rotation * offset;

        float blend =
            1f - Mathf.Exp(-followSharpness * Time.deltaTime);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            blend
        );

        transform.LookAt(
            target.position + Vector3.up * lookHeight
        );
    }
}
