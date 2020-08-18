using UnityEngine;
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
    private boolm_wasCrouching = false;

        private void Awake ()
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
        for (int i = 0; i <colliders.)
    }
    