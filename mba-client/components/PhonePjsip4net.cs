using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pjsip4net.Configuration;
using pjsip4net.Core.Configuration;

namespace mba_client.components
{
    class PhonePjsip4net
    {
        public PhonePjsip4net()
        { 
            var cfg = Configure.Pjsip4Net().FromConfig();//read configuration from .config file 
            var ua = cfg.Build().Start();//build and start
        }
        //private static ISoftPhone softphone;   // softphone object
        //private static IPhoneLine phoneLine;   // phoneline object
        //public PhonePjsip4net()
        //{ 
        //    // Create a softphone object with RTP port range 5000-10000
        //    softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000);

        //        // SIP account registration data, (supplied by your VoIP service provider)
        //        var registrationRequired = true;
        //    var userName = "151";
        //    var displayName = "IvanTest";
        //    var authenticationId = "151";
        //    var registerPassword = "heslox151";
        //    var domainHost = "aster.mbaru.ru";
        //    var domainPort = 5060;

        //    var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);

        //        // Send SIP regitration request
        //        RegisterAccount(account);
        //}
        //static void RegisterAccount(SIPAccount account)
        //{
        //    try
        //    {
        //        phoneLine = softphone.CreatePhoneLine(account);
        //        phoneLine.RegistrationStateChanged += sipAccount_RegStateChanged;
        //        softphone.RegisterPhoneLine(phoneLine);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error during SIP registration: " + ex);
        //    }
        //}

        //static void sipAccount_RegStateChanged(object sender, RegistrationStateChangedArgs e)
        //{
        //    if (e.State == RegState.Error || e.State == RegState.NotRegistered)
        //        Console.WriteLine("Registration failed!");

        //    if (e.State == RegState.RegistrationSucceeded)
        //        Console.WriteLine("Registration succeeded - Online!");
        //}
    }
}
