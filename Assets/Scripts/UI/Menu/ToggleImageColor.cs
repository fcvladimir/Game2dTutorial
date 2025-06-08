using UnityEngine;
using UnityEngine.UI;

public class ToggleImageColor : MonoBehaviour
{
    public Material grayscaleMaterial;
    private Material originalMaterial;
    private Image img;

    private bool isGrayscale = true;

    void Start()
    {
        img = GetComponent<Image>();
        originalMaterial = img.material;
        img.material = grayscaleMaterial;
    }

    public void OnClick()
    {
        if (isGrayscale)
        {
            img.material = originalMaterial;
        }
        else
        {
            img.material = grayscaleMaterial;
        }

        isGrayscale = !isGrayscale;
    }
}
