using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeginClientAPI
{
    public class ListenUp_YouGottaDo
    {
        // ToDo:
        // The DealerAccess controller copies some methods used in the timeAPI class.  I wanted to see the typical flow for the Authentifcation.
        // However, the TimeAPI is for communication with DEFI's API.  Therefore, a Post should be a Get?
        // Also, need to slim down the functionality to represent only the necessary tasks associated with OUR specific authentication.
        // The OnlineOrderingSystem project can be used to determine the activity that needs to take place in order to authenticate.  That project
        // is just written as an ASP.net project rather than an API.  It contains way more functionality than is needed here.
        // We don't need web forms. 
        // 
        // Here is the flow to be emulated:
        // Using the DBHelper class (from TimLib),
        // method: CheckUser(username, pw):
        // gets the "DealerIndicator" from App Settings.  comes from the querystring in the OOS. ("bin" = "instore" or "promo", gets token from QS; decrypts "token" using our
        // public key (which is static), and using Crypto class creates a token string using "UserToken"=crypto.encode(parms including public key).  There are 2 sprocs that can
        // be used are called from SQL comd, "usp_SEC_AuthenticationReportUser" and "usp_GetCRMIDForDealer".  
        // So the code I brought over from OOS won't really translate exactly since this is an API and not a WebForms app.

        // gets the "authGroup" from App Settings.  (should = something like, "EcollectData" or whatever).
        // if the username contains the dealer indicator, pull the username from the response object as well as the dealerID.
        // then validates user is in A/D, user is a Windows client.  Gets the "cPrinc" object collection
        // 
    }
}