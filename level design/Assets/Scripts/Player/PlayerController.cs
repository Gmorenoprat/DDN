
using UnityEngine;

public class PlayerController  //ALL THE INPUT HERE
{
    Player _player;
    Movement _movement;
    BattleMechanics _battle;


    SoundMananger _soundMananger;
    public PlayerController(Player p, Movement m, BattleMechanics b, SoundMananger s)
    {
        _player = p;
        _movement = m;
        _battle = b;
        _soundMananger = s;
    }

    public void OnUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _player._animator.SetFloat("Speed_Forward", v);
        _player._animator.SetFloat("Speed_Right", h);

        if (Input.GetKey(KeyCode.Space)) //ACA ROLL
        {
            _player.isRolling = true;
            _movement.RollAim(v, h);
        }      
        
        if (Input.GetKeyUp(KeyCode.Space)) //ACA ROLL
        {
            // if (_player.isGrounded) _soundMananger.SoundPlay((int)sounds.JUMP);
            // _movement.Jump();
            _movement.Roll(v, h);
            _player.isRolling = false;

        }

        
        if ((v != 0 || h != 0) && !_player.isRolling )
        {
            //_player.GetComponent<Animator>().SetBool("Moving", true);
            _movement.Move(v, h);
        }

        if (!Input.GetKeyDown(KeyCode.Space)) _movement.Aim();


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _battle.Shoot();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _battle.StopShoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _movement.Crouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movement.StandUp();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) { _battle.ChangeFiringMode(FiringMode.SINGLESHOOT); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { _battle.ChangeFiringMode(FiringMode.BURSTSHOOT); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { _battle.ChangeFiringMode(FiringMode.AUTOSHOOT); }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            FiringMode temp = _battle.getCurrentFireMode();
            if(temp == FiringMode.SINGLESHOOT) _battle.ChangeFiringMode(FiringMode.BURSTSHOOT);
            if (temp == FiringMode.BURSTSHOOT) _battle.ChangeFiringMode(FiringMode.AUTOSHOOT);
            if (temp == FiringMode.AUTOSHOOT) _battle.ChangeFiringMode(FiringMode.SINGLESHOOT);

        }

    }
}
