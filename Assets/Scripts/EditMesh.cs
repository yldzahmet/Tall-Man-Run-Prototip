using UnityEngine;

public class EditMesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject spineRef;
    internal static float currentLength = 10f;
    internal static float currentHeight = 0.1f;
    // Start is called before the first frame update
    void Awake()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, currentLength);
        currentHeight = spineRef.transform.localPosition.y;

    }

    public void HeightUp(float up)
    {
        up /= 100.0f;
        spineRef.transform.localPosition = new Vector3(0, spineRef.transform.localPosition.y + up, 0);
        currentHeight = spineRef.transform.localPosition.y;
    }

    public bool HeightDown(float down)
    {
        down /= 100;
        // if current height lower than desired subjection
        if(-down >= spineRef.transform.localPosition.y)
        {
            // if spine height still would be reducible
            if (spineRef.transform.localPosition.y > 0.1f)
            {
                spineRef.transform.localPosition = new Vector3(0f, 0.1f, 0f);
                currentHeight = spineRef.transform.localPosition.y;
                return true;
            }
            else
                return false;
        }
        // reduce spine height
        else
        {
            spineRef.transform.localPosition = new Vector3(0, spineRef.transform.localPosition.y + down, 0);
            currentHeight = spineRef.transform.localPosition.y;
            return true;
        }
    }

    public void LengthUp(float up)
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, currentLength + up);
        currentLength = skinnedMeshRenderer.GetBlendShapeWeight(0);
    }

    public bool LengthDown(float down)
    {
        if (-down > skinnedMeshRenderer.GetBlendShapeWeight(0))
        {
            if (skinnedMeshRenderer.GetBlendShapeWeight(0) > 0)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
                return true;
            }
            else
                return false;
        }
        else
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, currentLength + down);
            currentLength = skinnedMeshRenderer.GetBlendShapeWeight(0);
            return true;
        }
    }
}
