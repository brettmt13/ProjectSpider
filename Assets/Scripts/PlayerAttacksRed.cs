using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
public class PlayerAttacksRed : MonoBehaviour
{

    private Animator anim;
    public GameObject ftiltHitbox1;
    public GameObject ftiltHitbox2;
    public GameObject uptiltHitbox;
    public GameObject fairHitbox;
    public GameObject dairHitbox;
    public GameObject upairHitbox1;
    public GameObject upairHitbox2;
    public GameObject upairHitbox3;
    public float fairHitboxRadius;
    public float ftiltHitboxRadius;
    public float uptiltHitboxRadius;
    public float dairHitboxRadius;
    public float upairHitboxRadius;
    public LayerMask enemyLayer;
    public PlayerMovementRed playerMovement;
    Controls playerInput;
    private Vector2 attackDirection;
    
    public AudioSource source;
    public AudioClip ftiltAudio;
    public AudioClip uptiltAudio;
    public bool showFtiltHitboxes;
    public bool showUptiltHitboxes;
    public bool showFairHitboxes;
    public bool showDairHitboxes;
    public bool showUpairHitboxes;


    private void Awake()
    {
        playerInput = new Controls();
        playerInput.Enable();
        playerInput.Player.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

// GROUNDED ATTACKS

    public void startFTilt()
    {
        Collider2D[] hitbox1 = Physics2D.OverlapCircleAll(ftiltHitbox1.transform.position, ftiltHitboxRadius, enemyLayer);
        Collider2D[] hitbox2 = Physics2D.OverlapCircleAll(ftiltHitbox2.transform.position, ftiltHitboxRadius, enemyLayer);

        if(hitbox1.Length > 0){
            foreach (Collider2D enemyGameobject in hitbox1)
            {
                if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                    enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 35, 20, (float)0.3);
                }
                else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                    enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 35, 20, (float)0.3);
                }
                // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (ftiltHitbox1.transform.position.x >= enemyGameobject.transform.position.x);
            }
        }
        else if(hitbox2.Length > 0){
            foreach (Collider2D enemyGameobject in hitbox2)
            {
                if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                    enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 35, 20, (float)0.3);
                }
                else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                    enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 35, 20, (float)0.3);
                }
                // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (ftiltHitbox1.transform.position.x >= enemyGameobject.transform.position.x);
            }           
        }


    }


    public IEnumerator endFTilt()
    {
        anim.SetBool("isFtilt", false);
        yield return new WaitForSeconds(0.1f);
        playerMovement.inAttackState = false;
        // Debug.Log(playerInput.Player.Move.enabled);
    }


    public void startUpTilt()
    {
        // ftiltHitbox1.transform.position.y += 0.2f;
        Collider2D[] enemy = Physics2D.OverlapCircleAll(uptiltHitbox.transform.position, uptiltHitboxRadius, enemyLayer);
        foreach (Collider2D enemyGameobject in enemy)
        {
            enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (uptiltHitbox.transform.position.x >= enemyGameobject.transform.position.x);
            enemyGameobject.GetComponent<PlayerTwoHP>().TakeDamage(30, 10, 40, (float)0.3);
        }
    }


    public IEnumerator endUpTilt()
    {
        anim.SetBool("isUptilt", false);
        yield return new WaitForSeconds(0.3f);
        playerMovement.inAttackState = false;
        // ftiltHitbox1.transform.position.y -= 0.2f;
    }


