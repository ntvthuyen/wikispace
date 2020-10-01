using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TeleportEffect : MonoBehaviour
{
    public float effectDuration = 2;
    public ParticleSystem rings;
    List<Material> allMaterials;

    bool firstTime = true;

    List<Material> GetAllMaterials()
    {
        List<Material> results = new List<Material>();
        Renderer[] childrenRenderer = gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in childrenRenderer)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            foreach(Material material in renderer.materials)
            {
                results.Add(material);
            }
        }

        return results;
    }

    void OnEnable()
    {
        allMaterials = GetAllMaterials();
        foreach (Material material in allMaterials)
        {
            //ENABLE FADE Mode on the material if not done already
            material.SetFloat("_Mode", 2);
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;

            //Set alpha of material to 0 (invisible)
            Color currentColor = material.color;
            material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        }

        var main = rings.main;
        main.duration = effectDuration;

        TeleportIn();
    }

    public void TeleportIn()
    {
        rings.Play();
        StartCoroutine(FadeInAndOut(allMaterials, true, effectDuration));
    }

    public void TeleportOut()
    {
        rings.Play();
        StartCoroutine(FadeInAndOut(allMaterials, false, effectDuration));
    }

    IEnumerator FadeInAndOut(List<Material> materials, bool fadeIn, float duration)
    {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            foreach (Material material in materials)
            {
                Color currentColor = material.color;
                material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            yield return null;
        }
    }
}
