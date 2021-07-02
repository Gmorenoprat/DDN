
using UnityEngine;

public class PlayerController  //ALL THE INPUT HERE
{
    Player _player;
    Movement _movement;
    BattleMechanics _battle;

    PlayerView _playerView;
    public PlayerController(Player p, Movement m, BattleMechanics b, PlayerView pv)
    {
        _player = p;
        _movement = m;
        _battle = b;
        _playerView = pv;

        //_playerView.Start();
    }

    public void OnUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if ((v != 0 || h != 0))
        {
            _movement.Move(v, h);
         //   _playerView.animator.Move(h, v);
        } //Move

        if (Input.GetKey(KeyCode.Space)) 
        {
            _player.isRolling = true;
            _movement.ChangeMovementMode(MovementMode.PREROLL);
        }//PreRoll

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            _movement.Roll();
          ////  _playerView.animator.Roll();
            _movement.ChangeMovementMode(MovementMode.NORMAL);
        }//Roll
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _movement.ChangeMovementMode(MovementMode.CROUCHED);
            //_playerView.animator.Crouch(true);
        } //Crouched
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movement.ChangeMovementMode(MovementMode.NORMAL);
           // _playerView.animator.Crouch(false);
        } //Crouched

        if (!Input.GetKeyDown(KeyCode.Space)) _movement.Aim();


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _battle.Shoot();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _battle.StopShoot();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            _battle.ReloadActiveWeapon();
        }



        //UsarEstoParaCambiarDeArma
        if (Input.GetKeyDown(KeyCode.Alpha1)) { _battle.ChangeFiringMode(FiringMode.SINGLESHOOT); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { _battle.ChangeFiringMode(FiringMode.BURSTSHOOT); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { _battle.ChangeFiringMode(FiringMode.AUTOSHOOT); }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            FiringMode temp = _battle.getCurrentFireMode();
            if(temp == FiringMode.SINGLESHOOT) _battle.ChangeFiringMode(FiringMode.BURSTSHOOT); //
            if (temp == FiringMode.BURSTSHOOT) _battle.ChangeFiringMode(FiringMode.AUTOSHOOT);  //TODO
            if (temp == FiringMode.AUTOSHOOT) _battle.ChangeFiringMode(FiringMode.SINGLESHOOT); //

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _battle.launchGranade();
        }
        if (Input.GetKeyDown(KeyCode.T)) //SOLO HAY UNA DE MOMENTO
        {
            _battle.changeGranade();
        }



    }
}
