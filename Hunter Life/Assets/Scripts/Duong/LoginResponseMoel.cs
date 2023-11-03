using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginResponseMoel 
{
    public LoginResponseMoel(bool status, string message, string id, string coin, string positionX, string positionY, string positionZ)
    {
        this.status = status;
        this.message = message;
        this.id = id;
        this.coin = coin;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }

    public bool status { get; set; }
    public string message { get; set; }
    public string id { get; set; }
    public string coin { get; set; }
    public string positionX { get; set; }
    public string positionY { get; set; }
    public string positionZ { get; set; }
}
