using UnityEngine;

public class Character
{
    private float _humanAtkPower;
    private float _humanAtkSpeed;
    private float _humanAtkRange;
    private float _humanMoveSpeed;
    private float _machineAtkPower;
    private float _machineAtkSpeed;
    private float _machineAtkRange;
    private float _machineMoveSpeed;
    private float _magicAtkPower;
    private float _magicAtkSpeed;
    private float _magicAtkRange;
    private float _magicMoveSpeed;

    public void Init()
    {
        GetItemAbility();
    }

    private void GetItemAbility()
    {
       var enumer =  UserInformation.i.Inventory.GetEnumerMountingItemDic();

        while(enumer.MoveNext())
        {
            _humanAtkPower += enumer.Current.Value.HumanAtkPower;
            _humanAtkSpeed += enumer.Current.Value.HumanAtkSpeed;
            _humanAtkRange += enumer.Current.Value.HumanAtkRange;
            _humanMoveSpeed += enumer.Current.Value.HumanMoveSpeed;

            _machineAtkPower += enumer.Current.Value.MachineAtkPower;
            _machineAtkSpeed += enumer.Current.Value.MachineAtkSpeed;
            _machineAtkRange += enumer.Current.Value.MachineAtkRange;
            _machineMoveSpeed += enumer.Current.Value.MachineMoveSpeed;

            _magicAtkPower += enumer.Current.Value.MagicAtkPower;
            _magicAtkSpeed += enumer.Current.Value.MagicAtkSpeed;
            _magicAtkRange += enumer.Current.Value.MagicAtkRange;
            _magicMoveSpeed += enumer.Current.Value.MagicMoveSpeed;
        }
    }



    public float GetHumanAtkPower() { return _humanAtkPower; }
    public float GetHumanAtkSpeed() { return _humanAtkSpeed; }
    public float GetHumanAtkRange() { return _humanAtkRange; }
    public float GetHumanMoveSpeed() { return _humanMoveSpeed; }

    public float GetMachineAtkPower() { return _machineAtkPower; }
    public float GetMachineAtkSpeed() { return _machineAtkSpeed; }
    public float GetMachineAtkRange() { return _machineAtkRange; }
    public float GetMachineMoveSpeed() { return _machineMoveSpeed; }

    public float GetMagicAtkPower() { return _magicAtkPower; }
    public float GetMagicAtkSpeed() { return _magicAtkSpeed; }
    public float GetMagicAtkRange() { return _magicAtkRange; }
    public float GetMagicMoveSpeed() { return _magicMoveSpeed; }




}
