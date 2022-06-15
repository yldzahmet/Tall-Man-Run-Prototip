using UnityEngine;

public class CameraFolower : MonoBehaviour
{
    public GameObject target;
    public GameObject spine;
    internal Vector3 relativeSpinePos;
    internal Vector3 offsetSpine2Cam;
    public float offsetMultipler = 1;
    public float speed = 1.0f;

    private void Start()
    {
        offsetSpine2Cam = spine.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offsetMultipler = 1;
        relativeSpinePos = new Vector3(0, spine.transform.position.y, spine.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, relativeSpinePos - offsetSpine2Cam * offsetMultipler, 2 * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.FromToRotation(Vector3.forward, offsetSpine2Cam), 5 * Time.deltaTime);
    }
}

