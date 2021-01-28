using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Rewired.ControllerExtensions;

public class PlayerController : MonoBehaviour
{

    // rewired Requirements
    [SerializeField] private int _playerId = 0;
    private Player _player;

    // Movement Requirements
    //camera stuff
    private float _cameraX = 0f;
    private float _cameraY = 0f;

    public float turnSpeed = 5f;
    public float FOVSpeed = 0.75f;
    public float MinFov = 0f;
    public float MaxFov = 5f;
    public float LookUpSpeed = 20f; //how fast we look up and down
    private float YTurn = 0; //how much we have turned left and right
    private float XTurn = 0; //how much we have turned Up or Down
    public float MaxLookAngle = 65; //how much we can look up
    public float MinLookAngle = -30; //how much we can look down
    [SerializeField] private Camera camera;




    // Movment stuff
    private float _moveFor = 0f;
    private float _moveStrafe = 0f;
    private float _maxSpeed = 20f;
    private float _backSpeed = 5f;
    private float ActSpeed = 0f;

    private float _accel = 0.6f;
    private float _decell = 5f;


    private Rigidbody _rb;
    private CapsuleCollider _capColl;
    [SerializeField] private float _playerSpeed = 5f;


    //Jumping handlers
    [SerializeField] private float JUMP_FORCE = 10f;
    private float yVelocity = 0f;
    private bool _canJump = true;
    private bool _jumped = false;
    private float fallMultiplier = 1.5f;
    private bool _bufferJump = false;
    private float _bufferTimeLimit = 0.5f; // Change to 0.1f once it works
    private float _coyoteTime = 0f;
    private float _coyoteTimeLimit = 0.5f; // Change to 0.1f once it works

    

    // Start is called before the first frame update
    void Start()
    {
        // Set up everything
        _player = ReInput.players.GetPlayer (_playerId);
        _rb = GetComponent<Rigidbody>();
        _capColl= GetComponent<CapsuleCollider>();
        
        Physics.gravity = new Vector3 (0, -30.0F, 0);
    }

    // Update to handle during physics
    void FixedUpdate()
    {
        float Del = Time.deltaTime;

        //get our players rotation amount for turning


        //have our player look up and down

        //handle our fov
        //

        //get inputs
        float horInput = _player.GetAxis(RewiredMappings.MOVE_HORIZONTAL);
        float verInput = _player.GetAxis(RewiredMappings.MOVE_VERTICAL);
        float CamX = _player.GetAxis(RewiredMappings.CAMERA_HORIZONTAL);
        float CamY = _player.GetAxis(RewiredMappings.CAMERA_VERTICAL);
        LookUpDown(CamY, Del);

        
        HandleFov(Del);
        // Ground Movment stuff -> Expand to introduce many cases
            //get magnituded of our inputs
            float InputMagnitude = new Vector2(horInput, verInput).normalized.magnitude;
            //get the amount of speed, based on if we press forwards or backwards
            float TargetSpd = Mathf.Lerp(_backSpeed, _maxSpeed, verInput); //using the vertical input as a lerp from if forward is being pressed

            LerpSpeed(InputMagnitude, Del, TargetSpd);

            MovePlayer(horInput, verInput, Del);
            TurnPlayer(CamX, Del, turnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Update movments in Update, Apply in FixedUpdate
        _moveStrafe = _player.GetAxis (RewiredMappings.MOVE_HORIZONTAL);
        _moveFor = _player.GetAxis (RewiredMappings.MOVE_VERTICAL);
    }

    void LerpSpeed(float InputMag, float D, float TargetSpeed)
    {
        //multiply our speed by our input amount
        float LerpAmt = TargetSpeed * InputMag;
        //get our acceleration (if we should speed up or slow down
        float Accel = _accel;
        if (InputMag == 0)
            Accel = _decell;
        //lerp by a factor of our acceleration
        ActSpeed = Mathf.Lerp(ActSpeed, LerpAmt, D * Accel);
    }

    void MovePlayer(float Hor, float Ver, float D)
    {
        //find the direction to move in, based on the direction inputs
        Vector3 MovementDirection = (transform.forward * Ver) + (transform.right * Hor);
        MovementDirection = MovementDirection.normalized;
        //if we are no longer pressing and input, carryon moving in the last direction we were set to move in
        if (Hor == 0 && Ver == 0)
            MovementDirection = _rb.velocity.normalized;

        MovementDirection = MovementDirection * ActSpeed;

        //apply Gravity and Y velocity to the movement direction 
        MovementDirection.y = _rb.velocity.y;

        //apply adjustment to acceleration
        float Acel = 8f;
        Vector3 LerpVelocity = Vector3.Lerp(_rb.velocity, MovementDirection, Acel * D);
        _rb.velocity = LerpVelocity;          
    }
    
    void TurnPlayer(float Hor, float D, float turn)
    {
        //add our inputs to our turn value
        YTurn += (Hor * D) * turn; 
        //turn our character
        transform.rotation = Quaternion.Euler(0, YTurn, 0);
    }
    
    void HandleFov(float D)
    {
        //get our velocity magniture
        float mag = new Vector2(_rb.velocity.x, _rb.velocity.z).magnitude;
        //get appropritate fov 
        float LerpAmt = mag / FOVSpeed;
        float FieldView = Mathf.Lerp(MinFov, MaxFov, LerpAmt);
        //ease into this fov
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, FieldView, 4 * D);
    }

    void LookUpDown(float Ver, float D)
    {
        //add our inputs to our look angle
        XTurn -= (Ver * D) * LookUpSpeed;
        XTurn = Mathf.Clamp(XTurn, MinLookAngle, MaxLookAngle);
        //look up and down
        camera.transform.localRotation = Quaternion.Euler(XTurn, 0, 0);
    }
}
