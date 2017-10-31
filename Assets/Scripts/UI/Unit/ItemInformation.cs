using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemInformation : UIObject
{
    private Image _image;
    private Text _name;
    private Text _kind;
    private Text _rank;
    private Text _level;
    private Text _humanAtkPower;
    private Text _humanAtkSpeed;
    private Text _humanAtkRange;
    private Text _humanMoveSpeed;

    private Text _machineAtkPower;
    private Text _machineAtkSpeed;
    private Text _machineAtkRange;
    private Text _machineMoveSpeed;

    private Text _magicAtkPower;
    private Text _magicAtkSpeed;
    private Text _magicAtkRange;
    private Text _magicMoveSpeed;

    private Text _cost;


    void Awake()
    {
        _image = GetImage("Img_Image");
        _name = GetText("Txt_Name");
        _kind = GetText("Txt_Kind");
        _rank = GetText("Txt_Rank");
        _level = GetText("Txt_Level");
        _cost = GetText("Txt_Cost");

        _humanAtkPower = GetText("Txt_HumanAtkPower");
        _humanAtkSpeed = GetText("Txt_HumanAtkSpeed");
        _humanAtkRange = GetText("Txt_HumanAtkRange");
        _humanMoveSpeed = GetText("Txt_HumanMoveSpeed");

        _machineAtkPower = GetText("Txt_MachineAtkPower");
        _machineAtkSpeed = GetText("Txt_MachineAtkSpeed");
        _machineAtkRange = GetText("Txt_MachineAtkRange");
        _machineMoveSpeed = GetText("Txt_MachineMoveSpeed");

        _magicAtkPower = GetText("Txt_MagicAtkPower");
        _magicAtkSpeed = GetText("Txt_MagicAtkSpeed");
        _magicAtkRange = GetText("Txt_MagicAtkRange");
        _magicMoveSpeed = GetText("Txt_MagicMoveSpeed");

    }

    public void SetUIData(int index)
    {
        if (index ==0)
        {
            _image.sprite = null;

            Text[] text = GetComponentsInChildren<Text>();

            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = null;
            }
            return;
        }

        int itemIndex = (index-1) / 10;
        Utility.i.TextBuilder.Length = 0;
        Utility.i.TextBuilder.Append(Utility.ImagePath);
        Utility.i.TextBuilder.Append(Utility.ImageName + itemIndex);

        var table = TableManager.i.GetTable<ItemData>(index);

        _image.sprite = Resources.Load<Sprite>(Utility.i.TextBuilder.ToString());
        _name.text = Utility.Name + table.Name;
        _kind.text = Utility.Kind + table.Kind;
        _rank.text = Utility.Rank + table.Rank;
        _level.text = Utility.Level + table.Level;
        _cost.text = Utility.Cost + table.Cost.ToString();


        if (table.HumanAtkPower == 0)
        {
            _humanAtkPower.gameObject.SetActive(false);
        }
        else
        {
            _humanAtkPower.text = "인간속성 공격력 " + (table.HumanAtkPower * 100).ToString() + "% 증가";
            _humanAtkPower.gameObject.SetActive(true);
        }

        if (table.HumanAtkSpeed == 0)
            _humanAtkSpeed.gameObject.SetActive(false);
        else
        {
            _humanAtkSpeed.text = "인간속성 공격속도 " + (table.HumanAtkSpeed * 100).ToString() + "% 증가";
            _humanAtkSpeed.gameObject.SetActive(true);
        }

        if (table.HumanAtkRange == 0)
            _humanAtkRange.gameObject.SetActive(false);
        else
        {
            _humanAtkRange.text = "인간속성 공격사거리 " + (table.HumanAtkRange * 100).ToString() + "% 증가";
            _humanAtkRange.gameObject.SetActive(true);
        }

        if (table.HumanMoveSpeed == 0)
            _humanMoveSpeed.gameObject.SetActive(false);
        else
        {
            _humanMoveSpeed.text = "인간속성 이동속도 " + (table.HumanMoveSpeed * 100).ToString() + "% 증가";
            _humanMoveSpeed.gameObject.SetActive(true);
        }

        if (table.MachineAtkPower == 0)
            _machineAtkPower.gameObject.SetActive(false);
        else
        {
            _machineAtkPower.text = "기계속성 공격력 " + (table.MachineAtkPower * 100).ToString() + "% 증가";
            _machineAtkPower.gameObject.SetActive(true);
        }

        if (table.MachineAtkSpeed == 0)
            _machineAtkSpeed.gameObject.SetActive(false);
        else
        {
            _machineAtkSpeed.text = "기계속성 공격속도 " + (table.MachineAtkSpeed * 100).ToString() + "% 증가";
            _machineAtkSpeed.gameObject.SetActive(true);
        }

        if (table.MachineAtkRange == 0)
            _machineAtkRange.gameObject.SetActive(false);
        else
        {
            _machineAtkRange.text = "기계속성 공격사거리 " + (table.MachineAtkRange * 100).ToString() + "% 증가";
            _machineAtkRange.gameObject.SetActive(true);
        }

        if (table.MachineMoveSpeed == 0)
            _machineMoveSpeed.gameObject.SetActive(false);
        else
        {
            _machineMoveSpeed.text = "기계속성 이동속도 " + (table.MachineMoveSpeed * 100).ToString() + "% 증가";
            _machineMoveSpeed.gameObject.SetActive(true);
        }

        if (table.MagicAtkPower == 0)
            _magicAtkPower.gameObject.SetActive(false);
        else
        {
            _magicAtkPower.text = "마법속성 공격력 " + (table.MagicAtkPower * 100).ToString() + "% 증가";
            _magicAtkPower.gameObject.SetActive(true);
        }

        if (table.MagicAtkSpeed == 0)
            _magicAtkSpeed.gameObject.SetActive(false);
        else
        {
            _magicAtkSpeed.text = "마법속성 공격속도 " + (table.MagicAtkSpeed * 100).ToString() + "% 증가";
            _magicAtkSpeed.gameObject.SetActive(true);
        }

        if (table.MagicAtkRange == 0)
            _magicAtkRange.gameObject.SetActive(false);
        else
        {
            _magicAtkRange.text = "마법속성 공격사거리 " + (table.MagicAtkRange * 100).ToString() + "% 증가";
            _magicAtkRange.gameObject.SetActive(true);
        }

        if (table.MagicMoveSpeed == 0)
            _magicMoveSpeed.gameObject.SetActive(false);
        else
        {
            _magicMoveSpeed.text = "마법속성 이동속도 " + (table.MagicMoveSpeed * 100).ToString() + "% 증가";
            _magicMoveSpeed.gameObject.SetActive(true);
        }
    }
}
