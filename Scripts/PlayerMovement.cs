 using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckLeft; //Marqueur pour savoir si le personnage est sur le sol, a gauche
    public Transform groundCheckRight; //Marqueur pour savoir si le personnage est sur le sol, a droite

    public Rigidbody2D rb; //Systeme d'entite physique (PAS le systeme de hitbox)
    public Animator animator; //Liaison pour les animations
    public SpriteRenderer spriteRenderer; //Liaison pour les differents sprites

    private Vector3 velocity = Vector3.zero; //Variable pour le deplacement sur axe


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position); //Est-ce que les capteurs du personnage au sol le détectent ou non ?

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //Systeme de deplacement avec vitesse sur axe

        /**if(Input.getButtonDown("Jump") && isGrounded) //Syteme de saut (incorrecte)
        {
            isJumping = true;
        }**/

        MovePlayer(horizontalMovement); //Fonction de deplacement

        Flip(rb.velocity.x); //Systeme d'inversement de sprite en rapport avec la direction de deplacement

        float characterVelocity = Mathf.Abs(rb.velocity.x); //Fonction qui rend la direction de deplacement forcement positive pour eviter certains problemes de vitesse
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement) //Fonction de deplacement
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true) //Systeme de deplacement apres pression sur Espace en rapport avec la vitesse de deplacement (incorrecte)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

    }

    void Flip(float _velocity) //Fonction d'inversement de sprite en rapport avec la direction de deplacement
    {
        if(_velocity > 0.1f) //Sprite vers la droite parce que si le deplacement est positive, on avance sur l'axe des x
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f) //Sprite vers la gauche parce que si le deplacement est negatif, on recule sur l'axe des x
        {
            spriteRenderer.flipX = true;
        }
    }

}