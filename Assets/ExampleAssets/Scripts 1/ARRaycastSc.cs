using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycastSc : MonoBehaviour
{
    public GameObject player;
    public GameObject playerP;
    private GameObject spawnedObject;
    //public CubeDetection cB;
    public GameObject planed;
    private ARRaycastManager arRaycast;
    private ARPlaneManager arPlaneDetect;
    private Vector2 touchposition;
    private Vector3 direct;
    private RaycastHit hit;
    public static bool isAbletoInstal;
    public static bool isENable;
    static List<ARRaycastHit> hitvalue = new List<ARRaycastHit>();
    public List<Material> mcolor = new List<Material>();
    public int tCount;
    private Vector3 crrt;
    private Vector3 final;
    public AudioSource audioClipp;
    public Text gameOver;

    //private int i = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        audioClipp = GetComponent<AudioSource>();
        isAbletoInstal = false;
        
    }
    void Start()
    {
        arRaycast = GetComponent<ARRaycastManager>();
        arPlaneDetect = GetComponent<ARPlaneManager>();
        
        isENable = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Input.touchCount != 1)
        //{
        //    EnableInstant();
        //}
        //playerP = GameObject.FindGameObjectWithTag("player");
        ARPlane arPlane = FindObjectOfType<ARPlane>();
        if (arPlane)
        {
            arPlaneDetect.enabled = false;
        }
        //if (i > 1)
        //{
        //    arPlane.gameObject.SetActive(false);
        //}
        //if (GameObject.FindGameObjectsWithTag("planex")!=null)
        //{
        //    arPlaneDetect.gameObject.SetActive(false);
        //}

        //tCount = Input.GetTouch(0).tapCount;


        //if(touch.phase== TouchPhase.Began)
        //{
        //    crrt = touch.position;
        //}
        //if (touch.phase == TouchPhase.Ended)
        //{
        //    final = touch.position;
        //}
        //if (crrt == final && player==null)
        //{
        //    EnableInstant();
        //}
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).tapCount > 0)
            {
                Touch touch = Input.touches[0];
                touchposition = Input.GetTouch(0).position;
                Ray r = Camera.main.ScreenPointToRay(touchposition);
                if (Physics.Raycast(r, out hit, 50, ~1 << 6))
                {
                    string m = hit.collider.tag;
                    if (m == "red" && isAbletoInstal)
                    {
                        Debug.Log("kkkkk");
                    }
                    //if (m == "red")
                    //{
                    //    Destroy(player);
                    //    Destroy(playerP);
                    //}
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (player == null /*&& isAbletoInsta*/)
                        {
                            player = CreatObjects();

                            isENable = false;
                            //player = Instantiate(playerP, new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z), hit.transform.rotation);
                            //isAbletoInsta = true;

                        }
                    }
                    player.transform.position = new Vector3(hit.point.x, hit.point.y + 0.17f, hit.point.z);

                    if (touch.phase == TouchPhase.Ended)
                    {
                        Debug.Log("gg");
                        isAbletoInstal = true;
                        player = null;
                        //Destroy(FindObjectOfType<CubeDetection>().gameObject);
                        //isAbletoInstal=false;


                    }
                }


                //Vector3 t3 = new Vector3(touchposition.x, touchposition.y, 0);
                //direct = (t3 - player.transform.position).normalized;
            }
        }
        
        
        if (arRaycast.Raycast(touchposition, hitvalue, TrackableType.PlaneWithinPolygon))
        {
            var hit = hitvalue[0].pose;
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(planed, hit.position, hit.rotation);
            }
            //else
            //{
            //    player.transform.position = hit.position;
            //}
           // Debug.DrawRay(touchposition,direct*40,Color.red);
        }

            
        
    }
    public GameObject CreatObjects()
    {
        if (mcolor.Count == 0)
        {
            gameOver.gameObject.SetActive(true);
        }
        int i = Random.Range(0, mcolor.Count);
        playerP.GetComponent<MeshRenderer>().material = mcolor[i];
        GameObject playerM = Instantiate(playerP, new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z), hit.transform.rotation);
        
        //mcolor.RemoveAt(i);
        return playerM;
    }
   

}
