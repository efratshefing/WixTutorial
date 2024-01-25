using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WixToolset.Dtf.WindowsInstaller;

namespace WixValidation
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            session.Log("Efrat## Begin CustomAction1");


            // Validate AccountKey
            string accountKey = session["ACCOUNTKEY"];
            if (string.IsNullOrEmpty(accountKey))
            {
                session.Log("Efrat## AccountKey is required.");
                return ActionResult.Failure;
            }

            // Validate DeviceType
            string deviceType = session["DEVICETYPE"];
            HashSet<string> validDeviceTypes = new HashSet<string> { "Type1", "Type2", "Type3" };
            if (!validDeviceTypes.Contains(deviceType))
            {
                session.Log($"Efrat## Invalid DeviceType: {deviceType}");
                return ActionResult.Failure;
            }
          
            // Validate ServiceUrl
            string serviceUrl = session["SERVICEURL"];
            if (!IsValidUrl(serviceUrl))
            {
                session.Log($"Efrat## Invalid ServiceUrl: {serviceUrl}");
                return ActionResult.Failure;
            }

            return ActionResult.Success;
             }

            private static bool IsValidUrl(string url)
            {
                // Simple regex for checking if it starts with http:// or https://
                Regex urlRegex = new Regex("^https?://.*");
                return urlRegex.IsMatch(url);
            }
    }

    }

