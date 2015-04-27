using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace StageSoft.WebPowerSwitch
{
    public class WebPowerSwitch_Device
    {
        private bool[] _blnStatus;
        private string[] _strName;

        public WebPowerSwitch_Device()
        {
            _blnStatus = new bool[9];
            _strName = new string[9];

            SetAllowUnsafeHeaderParsing20();
        }

        private WebPowerSwitch_Config _objConfig;
        /// <summary>
        /// Gets/Sets the current configuration of the device.  
        /// </summary>
        public WebPowerSwitch_Config Configuration
        {
            get { return _objConfig; }
            set
            {
                if (_objConfig != value)
                {
                    _objConfig = value;
                    WebRequest = CreateWebRequest();
                }
            }
        }

        /// <summary>
        /// Event raised when the device responds to a status request
        /// </summary>
        public event EventHandler StatusChanged;
        private void OnStatusChanged()
        {
            if (StatusChanged != null)
            {
                StatusChanged(this, EventArgs.Empty);
            }
        }

        private System.Net.WebClient _objWebRequest;
        private System.Net.WebClient WebRequest
        {
            get { return _objWebRequest; }
            set
            {
                if (_objWebRequest != value)
                {
                    if (_objWebRequest != null)
                    {
                        _objWebRequest.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(_objWebRequest_DownloadStringCompleted);
                    }

                    _objWebRequest = value;

                    if (_objWebRequest != null)
                    {
                        _objWebRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(_objWebRequest_DownloadStringCompleted);
                    }
                }
            }
        }

        private System.Net.WebClient CreateWebRequest()
        {
            System.Net.WebClient objRet = new WebClient();

            string strLoginPassword = string.Format("{0}:{1}", _objConfig.Login, _objConfig.Password);
            byte[] bytLoginPassword = System.Text.Encoding.UTF8.GetBytes(strLoginPassword);
            string strLoginPasswordEncoded = Convert.ToBase64String(bytLoginPassword);

            objRet.Headers.Add(string.Format("Authorization: Basic {0}", strLoginPasswordEncoded));
            return objRet;
        }

        public void StartScript(int intScriptLine)
        {
            string strUri = string.Format("{0}script?run{1:000}", DeviceUri, intScriptLine);
            WebRequest.DownloadStringAsync(new Uri(strUri), null);
        }

        private void _objWebRequest_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    if (e.UserState != null)
                    {
                        if (e.UserState.ToString() == "RefreshStatus")
                        {
                            RefreshStatus_Response(e.Result);
                        }
                    }
                }
            }
        }

        private string DeviceUri
        {
            get
            {
                string strRet;
                strRet = string.Format(@"http://{0}/", _objConfig.IpAddress);
                return strRet;
            }
        }

        /// <summary>
        /// http://social.msdn.microsoft.com/forums/en-US/netfxnetcom/thread/ff098248-551c-4da9-8ba5-358a9f8ccc57/
        /// Allows talking to servers that only terminate with CR instead of the standard CRLF
        /// </summary>
        /// <returns></returns>
        public static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            System.Reflection.Assembly aNetAssembly = System.Reflection.Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        System.Reflection.FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the current state of a relay.  True = on, False = off
        /// </summary>
        /// <param name="intRelay"></param>
        /// <returns></returns>
        public bool Status(int intRelay)
        {
            return _blnStatus[intRelay];
        }

        /// <summary>
        /// Toggle the current state of a relay
        /// </summary>
        /// <param name="intRelay"></param>
        internal void Relay_Toggle(int intRelay)
        {
            Relay_Set(intRelay, !_blnStatus[intRelay]);
        }

        /// <summary>
        /// Set the state of a relay
        /// </summary>
        /// <param name="intRelay"></param>
        /// <param name="blnState"></param>
        public void Relay_Set(int intRelay, bool blnState)
        {
            string strOnOff = BoolToText(blnState).ToUpper();

            string strAddress = string.Format("{0}outlet?{1}={2}", DeviceUri, intRelay, strOnOff);

            WebRequest.DownloadStringAsync(new Uri(strAddress), "Relay_Set");

            _blnStatus[intRelay] = blnState;
            OnStatusChanged();
        }

        /// <summary>
        /// Turn all relays on or off.  Note: the device may sequence the relays depending on other settings.
        /// </summary>
        /// <param name="blnState"></param>
        public void Relay_SetAll(bool blnState)
        {
            string strOnOff = BoolToText(blnState).ToUpper();

            string strAddress = string.Format("{0}outlet?a={1}", DeviceUri, strOnOff);

            WebRequest.DownloadStringAsync(new Uri(strAddress), "Relay_SetAll");

            for (int i = 1; i <= 8; i++)
            {
                _blnStatus[i] = blnState;
            }
            OnStatusChanged();
        }

        public string BoolToText(bool blnStatus)
        {
            string strRet;
            if (blnStatus)
            {
                strRet = "On";
            }
            else
            {
                strRet = "Off";
            }
            return strRet;
        }

        private bool TextToBool(string strState)
        {
            bool blnRet = false;
            if (strState.ToUpper() == "ON")
            {
                blnRet = true;
            }
            return blnRet;
        }

        /// <summary>
        /// Ask the device to send the current status.
        /// </summary>
        public void RefreshStatus()
        {
            string strUriIndex = string.Format("{0}index.htm", DeviceUri);

            WebRequest.DownloadStringAsync(new Uri(strUriIndex), "RefreshStatus");
        }

        /// <summary>
        /// Parse device response to extract names and states
        /// </summary>
        /// <param name="strResponse"></param>
        private void RefreshStatus_Response(string strResponse)
        {
            ControllerName = ParseControllerName(strResponse);

            for (int i = 1; i <= 8; i++)
            {
                _blnStatus[i] = ParseRelayState(strResponse, i);
                _strName[i] = ParseRelayName(strResponse, i);
            }

            OnStatusChanged();
        }

        /// <summary>
        /// Get the controller name
        /// </summary>
        /// <param name="strResponse"></param>
        /// <returns></returns>
        private string ParseControllerName(string strResponse)
        {
            string strRet = "Web Power Switch";

            string strFind = "Controller: ";
            int intStart = strResponse.IndexOf(strFind);
            if (intStart > 0)
            {
                intStart = intStart + strFind.Length;
                int intStop = strResponse.IndexOf("\r\n", intStart);
                if (intStop > 0)
                {
                    strRet = strResponse.Substring(intStart, intStop - intStart);
                    strRet = strRet.Trim();
                }
            }

            return strRet;
        }

        /// <summary>
        /// Get the specified relay state
        /// </summary>
        /// <param name="strResponse"></param>
        /// <param name="intRelay"></param>
        /// <returns></returns>
        private bool ParseRelayState(string strResponse, int intRelay)
        {
            bool blnRet = false;

            string strFind = string.Format("href=outlet?{0}=O", intRelay);
            int intStart = strResponse.IndexOf(strFind);
            if (intStart > 0)
            {
                string strValue = strResponse.Substring(intStart + strFind.Length - 1, 2);

                blnRet = TextToBool(strValue);
                //The link shows the opposite of the current state
                blnRet = !blnRet;
            }

            return blnRet;
        }

        /// <summary>
        /// Get the specified relay name
        /// </summary>
        /// <param name="strResponse"></param>
        /// <param name="intRelay"></param>
        /// <returns></returns>
        private string ParseRelayName(string strResponse, int intRelay)
        {
            string strRet = string.Format("Switch {0}", intRelay);

            string strFind = string.Format("<td align=center>{0}</td>", intRelay);
            int intStart = strResponse.IndexOf(strFind);
            if (intStart > 0)
            {
                intStart += strFind.Length;

                strFind = "<td>";
                intStart = strResponse.IndexOf(strFind, intStart);
                intStart += strFind.Length;

                int intStop = strResponse.IndexOf("</td>", intStart);
                if (intStop > 0)
                {
                    strRet = strResponse.Substring(intStart, intStop - intStart);
                }
            }

            return strRet;
        }

        /// <summary>
        /// Get the name of the specified relay
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string RelayName(int i)
        {
            return _strName[i];
        }

        /// <summary>
        /// Get the controller name
        /// </summary>
        public string ControllerName { get; private set; }
    }
}
