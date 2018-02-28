using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsFlyerMMP : MonoBehaviour
{

    void Start()
    {
        // For detailed logging
        //AppsFlyer.setIsDebug (true);
#if UNITY_IOS
        //Mandatory - set your AppsFlyer’s Developer key.
        AppsFlyer.setAppsFlyerKey ("YOUR_APPSFLYER_DEV_KEY_HERE");
        //Mandatory - set your apple app ID
        //NOTE: You should enter the number only and not the "ID" prefix
        AppsFlyer.setAppID ("YOUR_APP_ID_HERE");
        AppsFlyer.trackAppLaunch ();
#elif UNITY_ANDROID
        //Mandatory - set your Android package name
        AppsFlyer.setAppID("com.Blast.RunFloor");
        //Mandatory - set your AppsFlyer’s Developer key.
        AppsFlyer.init("aTYJZVwsYCTz8BbnbrDbxL");

        AppsFlyer.setCustomerUserID("698123");

        

        //For getting the conversion data in Android, you need to this listener.
        //AppsFlyer.loadConversionData("AppsFlyerTrackerCallbacks");

#endif
    }


    public static void Score(int batch)
    {
        Debug.Log("Batch: " + batch);
        Dictionary<string, string> score = new Dictionary<string, string>();
        score.Add("af_score", batch.ToString());
        AppsFlyer.trackRichEvent("score_batch", score);
        Debug.Log("AppsFlyer Score Sent");
        //AppsFlyer.loadConversionData("AppsFlyerTrackerCallbacks");

        //To get the callbacks
        //AppsFlyer.createValidateInAppListener ("AppsFlyerTrackerCallbacks", "onInAppBillingSuccess", "onInAppBillingFailure");

    }


}
