using UnityEngine;

public class HypeCityHairCustomizer : MonoBehaviour
{
    [Header("Hair Styles")]
    [SerializeField] private GameObject[] hairStyles;

    [Header("Hair Colors")]
    [SerializeField] private Renderer[] hairRenderers;

    private readonly Color[] hairColors =
    {
        new Color(0.12f, 0.07f, 0.04f), // Black-brown
        new Color(0.30f, 0.16f, 0.08f), // Brown
        new Color(0.85f, 0.68f, 0.35f), // Blonde
        new Color(0.45f, 0.12f, 0.07f), // Auburn
        new Color(0.04f, 0.08f, 0.18f)  // Blue-black
    };

    private MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();

        SelectHairStyle(0);
        SelectHairColor(0);
    }

    public void SelectHairStyle(int index)
    {
        if (hairStyles == null || hairStyles.Length == 0)
            return;

        if (index < 0 || index >= hairStyles.Length)
            return;

        for (int i = 0; i < hairStyles.Length; i++)
        {
            if (hairStyles[i] != null)
                hairStyles[i].SetActive(i == index);
        }
    }

    public void SelectHairColor(int index)
    {
        if (index < 0 || index >= hairColors.Length)
            return;

        foreach (Renderer hair in hairRenderers)
        {
            if (hair == null)
                continue;

            hair.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_BaseColor", hairColors[index]);
            propertyBlock.SetColor("_Color", hairColors[index]);
            hair.SetPropertyBlock(propertyBlock);
        }
    }
}
