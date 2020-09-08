using UnityEngine;
using System.Collections;

public class MovingTheCamera : MonoBehaviour
{
    public int counter;
    public float moveSensitivityX = 1.0f;
    public float moveSensitivityY = 1.0f;
    public float minZoom = 1.5f;
    public float maxZoom = 9.1f;
    public bool updateZoomSensitivity = true;
    public float orthoZoomSpeed = 0.05f;
    public bool invertMoveX = false;
    public bool invertMoveY = false;
    public bool TouchConfliction = false;
    private Camera _camera;
    public float mapWidth = 40.0f;
    public float mapHeight = 40.0f;
    public static bool moveable = true;

    private bool right = false;
    private bool left = false;
    private bool up = false;
    private bool down = false;

    private Vector2 lastPosition;


    //private float horizontalExtent, verticalExtent;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Building_Movement.PANEL_ON == false)
        {
            _camera.transform.GetComponent<Transform>().localScale = new Vector3(_camera.orthographicSize / 7.2f * 25f, _camera.orthographicSize / 7.2f * 14f, 1);

            if (moveable == true)
            {

                if (updateZoomSensitivity)
                {
                    moveSensitivityX = _camera.orthographicSize / 3.0f;
                    moveSensitivityY = _camera.orthographicSize / 3.0f;
                }

                Touch[] touches = Input.touches;

                if (Input.touchCount > 0 && touches.Length > 0 && Input.GetMouseButtonDown(0) == false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Selected")
                    {
                        TouchConfliction = true;
                    }

                    if (Physics.Raycast(ray, out hit) && TouchConfliction == true)
                    {
                        if (touches.Length == 1)
                        {
                            if (touches[0].phase == TouchPhase.Moved)
                            {
                                Vector2 delta = touches[0].deltaPosition;
                                float positionX = delta.x * moveSensitivityX * Time.deltaTime;
                                positionX = invertMoveX ? positionX : positionX * -1;

                                float positionY = delta.y * moveSensitivityY * Time.deltaTime;
                                positionY = invertMoveY ? positionY : positionY * -1;

                                transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1000f * positionX, 1000f * positionY, 0));
                                /*  if (right == true)
                                  {
                                     if (positionX > 0)
                                      positionX = 0;
                                  }
                                  if (left == true)
                                  {
                                      if (positionX < 0)
                                          positionX = 0;
                                  }
                                  if (up == true)
                                  {
                                      if (positionY > 0)
                                          positionY = 0;
                                  }
                                  if (down == true)
                                  {
                                      if (positionY < 0)
                                          positionY = 0;
                                  }
                                  _camera.transform.Translate(new Vector3(positionX, positionY, 0));  */
                            }
                        }

                        if (touches.Length == 2)
                        {
                            Vector2 cameraViewSize = new Vector2(_camera.pixelWidth, _camera.pixelHeight);
                            Touch touchOne = touches[0];
                            Touch touchTwo = touches[1];

                            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
                            Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

                            float prevTouchDeltaMag = (touchOnePrevPos - touchTwoPrevPos).magnitude;
                            float touchDeltaMag = (touchOne.position - touchTwo.position).magnitude;

                            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

                            _camera.transform.position += _camera.transform.TransformDirection((touchOnePrevPos + touchTwoPrevPos - cameraViewSize) * _camera.orthographicSize / cameraViewSize.y);
                            _camera.orthographicSize += deltaMagDiff * orthoZoomSpeed;
                            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, minZoom, maxZoom);
                            _camera.transform.position -= _camera.transform.TransformDirection((touchOnePrevPos + touchTwoPrevPos - cameraViewSize) * _camera.orthographicSize / cameraViewSize.y);
                        }


                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                            TouchConfliction = false;
                    }
                }
            }

            /////////////////////////////////////////////////////// MOUSE CONTROLS //////////////////////////////////////////////////////////////

            if (moveable == true)
            {

                if (Input.GetMouseButton(0) == false)
                {
                    TouchConfliction = false;
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    _camera.orthographicSize += 0.1f;
                }

                if (Input.GetKey(KeyCode.W))
                {
                    _camera.orthographicSize -= 0.1f;
                }

                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, minZoom, maxZoom);

                if (Input.touchCount <= 0 && Input.GetMouseButton(0) == true)
                {



                    if (updateZoomSensitivity)
                    {
                        moveSensitivityX = _camera.orthographicSize / 3.0f;
                        moveSensitivityY = _camera.orthographicSize / 3.0f;
                    }


                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Selected" && TouchConfliction == false)
                    {
                        TouchConfliction = true;
                        lastPosition = Input.mousePosition;

                    }


                    if (Physics.Raycast(ray, out hit) && TouchConfliction == true)
                    {
                        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                        {
                            Vector2 delta = new Vector2(Input.mousePosition.x - lastPosition.x, Input.mousePosition.y - lastPosition.y);
                            lastPosition = Input.mousePosition;
                            lastPosition = Input.mousePosition;
                            float positionX = delta.x * moveSensitivityX * Time.deltaTime;
                            positionX = invertMoveX ? positionX : positionX * -1;

                            float positionY = delta.y * moveSensitivityY * Time.deltaTime;
                            positionY = invertMoveY ? positionY : positionY * -1;

                            transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1000f * positionX, 1000f * positionY, 0));

                        }
                    }
                }
            }
        }
    }
    

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("d");
        if (col.transform.tag == "Camera right")
        {
            right = true;
        }

        if (col.transform.tag == "Camera left")
        {
            left = true;
        }

        if (col.transform.tag == "Camera up")
        {
            up = true;
        }

        if (col.transform.tag == "Camera down")
        {
            down = true;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Camera right")
        {
            right = true;
        }

        if (col.transform.tag == "Camera left")
        {
            left = true;
        }

        if (col.transform.tag == "Camera up")
        {
            up = true;
        }

        if (col.transform.tag == "Camera down")
        {
            down = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Camera right")
        {
            right = false;
        }

        if (col.transform.tag == "Camera left")
        {
            left = false;
        }

        if (col.transform.tag == "Camera up")
        {
            up = false;
        }

        if (col.transform.tag == "Camera down")
        {
            down = false;
        }
    }

}