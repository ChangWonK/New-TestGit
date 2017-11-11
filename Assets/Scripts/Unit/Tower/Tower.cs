using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum States { WATING = 0, IDLE, MOVE, ATTACK }

    public TowerBase TowerBase;

    private States _currentState = States.IDLE;

    public States CurrentState
    {
        set
        {

            Debug.Log("dDddd");
            _currentState = value;
        }
    }

    private List<EnemyBase> _targetList = new List<EnemyBase>();
    private bool _isMovable = false;
    private float _attackDelay = 0;    
    private GameObject _target;
    private Transform _transform;
    private bool _isAttackable = true;
    private Animator _animator;
    

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Init()
    {
        TowerBase.SetAility();
        _isMovable = true;
        if (_isMovable == true)
            _currentState = States.IDLE;

        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        UpdateStates();
    }
    public void UpdateStates()
    {
        switch (_currentState)
        {   


            case States.IDLE:
                {
                    Debug.Log("Check");
                    CheckTarget();
                    CooltimeCheck();
                    
                }
                break;
            case States.MOVE:
                {
                    Debug.Log("MOVE");
                    CheckTarget();
                    CooltimeCheck();
                    Move();
                }
                break;
            case States.ATTACK:
                {
                    Debug.Log("ATTACK");
                    Attack();
                }
                break;                      
        }
    }

    private void OnceFunc(States state)
    {
        _currentState = state;
        Debug.Log("animator");
    }

    // 적 감지하는 함수
    private void CheckTarget()
    {
        _target = SpawnManager.i.GetCloseEnemyList(_transform);
        if (_target == null) return;
        if (Vector3.Distance(_target.transform.position , _transform.position) < TowerBase.AtkRange)
         {
            // 공격으로 바꿔준다
            if(_isAttackable)
            {                
                CurrentState = States.ATTACK;
                return;
            }
          }

        if (_currentState.Equals(States.MOVE))
            return;

        CurrentState = States.MOVE;
            
    }     
    
      

    // 공격하는 함수
    private void Attack()
    {
        if (!_isAttackable)
        {
            _currentState = States.IDLE;
            return;
        }

        Debug.Log("Real Attack , Change AniMation");
        _attackDelay = TowerBase.AtkSpeed;
        _isAttackable = false;
    } 

    private void Move()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _target.transform.position, Time.deltaTime * TowerBase.AtkSpeed);

    }


    private void CooltimeCheck()
    {
        if (_isAttackable)
            return;

        _attackDelay -= Time.deltaTime;

        if (_attackDelay <= 0)
            _isAttackable = true;

    }
    
    void OnMouseDown()
    {
        Debug.Log(_targetList.Count);
        UIManager.i.GetPageUIObject<PageGame>().TowerClickEvent(this);
    }
}
