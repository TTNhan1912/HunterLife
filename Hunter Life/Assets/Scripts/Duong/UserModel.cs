using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserModel 
{
    public UserModel(string email, string password, string confirm_password)
    {
        this.email = email;
        this.password = password;
        this.confirm_password = confirm_password;
    }

    public UserModel(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public UserModel(string email)
    {
        this.email = email;
    }

    public UserModel(string email, string password, string confirm_password, string otp) : this(email, password, confirm_password)
    {
        this.otp = otp;
    }

    public string email {  get; set; }
    public string password { get; set; }
    public string confirm_password { get; set; }
    public string otp { get; set; }
    
}
