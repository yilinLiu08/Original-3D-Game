using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour, ISaveable
{
    [Header("Inventory")]
    public GameObject mybag;
    bool isOpen;
    
    
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public Image healthBar;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ISaveable saveable = this;
        saveable.RegisterSaveData();
        readyToJump = true;
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        ISaveable saveable = this;
        saveable.UnRegisterSaveData();
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();
        OpenMyBag();

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - playerHeight * 0.5f + 0.3f), Color.red);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    #region "Input"
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    #endregion

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    #region "Speed"
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    #endregion

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        Debug.Log("ready to jump");
    }
    void OpenMyBag()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            isOpen = !isOpen;
            mybag.SetActive(!isOpen);
        }
    }

    public DataDefinition GetDataID()
    {
        return GetComponent<DataDefinition>();
    }

    public void GetSaveData(Data data)
    {
        //if(data.characterPosDict.ContainsKey(GetDataID().ID))
        //{
        //    data.characterPosDict[GetDataID().ID] = transform.position;
        //}
        //else
        //{
        //    data.characterPosDict.Add(GetDataID().ID, transform.position); 
        //}
    }
    public void LoadData(Data data)
    {
        //if (data.characterPosDict.ContainsKey(GetDataID().ID))
        //{
        //    transform.position = data.characterPosDict[GetDataID().ID];
        //}
    }

    #region "Health"
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        healthBar.fillAmount = (float) health / 100f;
    }
    #endregion
}