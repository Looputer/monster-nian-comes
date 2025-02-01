using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(-1.54f, 0.43f, -2.51f);
    private Transform _cameraTarget;
    void Start()
    {
        _cameraTarget = GameObject.Find("Player").transform;    
    }
    void LateUpdate()
    {
        transform.position = _cameraTarget.TransformPoint(cameraOffset);
        transform.LookAt(_cameraTarget);
    }
}
