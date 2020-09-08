using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Outside_Movement : MonoBehaviour
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

  //  public static bool PANEL_ON = false;
    public bool Hover = false;

    public float timeCounter = 0;
    public bool counter = false;
    public bool counter2 = false;
    public bool counter3 = false;
    public float moved = 0;

    // Use this for initialization
    void Start()
    {
        RetrievePosition();
        lastPosition = this.transform.position;
        SavePosition();

        tile_unit = 1f / 0.33f;

        //Depending on building size, equip with appropriate tiles underneath for moving, error, normal and when selected

        if (transform.GetChild(0).tag == "Five")
        {
            ErrorTile = GameObject.FindGameObjectWithTag("ErrorTileFive");
            MovingTile = GameObject.FindGameObjectWithTag("MovingTileFive");
            NormalTile = GameObject.FindGameObjectWithTag("GrassTileFive");
            SelectedTile = GameObject.FindGameObjectWithTag("GrassTileFive");
            height = 1;
        }

        if (transform.GetChild(0).tag == "Four")
        {
            ErrorTile = GameObject.FindGameObjectWithTag("ErrorTileFour");
            MovingTile = GameObject.FindGameObjectWithTag("MovingTileFour");
            NormalTile = GameObject.FindGameObjectWithTag("GrassTileFour");
            SelectedTile = GameObject.FindGameObjectWithTag("GrassTileFour");
            height = 1;
        }

        if (transform.GetChild(0).tag == "Three")
        {
            ErrorTile = GameObject.FindGameObjectWithTag("ErrorTileThree");
            MovingTile = GameObject.FindGameObjectWithTag("MovingTileThree");
            NormalTile = GameObject.FindGameObjectWithTag("GrassTileThree");
            SelectedTile = GameObject.FindGameObjectWithTag("GrassTileThree");
            height = 1f;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf == false || gameObject.transform.parent.transform.GetChild(1).gameObject.activeSelf == false)
        {
            Hover = false;
        }

        if (Building_Movement.PANEL_ON == true && gameObject.transform.parent.transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf == true)
        {
            gameObject.transform.parent.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (Building_Movement.PANEL_ON == false)
        {
            //When a building is no longer selected, teleport to the last position

            if (this.gameObject.tag == "Not Clicked")
            {
                ResetPosition();
                lastPosition = transform.position;
            }

            //Buttons appear when a building is selected

            if (this.gameObject.tag == "Clicked")
            {
                transform.parent.transform.GetChild(1).gameObject.SetActive(true);
            }

            else
            {

                transform.parent.transform.GetChild(1).gameObject.SetActive(false);
            }

            //When overlapping, error tile should be put on

            if (this.gameObject.tag == "Clicked" && overlap == true)
            {
                //Set Visibility
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 150;
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 151;

                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ErrorTile.GetComponent<SpriteRenderer>().sprite;

                gameObject.transform.GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetComponent<BoxCollider>().size.x, height, gameObject.transform.GetComponent<BoxCollider>().size.z);
            }

            //When Selected and not moving, building should have the selected tile on

            if (this.gameObject.tag == "Clicked" && moving == false && overlap == false)
            {

                //Set Visibility
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 150;
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 151;

                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = SelectedTile.GetComponent<SpriteRenderer>().sprite;
                MovingTheCamera.moveable = true;
                lastPosition = transform.position;
                SavePosition();
                gameObject.transform.GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetComponent<BoxCollider>().size.x, height, gameObject.transform.GetComponent<BoxCollider>().size.z);
            }

            //When Selected and moving, building should have the moving tile on

            if (this.gameObject.tag == "Clicked" && moving == true && overlap == false)
            {
                //Set Visibility
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 150;
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 151;

                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = MovingTile.GetComponent<SpriteRenderer>().sprite;

                gameObject.transform.GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetComponent<BoxCollider>().size.x, height, gameObject.transform.GetComponent<BoxCollider>().size.z);
            }

            //When not selected, building should have the normal tile on

            if (this.gameObject.tag == "Not Clicked")
            {
                lastPosition = transform.position;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = NormalTile.GetComponent<SpriteRenderer>().sprite;

                //Set Visibility 
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(14 + transform.position.x) + Mathf.RoundToInt(14 + transform.position.z);
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 50 + Mathf.RoundToInt(14 + transform.position.x) + Mathf.RoundToInt(14 + transform.position.z);

                gameObject.transform.GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetComponent<BoxCollider>().size.x, 0.01f, gameObject.transform.GetComponent<BoxCollider>().size.z);
            }

            /*
            if (Input.touchCount >= 1 && Input.GetMouseButtonDown(0) == false)
            {

                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                Debug.Log(Input.touchCount);
                if (touch.phase == TouchPhase.Began)
                {
                    if (counter2 == true)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter2 = false;
                        counter3 = false;
                        Debug.Log("sd");
                        moved = 0;
                    }
                    timeCounter += Time.deltaTime;
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    Debug.Log("dfdfd");
                    if (counter2 == true)
                    {
                        timeCounter = 0;
                        counter = false;
                        counter2 = false;
                        counter3 = false;
                        Debug.Log("sd");
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
                        Debug.Log("sd");
                        moved = 0;
                    }
                    moved++;
                    timeCounter += Time.deltaTime;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("ya");
                    counter = true;
                    counter2 = true;
                }


                //If a new building is tapped, set the previous selected building to not selected and the new building from not selected to selected

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == false && isMoving == false)
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
                        lastPosition = transform.position;
                        SavePosition();
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
                        lastPosition = transform.position;
                        SavePosition();
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



                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == true && isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    overlap = false;
                    ResetPosition();
                }


                //If a selected building is tapped again, follow the finger for movement as long as the player doesn't lift their finger from the screen
                //and drags the building
                //Movement map constraints also added here, and disabled camera movement temporary while moving buildings.

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Clicked")
                {
                    isMoving = true;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved && isMoving == true)
                {
                    MovingTheCamera.moveable = false;
                    moving = true;
                    Ray ray3 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit3;

                    if (Physics.Raycast(ray3, out hit3))
                    {
                        GameObject moveable = GameObject.FindGameObjectWithTag("Clicked");

                        if (moveable.gameObject.transform.GetChild(0).tag == "Three")
                        {
                            if (hit3.point.z <= -11.9f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, -11.9f);

                            if (hit3.point.z >= 2.12f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, 2.12f);

                            if (hit3.point.x <= -11.9f)
                                hit3.point = new Vector3(-11.9f, hit3.point.y, hit3.point.z);

                            if (hit3.point.x >= 2.12f)
                                hit3.point = new Vector3(2.12f, hit3.point.y, hit3.point.z);

                            moveable.transform.position = new Vector3((Mathf.RoundToInt(hit3.point.x * tile_unit)) / tile_unit - 0.03f, transform.position.y,
                                Mathf.RoundToInt(hit3.point.z * tile_unit) / tile_unit - 0.11f);
                        }

                        if (moveable.gameObject.transform.GetChild(0).tag == "Four")
                        {
                            if (hit3.point.z <= -11.6f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, -11.6f);

                            if (hit3.point.z >= 2.12f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, 2.12f);

                            if (hit3.point.x <= -11.6f)
                                hit3.point = new Vector3(-11.6f, hit3.point.y, hit3.point.z);

                            if (hit3.point.x >= 2.12f)
                                hit3.point = new Vector3(2.12f, hit3.point.y, hit3.point.z);

                            moveable.transform.position = new Vector3((Mathf.RoundToInt(hit3.point.x * tile_unit)) / tile_unit - 0.18f, transform.position.y,
                                Mathf.RoundToInt(hit3.point.z * tile_unit) / tile_unit - 0.26f);
                        }

                        if (moveable.gameObject.transform.GetChild(0).tag == "Five")
                        {
                            if (hit3.point.z <= -11.6f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, -11.6f);

                            if (hit3.point.z >= 1.72f)
                                hit3.point = new Vector3(hit3.point.x, hit3.point.y, 1.72f);

                            if (hit3.point.x <= -11.6f)
                                hit3.point = new Vector3(-11.6f, hit3.point.y, hit3.point.z);

                            if (hit3.point.x >= 1.72f)
                                hit3.point = new Vector3(1.72f, hit3.point.y, hit3.point.z);

                            moveable.transform.position = new Vector3((Mathf.RoundToInt(hit3.point.x * tile_unit)) / tile_unit, transform.position.y,
                                Mathf.RoundToInt(hit3.point.z * tile_unit) / tile_unit);
                        }
                    }

                }
                //When the finger is lifted, stop building movement and allow the camera to be moved again.

                if (isMoving == true)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                    {

                        isMoving = false;
                        if (overlap == false)
                        {
                            lastPosition = transform.position;
                            SavePosition();
                        }
                        moving = false;
                        MovingTheCamera.moveable = true;
                    }
                }

                //If empty space is tapped, either unselect a building if it was a tap, or still move the screen and zoom otherwise

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Not Clicked" &&
               hit.collider.gameObject.tag != "Clicked" && isMoving == false)
                {
                    if (overlap == false)
                    {
                        lastPosition = transform.position;
                        SavePosition();
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
                                ResetPosition();
                                TouchTime = 0;
                            }

                            else
                            {
                                TouchTime = 0;
                            }

                        }
                    }
                }
            }*/


            ////////////////////////////////////////////// Mouse Controls /////////////////////////////////////////////


            //When the finger is lifted, stop building movement and allow the camera to be moved again.

            //If empty space is tapped, either unselect a building if it was a tap, or still move the screen and zoom otherwise

            if (Input.GetMouseButtonUp(0) == true && isMoving == true)
            {
                isMoving = false;
                if (overlap == false)
                {
                    lastPosition = transform.position;
                    SavePosition();
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
               hit.collider.gameObject.tag != "Clicked" && isMoving == false && Hover == false && gameObject.tag == "Clicked")
                {
                    if (overlap == false)
                    {
                        lastPosition = transform.position;
                        SavePosition();
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
                        Debug.Log("working");
                        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                        {
                            TouchTime += 0.01f;
                        }

                        Debug.Log("df");
                        moving = false;
                        if (TouchTime <= 0.01)
                        {
                            if (GameObject.FindGameObjectWithTag("Clicked") != null)
                            {
                                GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                            }
                            ResetPosition();
                            TouchTime = 0;
                        }

                        else
                        {
                            TouchTime = 0;
                        }


                    }


                }

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Not Clicked" &&
               hit.collider.gameObject.tag != "Clicked" && isMoving == false)
                {
                    Debug.Log("taps");



                }

                //If a new building is tapped, set the previous selected building to not selected and the new building from not selected to selected

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == false && isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    lastPosition = transform.position;
                    SavePosition();
                }

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Not Clicked" && overlap == true && isMoving == false)
                {
                    if (GameObject.FindGameObjectWithTag("Clicked") != null)
                    {
                        GameObject.FindGameObjectWithTag("Clicked").tag = "Not Clicked";
                    }
                    hit.collider.gameObject.tag = "Clicked";
                    moving = false;
                    overlap = false;
                    ResetPosition();
                }

                //If a selected building is tapped again, follow the finger for movement as long as the player doesn't lift their finger from the screen
                //and drags the building
                //Movement map constraints also added here, and disabled camera movement temporary while moving buildings.

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Clicked" && isMoving == false)
                {
                    isMoving = true;
                }
                if (isMoving == true)
                {
                    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                    {
                        MovingTheCamera.moveable = false;
                        moving = true;
                        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit2;

                        if (Physics.Raycast(ray2, out hit2))
                        {

                            GameObject moveable = GameObject.FindGameObjectWithTag("Clicked");

                            if (moveable.transform.GetChild(0).tag == "Three")
                            {
                                if (hit2.point.z <= -11.9f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, -11.9f);

                                if (hit2.point.z >= 2.12f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, 2.12f);

                                if (hit2.point.x <= -11.9f)
                                    hit2.point = new Vector3(-11.9f, hit2.point.y, hit2.point.z);

                                if (hit2.point.x >= 2.12f)
                                    hit2.point = new Vector3(2.12f, hit2.point.y, hit2.point.z);

                                moveable.transform.position = new Vector3((hit2.point.x * tile_unit) / tile_unit - 0.03f, transform.position.y,
                                    Mathf.RoundToInt(hit2.point.z * tile_unit) / tile_unit - 0.11f);
                            }

                            else if (moveable.gameObject.transform.GetChild(0).tag == "Four")
                            {
                                if (hit2.point.z <= -11.6f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, -11.6f);

                                if (hit2.point.z >= 2.12f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, 2.12f);

                                if (hit2.point.x <= -11.6f)
                                    hit2.point = new Vector3(-11.6f, hit2.point.y, hit2.point.z);

                                if (hit2.point.x >= 2.12f)
                                    hit2.point = new Vector3(2.12f, hit2.point.y, hit2.point.z);

                              //  moveable.transform.position = new Vector3(((hit2.point.x * tile_unit - hit2.point.x % tile_unit)) / tile_unit - 0.18f, transform.position.y,
                               //     Mathf.RoundToInt(hit2.point.z * tile_unit) / tile_unit - 0.26f);
                            }

                            else if (moveable.gameObject.transform.GetChild(0).tag == "Five")
                            {
                                if (hit2.point.z <= -11.6f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, -11.6f);

                                if (hit2.point.z >= 1.72f)
                                    hit2.point = new Vector3(hit2.point.x, hit2.point.y, 1.72f);

                                if (hit2.point.x <= -11.6f)
                                    hit2.point = new Vector3(-11.6f, hit2.point.y, hit2.point.z);

                                if (hit2.point.x >= 1.72f)
                                    hit2.point = new Vector3(1.72f, hit2.point.y, hit2.point.z);
                                moveable.transform.position = new Vector3((Mathf.RoundToInt(hit2.point.x * tile_unit)) / tile_unit, transform.position.y,
                                    Mathf.RoundToInt(hit2.point.z * tile_unit) / tile_unit);
                            }
                        }
                    }

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

    private void ResetPosition()
    {
        transform.position = lastPosition;
        overlap = false;
        moving = false;
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

    public void SavePosition()
    {
        if (transform.parent.gameObject.layer == 1)
        {
            if (transform.parent.transform.GetChild(1).gameObject.layer == 1)
            {
                PlayerPrefs.SetFloat("1.1.x", transform.position.x);
                PlayerPrefs.SetFloat("1.1.y", transform.position.y);
                PlayerPrefs.SetFloat("1.1.z", transform.position.z);
            }

            if (transform.parent.transform.GetChild(1).gameObject.layer == 2)
            {
                PlayerPrefs.SetFloat("1.2.x", transform.position.x);
                PlayerPrefs.SetFloat("1.2.y", transform.position.y);
                PlayerPrefs.SetFloat("1.2.z", transform.position.z);
            }

            if (transform.parent.transform.GetChild(1).gameObject.layer == 4)
            {
                PlayerPrefs.SetFloat("1.4.x", transform.position.x);
                PlayerPrefs.SetFloat("1.4.y", transform.position.y);
                PlayerPrefs.SetFloat("1.4.z", transform.position.z);
            }
        }
    }

    public void RetrievePosition()
    {
        if (transform.parent.gameObject.layer == 1)
        {
            if (transform.parent.transform.GetChild(1).gameObject.layer == 1)
            {
                transform.position = new Vector3(PlayerPrefs.GetFloat("1.1.x"), PlayerPrefs.GetFloat("1.1.y")
                    , PlayerPrefs.GetFloat("1.1.z"));
            }

            if (transform.parent.transform.GetChild(1).gameObject.layer == 2)
            {
                transform.position = new Vector3(PlayerPrefs.GetFloat("1.2.x"), PlayerPrefs.GetFloat("1.2.y")
                     , PlayerPrefs.GetFloat("1.2.z"));
            }

            if (transform.parent.transform.GetChild(1).gameObject.layer == 4)
            {
                transform.position = new Vector3(PlayerPrefs.GetFloat("1.4.x"), PlayerPrefs.GetFloat("1.4.y")
                   , PlayerPrefs.GetFloat("1.4.z"));
            }
        }
    }
}
