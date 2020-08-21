/*using UnityEngine;
using UnityEngine.Event;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                      //Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;      //Amount of maxspeed applied to crouching movement. 1 = 100%
    [Range(0, 3f)] [SerializeField] private float m_MovementSmoothing = .05f;   //How much to smooth out the movement 
    [SerializeFeild] private bool m_AirControl = false;             // whether or not a player can steer while jumping
    [SerializeField] private LayerMask m_WhatIsGround;              // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;               // A position marking where to check if the player is grounded
    [SerializeField] private Transform m_CeilingCheck;              // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;    // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f;   // Radius of the overlap circle to determine if grounded 
    private bool m_Grounded;              // whether or not player is grounded 
    const float k_CeilingRadius = .2f;    // Radius of the overlapping circleto determine if player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;    // For determining which way the player is facing
    private Vector3 m_Velocity = Velocity3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

        private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrouned = m_Grounded;
        m_Grounded = false;

        // the player is grounded if a circlecast to the groundcheck position hits anything  designated as ground 
        //this can be done using layers instead but sample assets will NOT overwrite your project settings
        Collider2D[] colliders = physics2D.OverlapCircleAll(m_GroundedCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrouned)
                    OnLandEvent.invoke();
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // if crouching,check to see if the character can stand up 
        if (!crouch)
        {
            // if the character has a ceiling proventing them from standing up, keep them crouching 
            if (physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or aircontrol is turned on 
        if (m_Grounded || m_AirControl)
        {

            // if crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.invoke(true);
                }

                // Reduce the speed by the crouchspeed multiplier
                move *= m_CrouchSpeed;

                // Enable the collider when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            } else
            {
                // Enablethe collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            //move the character by finding the target velocity
            vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // and thensmoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.smoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // if  the imput is moving the player right and the player is facing left....
            if (move > 0 && !m_FacingRight)
            {
                //... flip the player.
                Flip();
            }
            // otherwise if the input is moving the player left and the player is facing the right...
            else if (move < 0 && m_FacingRight)
            {
                //....flip the player.
                Flip();
            }
        }
        // if the player should jump....
        if (m_Grounded && jump)
        {
            // add a verticle force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScaleScale.x *= -1;
        transform.localScale = theScalel;
    }
}*/


























