// AERIAL ATTACKS

    public void startFAir()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(fairHitbox.transform.position, fairHitboxRadius, enemyLayer);
        foreach (Collider2D enemyGameobject in enemy)
        {
            if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 40, 40, (float)0.3);
            }
            else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 40, 40, (float)0.3);
            }
            // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
        }
    }


    public IEnumerator endFAir()
    {
        anim.SetBool("isFair", false);
        yield return new WaitForSeconds(0.3f);
        playerMovement.inAerialState = false;
        playerMovement.playerInput.Player.Jump.Enable();
        playerMovement.playerInput.Player.Dash.Enable();
        playerMovement.playerInput.Player.WJump.Enable();
        playerMovement.playerInput.Player.Attack.Enable();

    }


    public void startUpAir()
    {
        Collider2D[] hitbox1 = Physics2D.OverlapCircleAll(upairHitbox1.transform.position, upairHitboxRadius, enemyLayer);
        Collider2D[] hitbox2 = Physics2D.OverlapCircleAll(upairHitbox2.transform.position, upairHitboxRadius, enemyLayer);
        Collider2D[] hitbox3 = Physics2D.OverlapCircleAll(upairHitbox3.transform.position, upairHitboxRadius, enemyLayer);

        if(hitbox1.Length > 0){
            foreach (Collider2D enemyGameobject in hitbox1)
            {
                if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                    enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 35, 20, (float)0.3);
                }
                else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                    enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 35, 20, (float)0.3);
                }
                // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
            }
        }
        else if(hitbox2.Length > 0){
            foreach (Collider2D enemyGameobject in hitbox2)
            {
                if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                    enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 35, 20, (float)0.3);
                }
                else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                    enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 35, 20, (float)0.3);
                }
                // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
            }           
        }
        else if(hitbox3.Length > 0){
            foreach (Collider2D enemyGameobject in hitbox3)
            {
                if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                    enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 35, 20, (float)0.3);
                }
                else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                    enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 35, 20, (float)0.3);
                }
                // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
            }                
        }
    }


    public IEnumerator endUpAir()
    {
        anim.SetBool("isUpair", false);
        yield return new WaitForSeconds(0.3f);
        playerMovement.inAerialState = false;
        playerMovement.playerInput.Player.Jump.Enable();
        playerMovement.playerInput.Player.Dash.Enable();
        playerMovement.playerInput.Player.WJump.Enable();
        playerMovement.playerInput.Player.Attack.Enable();
        }


    public void startDAir()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(dairHitbox.transform.position, dairHitboxRadius, enemyLayer);
        foreach (Collider2D enemyGameobject in enemy)
        {
            if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(10, 5, -35, (float)0.3);
            }
            else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(10, 5, -35, (float)0.3);
            }
            // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
        }
    }


    public IEnumerator endDAir()
    {
        anim.SetBool("isDair", false);
        yield return new WaitForSeconds(0.3f);
        playerMovement.inAerialState = false;
        playerMovement.playerInput.Player.Jump.Enable();
        playerMovement.playerInput.Player.Dash.Enable();
        playerMovement.playerInput.Player.WJump.Enable();
        playerMovement.playerInput.Player.Attack.Enable();

    }


