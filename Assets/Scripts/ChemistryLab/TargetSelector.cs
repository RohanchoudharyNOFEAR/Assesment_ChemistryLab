using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    private Camera camera;

    public Transform TestTubeRestPos;
    public Transform ConicalFlaskARestPos;
    public Transform ConicalFlaskBRestPos;
    private Vector3 clickOffset = Vector3.zero;
    private bool offsetCaluated = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {


                if (hitinfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    offsetCaluated = false;
                    clickOffset = Vector3.zero;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {


                if (hitinfo.collider.gameObject.GetComponent<Target>() != null)
                {

                    var TargetInstance = hitinfo.collider.gameObject;
                    if (!offsetCaluated)
                    {
                        clickOffset = hitinfo.point - TargetInstance.transform.position;
                        offsetCaluated = true;
                    }

                    Debug.Log(TargetInstance.name);
                    TargetInstance.transform.position = new Vector3(TargetInstance.transform.position.x, hitinfo.point.y - clickOffset.y, hitinfo.point.z - clickOffset.z)/* hitinfo.point*/;
                }
            }
        }
    }

  
}
