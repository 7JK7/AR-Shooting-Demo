using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AndroidManager : MonoBehaviour
{

    public enum ARState
    {
        Plane,
        Play
    }

    public LayerMask Trackinglayer;
    public LayerMask Playlayer;

    private int _count;

    public ARPlaneManager aRPlaneManager;

    public ARRaycastManager arRay;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Camera xrCam;

    public GameObject Level;

    public PlayerFire playerFire;
    public EnemtSpawner enemtSpawner;
    public GameObject Crosshair;
    

    Vector2 ScreenCenter;

    ARState ars = ARState.Plane;

    private void Start()
    {
        //중요 - 오브젝트 이름을 무조건 AndroidPlugin로 해주세요.
        gameObject.name = "AndroidPlugin";

        ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        xrCam.cullingMask = Trackinglayer;

    }

    private void Update()
    {
        if (ars == ARState.Plane)
        {
            if (arRay.Raycast(ScreenCenter, hits, TrackableType.PlaneWithinPolygon))
            {
                //Vector2 center = hits[0].pose.position;

                Level.transform.position = hits[0].pose.position;
            }
        }

    }

    void ResetARPlane()
    {
        aRPlaneManager.enabled = false;
        
        foreach (var item in aRPlaneManager.trackables)
        {
            Destroy(item.gameObject);
        }
    }

    //볼륨 이벤트를 받아 옵니다.
    public void VolumeEvent(string arg)
    {
        switch (arg)
        {
            case "Up":
                _count += 1;
                //원하는 내용을 넣으십시오.
                if(ars == ARState.Plane)
                {
                    ars = ARState.Play;
                    xrCam.cullingMask = Playlayer;
                    Crosshair.SetActive(true);
                    ResetARPlane();
                    Level.GetComponent<AudioSource>().Play();
                }
                if(ars == ARState.Play)
                {
                    if(enemtSpawner.enabled == false)
                    {
                        enemtSpawner.enabled = true;
                    }
                    playerFire.OnFire();
                }
                Debug.Log("Volume UP111");
                
                break;
            case "Down":
                _count -= 1;
                //원하는 내용을 넣으십시오.
                Debug.Log("Volume DOWN");
                break;
        }
    }
}