// wall attack hitbox needs to be negative in x direction, because player techincally facing left when sprite looks right!!
    public void startWallAttack()
    {
        // ftiltHitbox1.transform.position.y += 0.2f;
        Collider2D[] enemy = Physics2D.OverlapCircleAll(uptiltHitbox.transform.position, uptiltHitboxRadius, enemyLayer);
        foreach (Collider2D enemyGameobject in enemy)
        {
            if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerRed"){
                enemyGameobject.GetComponent<PlayerHealthRed>().TakeDamage(30, 10, 40, (float)0.3);
            }
            else if(enemyGameobject.gameObject.ToString().Split()[0] == "PlayerGreen"){
                enemyGameobject.GetComponent<PlayerHealthGreen>().TakeDamage(30, 10, 40, (float)0.3);
            }
            // enemyGameobject.GetComponent<PlayerTwoHP>().fromRight = (fairHitbox.transform.position.x >= enemyGameobject.transform.position.x);
        }
    }


    public IEnumerator endWallAttack()
    {
        anim.SetBool("isWallAttack", false);
        yield return new WaitForSeconds(0.3f);
        playerMovement.inAerialState = false;
        // ftiltHitbox1.transform.position.y -= 0.2f;
    }


    private void OnDrawGizmos()
    {
        if(showFtiltHitboxes){
            Gizmos.DrawWireSphere(ftiltHitbox1.transform.position, ftiltHitboxRadius);
            Gizmos.DrawWireSphere(ftiltHitbox2.transform.position, ftiltHitboxRadius);
            //something
        }
        if(showUptiltHitboxes){
            Gizmos.DrawWireSphere(uptiltHitbox.transform.position, uptiltHitboxRadius);
        }
        if(showFairHitboxes){
            Gizmos.DrawWireSphere(fairHitbox.transform.position, fairHitboxRadius);
        }
        if(showDairHitboxes){
            Gizmos.DrawWireSphere(dairHitbox.transform.position, dairHitboxRadius);
        }
        if(showUpairHitboxes){
            Gizmos.DrawWireSphere(upairHitbox1.transform.position, upairHitboxRadius);
            Gizmos.DrawWireSphere(upairHitbox2.transform.position, upairHitboxRadius);            
            Gizmos.DrawWireSphere(upairHitbox3.transform.position, upairHitboxRadius);            
        }
    }

    public void OnAttack(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("attack");
            if(playerMovement.KBCounter <= 0){
                Debug.Log("into here");
                if(!playerMovement.inAttackState && playerMovement.IsGrounded()){
                    Debug.Log("now in here");
                    playerMovement.inAttackState = true;
                    attackDirection = context.ReadValue<Vector2>();
                    playerMovement.moveDir[0] = 0f;
                    // Debug.Log(attackDirection);
                    if (attackDirection[0] > 0f && playerMovement.facingRight) // ftilt to right
                    {
                        playerMovement.playerInput.Player.Disable();
                        anim.SetBool("isFtilt", true);
                        source.PlayOneShot(ftiltAudio);
                    }
                    else if(attackDirection[0] > 0f && !playerMovement.facingRight){ // facing left, ftilt to right
                        playerMovement.Flip(true);
                        playerMovement.playerInput.Player.Disable();
                        anim.SetBool("isFtilt", true);
                        source.PlayOneShot(ftiltAudio);
                    }
                    else if(attackDirection[0] < 0f && !playerMovement.facingRight){ // ftilt to left
                        playerMovement.playerInput.Player.Disable();
                        anim.SetBool("isFtilt", true);
                        source.PlayOneShot(ftiltAudio);                    
                    }
                    else if(attackDirection[0] < 0f && playerMovement.facingRight){ // facing right, ftilt to left
                        playerMovement.Flip(true);
                        playerMovement.playerInput.Player.Disable();
                        anim.SetBool("isFtilt", true);
                        source.PlayOneShot(ftiltAudio);                   
                    }
                    else if(attackDirection[1] > 0f){ // up tilt
                        playerMovement.playerInput.Player.Disable();
                        anim.SetBool("isUptilt", true);
                        source.PlayOneShot(uptiltAudio);

                    }
                    else{
                        playerMovement.playerInput.Player.Disable(); 
                        anim.SetBool("isFtilt", true);
                        source.PlayOneShot(ftiltAudio);
                    }
                }
                else if(!playerMovement.inAerialState && !playerMovement.IsGrounded() && !playerMovement.isWallSliding){
                    playerMovement.inAerialState = true;
                    attackDirection = context.ReadValue<Vector2>();
                    // Debug.Log(attackDirection[0]);
                    // do aerials, disable necessary inputs while aerialing, and make it so you don't change directions when aerialing
                    if (attackDirection[0] > 0f && playerMovement.facingRight) // fair to right
                        {
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isFair", true);
                        anim.enabled = true;
                        // anim.SetBool("isJumping", false);
                    }
                    else if(attackDirection[0] > 0f && !playerMovement.facingRight){ // facing left, fair to right
                        playerMovement.Flip(false, true);
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isFair", true);
                        anim.enabled = true;
                    }
                    else if(attackDirection[0] < 0f && !playerMovement.facingRight){ // fair to left
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isFair", true);
                        anim.enabled = true;                  
                    }
                    else if(attackDirection[0] < 0f && playerMovement.facingRight){ // facing right, fair to left
                        playerMovement.Flip(false, true);
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isFair", true);
                        anim.enabled = true;                  
                    }
                    else if(attackDirection[1] > 0f){ // up air
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isUpair", true);
                        anim.enabled = true;
                    }
                    else{ // dair
                        playerMovement.playerInput.Player.Jump.Disable();
                        playerMovement.playerInput.Player.Dash.Disable();
                        playerMovement.playerInput.Player.WJump.Disable();
                        playerMovement.playerInput.Player.Attack.Disable();
                        if(anim.GetBool("isJumping")){
                            anim.enabled = false;
                        }
                        
                        anim.SetBool("isDair", true);
                        anim.enabled = true; 
                    }                   
                }
                else if(playerMovement.isWallSliding){
                    playerMovement.inAerialState = true;
                    attackDirection = context.ReadValue<Vector2>();
                    playerMovement.moveDir[0] = 0f;
                    playerMovement.moveDir[1] = 0f; //new
                    if (attackDirection[0] != 0f || attackDirection[1] != 0f) // any right stick input = wall attack
                    {
                        playerMovement.playerInput.Player.Disable(); 
                        anim.SetBool("isWallAttack", true);
                    }
                }
            }
        }
    }
 
}