using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 16f;
    
    [HideInInspector] public bool controls_enabled = true;
    Vector2 current_direction_vector2;

    //######################################
    void Update()
    {
        if (controls_enabled) MovementInputs();
        
        InteractionInput();
    }

    //######################################
    void InteractionInput()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // try to interact with shopkeeper or clothing 
            Vector2 interact_circle_position = (Vector2)transform.position + 0.5f * current_direction_vector2;
            Collider2D[] colliders_hit = Physics2D.OverlapCircleAll(interact_circle_position, 1f);

            foreach (Collider2D col2d in colliders_hit)
            {
                MonoBehaviour[] mb_scripts_on_objects = col2d.GetComponents<MonoBehaviour>();
                
                foreach(var mb_script in mb_scripts_on_objects)
                {
                    if (mb_script is IInteractable)
                    {
                        controls_enabled = false;
                        IInteractable interactable = (IInteractable)mb_script;
                        interactable.OnInteract();
                        break;
                    }

                }
            }

        }


    }


    //######################################
    void MovementInputs()
    {
        Vector2 move_vector2 = Vector2.zero;

        float horizontal_input = Input.GetAxis("Horizontal");
        float   vertical_input = Input.GetAxis("Vertical");

        if (horizontal_input != 0) move_vector2 += new Vector2(Mathf.Sign(horizontal_input), 0);
        if (  vertical_input != 0) move_vector2 += new Vector2(0, Mathf.Sign(vertical_input));

        // normalizing speed of diagonal movement
        if (move_vector2.x != 0 && move_vector2.y != 0) move_vector2.Normalize();

        GetComponent<Rigidbody2D>().velocity = move_vector2 * speed;

        // setting up animations and direction vector
        SetVisualDirection(move_vector2);
    }

    //######################################
    void SetVisualDirection(Vector2 move_vector2)
    {
        Animator animator = GetComponent<Animator>();
        if      (move_vector2.y > 0) { animator.Play("pc walk up"   ); current_direction_vector2 = new Vector2( 0, 1); }
        else if (move_vector2.y < 0) { animator.Play("pc walk down" ); current_direction_vector2 = new Vector2( 0,-1); }
        else if (move_vector2.x > 0) { animator.Play("pc walk right"); current_direction_vector2 = new Vector2( 1, 0); }
        else if (move_vector2.x < 0) { animator.Play("pc walk left" ); current_direction_vector2 = new Vector2(-1, 0); }
        else animator.SetTrigger("stop");

    }

}
