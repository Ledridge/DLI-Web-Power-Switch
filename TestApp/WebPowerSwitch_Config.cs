using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace StageSoft.WebPowerSwitch
{
    [Serializable]
    public class WebPowerSwitch_Config : ISerializable
    {
        public WebPowerSwitch_Config()
        {

        }

        public WebPowerSwitch_Config(string strIpAddress, string strLogin, string strPassword)
        {
            IpAddress = strIpAddress;
            Login = strLogin;
            Password = strPassword;
        }

        [System.ComponentModel.Category("Device")]
        [System.ComponentModel.DisplayName("IP address")]
        [System.ComponentModel.Description("IP address of the Web Power Switch device")]
        public string IpAddress { get; set; }

        [System.ComponentModel.Category("User")]
        [System.ComponentModel.Description("User login")]
        public string Login { get; set; }
        
        [System.ComponentModel.Category("User")]
        [System.ComponentModel.Description("User password")]
        [System.ComponentModel.PasswordPropertyText(true)]
        public string Password { get; set; }

        #region ISerializable Members

        public WebPowerSwitch_Config(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            IpAddress = (string)info.GetValue("IpAddress", typeof(string));
            Login = (string)info.GetValue("Login", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
        }

        void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IpAddress", IpAddress);
            info.AddValue("Login", Login);
            info.AddValue("Password", Password);
        }

        #endregion

    }
}
