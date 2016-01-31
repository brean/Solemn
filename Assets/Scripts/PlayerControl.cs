using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerControl : MonoBehaviour {
    private PlayerCharacter m_Character;
    private bool m_Jump;
    private bool active = true;

    long firstTouchTime;

	private Vector2 fingerStart;
	private Vector2 fingerEnd;

    private bool jumpedThisPhase = false;

    public void Stop()
    {
        this.active = false;
    }

    private void Awake()
    {
        m_Character = GetComponent<PlayerCharacter>();
    }

    private void Update()
    {
        if (!m_Jump)
        {
            // jumping logic
            m_Jump = false;
        }
    }

    private void FixedUpdate()
    {
        // Pass all parameters to the character control script.
        if (this.active)
        {
            handleInput();
        }
    }

    void handleInput()
    {
        if (Input.mousePresent)
        {
            if (Input.GetMouseButtonDown(0))
            {
                controlPlayer("left", "start");
            }
            else if (Input.GetMouseButtonUp(0))
            {
                controlPlayer("left", "ended");
            }

            if (Input.GetMouseButtonDown(1))
            {
                controlPlayer("right", "start");
            }
        }


        foreach (Touch touch in Input.touches)
        {

            Vector3 fingerPos = touch.position;
            if (fingerPos.x < Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Stationary) //Run
                {
                    controlPlayer("left", "start");
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    controlPlayer("left", "ended");
                }
            }
            else {


                if (touch.phase == TouchPhase.Began)
                {
                    fingerStart = touch.position;
                    fingerEnd = touch.position;
                }

                // Swipe detection
                if (touch.phase == TouchPhase.Moved && !jumpedThisPhase)
                {
                    fingerEnd = touch.position;

                    //There is more movement on the Y axis than the X axis
                    if (Mathf.Abs(fingerStart.x - fingerEnd.x) <= Mathf.Abs(fingerStart.y - fingerEnd.y))
                    {
                        //Upward Swipe
                        if ((fingerEnd.y - fingerStart.y) > 10 && (fingerPos.x > Screen.width / 2))
                        {
                            controlPlayer("right", "start"); // the finger is pressed down, start jumping
                            jumpedThisPhase = true;
                        }
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    jumpedThisPhase = false;
                    //After the checks are performed, set the fingerStart & fingerEnd to be the same
                    fingerStart = Vector2.zero;
                    fingerEnd = Vector2.zero;
                }
            }
        }

    }


    // handle input to control the player
    void controlPlayer(string position, string inputType)
    {
        // move character when touched/mouse down
        if (position == "left")
        {
            if (inputType == "start") //Run
            {
                moveForward();
            }
            else if (inputType == "ended")
            {
                stopMoveForward();
            }
        }

        // jump when swipe/(right mouse button)
        if (position == "right" && inputType == "start")
        {
            jump();
        }
    }

    private void jump()
    {
        m_Character.Move(1f, true);
    }

    private void moveForward()
    {
        m_Character.Move(1f, false);
        m_Jump = false;
    }

    private void stopMoveForward()
    {
        m_Character.Move(0.0f, false);
        m_Jump = false;
    }
}