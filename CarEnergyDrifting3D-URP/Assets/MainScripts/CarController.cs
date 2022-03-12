using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] Transform wheelObjectL, wheelObjectR, TiresM;
    [SerializeField] GameObject SkidMarks, ExhaustFlame, ExhaustFlameEx, boostTakenParticle, Boosts, speedIncreaseEffect;
    private float XPos, normalSpeed;
    public float Speed, driftAngle, recoverSpeed, movingSpeed;
    private bool isDraging;
    private Vector2 startTouch, swipeDelta;
    private Vector3 CarSizes, boostTakenRot, boostTakenPos;

    public static bool carStopped, carStopping, circleLvlEnd;
    public static float MainCarWeight, MainSpeed;
    float spin, turn, skidMarkControl;

    private void Start()
    {
        MainCarWeight = MainSpeed = skidMarkControl = spin = turn = 0;
        isDraging = circleLvlEnd = false;
        normalSpeed = movingSpeed;
        CarSizes = transform.localScale;
        SkidMarks.transform.localPosition = new Vector3(0, -5f, 0);
        boostTakenRot = new Vector3(0, 0, 0);
     //   Debug.Log("Rot y: " + transform.eulerAngles.y);

    }

    void FixedUpdate()
    {
        #region InGameController

        if (LevelEndController.lvlEndEnter == false && LevelEndController.clickCounter < 6)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }

            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    Reset();
                }
            }

            if (swipeDelta.magnitude > 126)
            {
                float x = swipeDelta.x;

                if (x < 0)
                {
                    //   Debug.Log("Left X= " + swipeDelta.x.ToString() + " || XPos= " + transform.position.x);
                    XPos = -1;
                    if (transform.position.x >= -3f) { LocalMoveL(XPos); }

                    if (transform.position.x <= -3f) { CarRotateHome(); }

                }
                else
                {
                    //  Debug.Log("Right X= " + swipeDelta.x.ToString() + " || XPos= " + transform.position.x);
                    XPos = 1;
                    if (transform.position.x <= 3f) { LocalMoveR(XPos); }

                    if (transform.position.x >= 3f) { CarRotateHome(); }

                }
            }
            else { XPos = 0; }

            if (MainSpeed >= 2)
            {

                if (spin != 35)
                {
                    // Debug.Log("360 Spin Turn!!");
                    SkidMarks.transform.localPosition = new Vector3(0.48f, 0, -1.36f);
                    transform.Rotate(Vector3.up * 500 * Time.deltaTime);
                    spin++;
                }

            }

            if (Glass.controlGlassSolid == 0) { transform.localPosition += new Vector3(0, 0, 1) * movingSpeed * Time.deltaTime; } //Car move
            else { Debug.Log("GameOver!!"); }

            if (skidMarkControl == 1)
            {
                if (SkidMarks.transform.localPosition == new Vector3(0.48f, 0, -1.36f)) { }
                else { SkidMarks.transform.localPosition = new Vector3(0.48f, 0, -1.36f); }
            }


            if (isDraging)
            {
                if (Input.touches.Length > 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
                else if (Input.GetMouseButton(0))
                {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }

            }
            else if (isDraging == false)
            {
                if (transform.eulerAngles.y != 180)
                {
                    //  Debug.Log("ReturningRotation! Rot: " + transform.eulerAngles.y);

                    //if (transform.position.x <= 0.24)
                    if (transform.eulerAngles.y < 180)
                    {
                        // Debug.Log("ReturningL Rotation: " + transform.eulerAngles.y);
                        transform.Rotate(Vector3.down * recoverSpeed * Time.deltaTime);

                    }
                    // else if (transform.position.x >= 0.26)
                    if (transform.eulerAngles.y > 180)
                    {
                        // Debug.Log("ReturningR Rotation: " + transform.eulerAngles.y);
                        transform.Rotate(Vector3.up * recoverSpeed * Time.deltaTime);

                    }

                    wheelObjectL.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                    wheelObjectR.transform.localRotation = Quaternion.Euler(0, 180, 0);

                    wheelObjectL.localPosition = new Vector3(0.05f, 0, 0f);
                    wheelObjectR.localPosition = new Vector3(1.43f, 0, -3.732f);

                    if (skidMarkControl == 1) { StartCoroutine(SkidMarkDelay()); }

                }
                else
                {
                    //    Debug.Log("NormalRotation Rot: " + transform.eulerAngles.y);
                }
            }
        }
        #endregion

        if (LevelEndController.lvlEndEnter && LevelEndController.endDriftCntrl == false && LevelEndController.clickCounter != 6)
        {
            if (movingSpeed > 0)
            {
                isDraging = false;
                carStopping = true;
                transform.localPosition += new Vector3(0, 0, 1) * movingSpeed * Time.deltaTime;

                transform.localScale = CarSizes;
                Vector3 desiredPosition = new Vector3(-0.25f, transform.position.y, transform.position.z);
                Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
                transform.position = SmoothedPosition;

                movingSpeed -= 4.7f * Time.deltaTime;
            }
            else if (movingSpeed <= 0)
            {
                carStopped = true;
                carStopping = false;
            }
        }

        if (LevelEndController.lvlEndEnter && LevelEndController.clickCounter >= 6)
        {
            if (circleLvlEnd)
            {
                wheelObjectL.transform.localRotation = Quaternion.Euler(0, -60f, 0);
                wheelObjectR.transform.localRotation = Quaternion.Euler(0, 120f, 0);

                wheelObjectL.localPosition = new Vector3(-0.47f, 0, -2.9f);
                wheelObjectR.localPosition = new Vector3(2f, 0, -1f);

                if (transform.rotation.eulerAngles.y < 21) { transform.Rotate(Vector3.up * driftAngle * Time.deltaTime); }
               

                /* if (turn != 30)
                 {
                     transform.Rotate(Vector3.down * 60 * Time.deltaTime);
                     turn++;
                 }
                 else if (turn >= 30)
                 {
                     transform.Rotate(Vector3.up * driftAngle * Time.deltaTime);
                 }
                */

              //  transform.localPosition += new Vector3(0, 0, 1) * movingSpeed * Time.deltaTime;

            }
            else if (circleLvlEnd != true)
            {
                if (movingSpeed < 6) { movingSpeed += 4.7f * Time.deltaTime; }
                
                SkidMarks.transform.localPosition = new Vector3(0.48f, 0, -1.36f);
                transform.localPosition += new Vector3(0, 0, 1) * movingSpeed * Time.deltaTime;
            }
        }

        boostTakenPos = new Vector3(transform.position.x, -1f, transform.position.z);
    }

    // float Rturn, Lturn;
    void LocalMoveL(float x)
    {
        skidMarkControl = 1;

        //kinda realistic drift code 
        /*    if (Lturn != 15f)
            {
                transform.Rotate(Vector3.down * 60 * Time.deltaTime);
              //  transform.localPosition += new Vector3(3, 0, 0) * Time.deltaTime;
                Lturn++;
            }
            if (Lturn >= 15f)
            {
            transform.Rotate(Vector3.up * driftAngle * Time.deltaTime);
            transform.localPosition += new Vector3(x, 0, 0) * Speed * Time.deltaTime;

            }
          */

        wheelObjectL.transform.localRotation = Quaternion.Euler(0, -60f, 0);
        wheelObjectR.transform.localRotation = Quaternion.Euler(0, 120f, 0);

        wheelObjectL.localPosition = new Vector3(-0.47f, 0, -2.9f);
        wheelObjectR.localPosition = new Vector3(2f, 0, -1f);

        transform.Rotate(Vector3.up * driftAngle * Time.deltaTime);
        transform.localPosition += new Vector3(x, 0, 0) * Speed * Time.deltaTime;
    }

    void LocalMoveR(float x)
    {
        skidMarkControl = 1;

        //kinda realistic drift code 
        /*  if (Rturn != 15f)
           {
               transform.Rotate(Vector3.up * 60 * Time.deltaTime);
             //  transform.localPosition += new Vector3(3, 0, 0) * Time.deltaTime;
               Rturn++;
               Debug.Log("Rturn: " + Rturn);
           }
           if (Rturn >= 15f)
           {
               transform.Rotate(Vector3.down * driftAngle * Time.deltaTime);
               transform.localPosition += new Vector3(x, 0, 0) * Speed * Time.deltaTime;
           }
         */

        wheelObjectL.transform.localRotation = Quaternion.Euler(0, 60f, 0);
        wheelObjectR.transform.localRotation = Quaternion.Euler(0, 240f, 0);

        wheelObjectL.localPosition = new Vector3(2.8f, 0, 0.72f);
        wheelObjectR.localPosition = new Vector3(-1.23f, 0, -4.8f);

        transform.Rotate(Vector3.down * driftAngle * Time.deltaTime);
        transform.localPosition += new Vector3(x, 0, 0) * Speed * Time.deltaTime;

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
       // Rturn = Lturn = 0;
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("SpeedBoost"))
        {
            MainSpeed++;
            movingSpeed += 2;
            Debug.Log("SpeedIncrease Speed: " + MainSpeed);
            if (MainSpeed == 1)
            {
                ExhaustFlame.SetActive(true);
            }
            else
            {
                speedIncreaseEffect.SetActive(true);
                ExhaustFlameEx.SetActive(true);
                ExhaustFlame.SetActive(false);
            }

            Quaternion rotParticle = Quaternion.Euler(boostTakenRot);
            Quaternion posParticle = Quaternion.Euler(boostTakenPos);
            //  Instantiate(boostTakenParticle, boostTakenPos * 1.02349f, rotParticle);
            Instantiate(boostTakenParticle, boostTakenPos, rotParticle);

            Destroy(coll.gameObject);

            if (Glass.glassEnter == false)
            { StartCoroutine(SpeedDelay()); }
            
        }

        if (coll.gameObject.CompareTag("WeightBoost"))
        {
            MainCarWeight++;
            movingSpeed -= 1;

            Quaternion rotParticle = Quaternion.Euler(boostTakenRot);
            Quaternion posParticle = Quaternion.Euler(boostTakenPos);
          //  Instantiate(boostTakenParticle, boostTakenPos * 1.02349f, rotParticle);
            Instantiate(boostTakenParticle, boostTakenPos, rotParticle);

            Debug.Log("WeightIncrease weight: " + MainCarWeight);
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

            Destroy(coll.gameObject);

            if (Glass.glassEnter == false)
            { StartCoroutine(WeightDelay()); }
      
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lvlEndEnter"))
        {
            Debug.Log("LevelEndReached!!");

            ExhaustFlame.SetActive(false);
            ExhaustFlameEx.SetActive(false);
            speedIncreaseEffect.SetActive(false);
          //  movingSpeed = normalSpeed;
            MainSpeed = 0;
            spin = 0;
            MainCarWeight = 0;
            transform.localScale = CarSizes;
            Glass.glassEnter = false;

            LevelEndController.lvlEndEnter = true;
        }
        if (other.gameObject.CompareTag("lvlEndCircle"))
        {
            circleLvlEnd = true;
        }
    }

    void CarRotateHome()
    {
        if (transform.eulerAngles.y != 180)
        {
         //   Debug.Log("ReturningRotation! Rot: " + transform.eulerAngles.y);

            if (transform.eulerAngles.y < 180) { transform.Rotate(Vector3.down * recoverSpeed * Time.deltaTime); }

            if (transform.eulerAngles.y > 180) { transform.Rotate(Vector3.up * recoverSpeed * Time.deltaTime); }

            wheelObjectL.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            wheelObjectR.transform.localRotation = Quaternion.Euler(0, 180, 0);

            wheelObjectL.localPosition = new Vector3(0.05f, 0, 0f);
            wheelObjectR.localPosition = new Vector3(1.43f, 0, -3.732f);

            if (skidMarkControl == 1) { StartCoroutine(SkidMarkDelay()); }
        }
        else
        {
          //  Debug.Log("NormalRotation Rot: " + transform.eulerAngles.y);
        }
    }

    public IEnumerator SpeedDelay()
    {
        yield return new WaitForSeconds(3);
        ExhaustFlame.SetActive(false);
        ExhaustFlameEx.SetActive(false);
        speedIncreaseEffect.SetActive(false);
        movingSpeed = normalSpeed;
        MainSpeed = 0;
        spin = 0;
        Glass.glassEnter = false;
    }

    public IEnumerator WeightDelay()
    {
        yield return new WaitForSeconds(3);
        MainCarWeight = 0;
        movingSpeed = normalSpeed;
        speedIncreaseEffect.SetActive(false);
        transform.localScale = CarSizes;
        Glass.glassEnter = false;
    }

    public IEnumerator SkidMarkDelay()
    {
        yield return new WaitForSeconds(2);
        SkidMarks.transform.localPosition = new Vector3(0, -30, -15);
        skidMarkControl = 0;
    }
}
