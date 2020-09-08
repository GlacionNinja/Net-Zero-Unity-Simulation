using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour
{

    private float tile_unit;
    private Touch touch;
    private float TouchTime = 0;

    private GameObject ErrorTile;
    private GameObject MovingTile;
    private GameObject NormalTile;
    private GameObject SelectedTile;

    private bool moving = false;
    private bool overlap = false;
    private bool isMoving = false;

    private float height = 1;

    private Vector3 lastPosition;

    public static bool PANEL_ON = false;
    public bool Hover = false;

    public float timeCounter = 0;
    public bool counter = false;
    public bool counter2 = false;
    public bool counter3 = false;
    public float moved = 0;

    void Start()
    {
        NormalTile = GameObject.Find("House Normal");
        SelectedTile = GameObject.Find("House Selected");
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Clicked")
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = SelectedTile.GetComponent<SpriteRenderer>().sprite;
        }

        if (this.gameObject.tag == "Not Clicked")
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = NormalTile.GetComponent<SpriteRenderer>().sprite;
        }

        if (gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf == false || gameObject.transform.parent.transform.GetChild(1).gameObject.activeSelf == false)
        {
            Hover = false;
        }

        if (PANEL_ON == true && gameObject.transform.parent.transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf == true)
        {
            gameObject.transform.parent.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (PANEL_ON == false)
        {


            //Buttons appear when a building is selected

            if (this.gameObject.tag == "Clicked")
            {
                transform.parent.transform.GetChild(1).gameObject.SetActive(true);
            }

            else
            {

                transform.parent.transform.GetChild(1).gameObject.SetActive(false);
            }








            if (Input.touchCount >= 1 && Input.GetMouseButtonDown(0) == false && Outside.isMoving == false)
            {

                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (touch.phase == TouchPhase.Began)
                {
                    if (counter2 == true)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter2 = false;
                        counter3 = false;
                        moved = 0;
                    }
                    timeCounter += Time.deltaTime;
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    if (counter2 == true)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter2 = false;
                        counter3 = false;
                        moved = 0;
                    }
                    timeCounter += Time.deltaTime;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (counter2 == true)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter2 = false;
                        counter3 = false;
                        moved = 0;
                    }
                    moved++;
                    timeCounter += Time.deltaTime;
                }

                if (touch.phase == TouchPhase.Ended)
                {
               
                    counter = true;
                    counter2 = true;
                }


                //If a new building is tapped, set the previous selected building to not selected and the new building from not selected to selected

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == false && Outside.isMoving == false)
                {
                    counter3 = true;
                }

                if (counter3 == true && counter2 == true)
                {
                    if (timeCounter <= 0.1f && counter == true)
                    {
                        if (GameObject.FindGameObjectWithTag("Clicked") != null)
                        {
                            GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                        }
                        hit.collider.gameObject.tag = "Clicked";
                        moving = false;
                        timeCounter = 0;
                        counter = false;
                        counter3 = false;
                        moved = 0;
                    }

                    if (timeCounter > 0.1f && counter == true && moved <= 1)
                    {
                        if (GameObject.FindGameObjectWithTag("Clicked") != null)
                        {
                            GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                        }
                        hit.collider.gameObject.tag = "Clicked";
                        moving = false;
                        timeCounter = 0;
                        counter = false;
                        counter3 = false;
                        moved = 0;
                    }

                    if (timeCounter > 0.1f && counter == true && moved > 1)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter3 = false;
                        moved = 0;
                    }
                }



                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == true && Outside.isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    overlap = false;
                }



                //If empty space is tapped, either unselect a building if it was a tap, or still move the screen and zoom otherwise

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Not Clicked" &&
               hit.collider.gameObject.tag != "Clicked" && Outside.isMoving == false)
                {
                    if (overlap == false)
                    {
                        lastPosition = transform.position;
                        if (touch.phase == TouchPhase.Moved)
                        {
                            TouchTime += 0.01f;
                        }

                        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        {
                            moving = false;
                            if (TouchTime <= 0.01)
                            {
                                if (GameObject.FindGameObjectWithTag("Clicked") != null)
                                {
                                    GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                                }
                                TouchTime = 0;
                            }

                            else
                            {
                                TouchTime = 0;
                            }

                        }
                    }


                    if (overlap == true)
                    {
                        if (touch.phase == TouchPhase.Moved)
                        {
                            TouchTime += 0.01f;
                        }

                        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        {
                            moving = false;
                            if (TouchTime <= 0.01)
                            {
                                if (GameObject.FindGameObjectWithTag("Clicked") != null)
                                {
                                    GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                                }
                                TouchTime = 0;
                            }

                            else
                            {
                                TouchTime = 0;
                            }

                        }
                    }
                }
            }


            ////////////////////////////////////////////// Mouse Controls /////////////////////////////////////////////


            //When the finger is lifted, stop building movement and allow the camera to be moved again.

            //If empty space is tapped, either unselect a building if it was a tap, or still move the screen and zoom otherwise

            if (Input.GetMouseButtonUp(0) == true && Outside.isMoving == true)
            {
                Outside.isMoving = false;
                if (overlap == false)
                {
                    lastPosition = transform.position;
                }
                moving = false;
                MovingTheCamera.moveable = true;
            }


            if ((Input.touchCount <= 0 && Input.GetMouseButton(0) == true))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                //Unselect building if tapping away (but only for quick taps, not holding and dragging the mouse which would move the camera)
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Not Clicked" &&
               hit.collider.gameObject.tag != "Clicked" && Outside.isMoving == false && Hover == false && gameObject.tag == "Clicked")
                {
                    if (overlap == false)
                    {
                        lastPosition = transform.position;
                        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                        {
                            TouchTime += 0.01f;
                        }
                        moving = false;
                        if (TouchTime <= 0.01)
                        {
                            StartCoroutine(runTapCode());

                        }

                        else
                        {
                            TouchTime = 0;
                        }
                    }

                    if (overlap == true)
                    {
                        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                        {
                            TouchTime += 0.01f;
                        }
                        
                        moving = false;
                        if (TouchTime <= 0.01)
                        {
                            if (GameObject.FindGameObjectWithTag("Clicked") != null)
                            {
                                GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                            }
                            TouchTime = 0;
                        }

                        else
                        {
                            TouchTime = 0;
                        }


                    }


                }

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Not Clicked" &&
               hit.collider.gameObject.tag != "Clicked" && Outside.isMoving == false)
                {




                }

                //If a new building is tapped, set the previous selected building to not selected and the new building from not selected to selected

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == false && Outside.isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    lastPosition = transform.position;
                }

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == true && Outside.isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    overlap = false;
                }

            }
        }

    }


    private IEnumerator runTapCode()
    {
        yield return new WaitForSeconds(0.1f);

        if (GameObject.FindGameObjectWithTag("Clicked") != null)
        {
            GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
        }


        TouchTime = 0;
    }

    public void Hovering()
    {
        Hover = true;
    }

    public void NotHovering()
    {
        Hover = false;
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (gameObject.tag == "Clicked")
        {
            overlap = true;
        }


    }

    void OnTriggerStay(UnityEngine.Collider other)
    {
        if (gameObject.tag == "Clicked")
        {
            overlap = true;
        }
    }

    void OnTriggerExit(UnityEngine.Collider other)
    {
        if (gameObject.tag == "Clicked")
        {
            overlap = false;
        }
    }
}
