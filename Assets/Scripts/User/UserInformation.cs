using System.Collections;
using System.Collections.Generic;

public class UserInformation: Singleton<UserInformation>
{
    public Inventory Inventory = new Inventory();
    public Character Character = new Character();

}
