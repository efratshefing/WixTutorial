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
            session.Log("Efrat### Begin CustomAction1");

            // Validate AccountKey
            //string accountKey = session["ACCOUNTKEY"];
            //if (string.IsNullOrEmpty(accountKey))
            //{
            //    Record record = new Record();
            //    record.FormatString = "AccountKey is required.";
            //    session.Message(InstallMessage.Error | (InstallMessage)MessageIcon.Error | (InstallMessage)MessageButtons.OK, record);
            //    session.Log("Efrat## AccountKey is required.");
            //    return ActionResult.Failure;
            //}

            // Validate DeviceType
            string deviceType = session["DEVICETYPE"];
            HashSet<string> validDeviceTypes = new HashSet<string> { "Type1", "Type2", "Type3" };
            if (!validDeviceTypes.Contains(deviceType))
            {
                Record record = new Record();
                record.FormatString = $"Invalid DeviceType: {deviceType}";
                session.Message(InstallMessage.Error | (InstallMessage)MessageIcon.Error | (InstallMessage)MessageButtons.OK, record);
                session.Log($"Efrat## Invalid DeviceType: {deviceType}");
                return ActionResult.Failure;
            }

            session.Log($"Efrat### Valid DeviceType: {deviceType}");

            // Validate ServiceUrl
            string serviceUrl = session["SERVICEURL"];
            if (!IsValidUrl(serviceUrl))
            {
                Record record = new Record();
                record.FormatString = $"Invalid ServiceUrl: {serviceUrl}";
                session.Message(InstallMessage.Error | (InstallMessage)MessageIcon.Error | (InstallMessage)MessageButtons.OK, record);
                session.Log($"Efrat## Invalid ServiceUrl: {serviceUrl}");
                return ActionResult.Failure;
            }

            session.Log($"Efrat### Valid ServiceUrl: {serviceUrl}");


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

