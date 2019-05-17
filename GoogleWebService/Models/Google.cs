using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace GoogleWebService.Models
{
    /// <summary>
    /// The certificate needs to be downloaded from the APIs Console
    /// <see cref="https://code.google.com/apis/console/#:access"/>:
    ///   "Create another client ID..." -> "Service Account" -> Download the certificate as "key.p12" and replace the
    ///   placeholder.
    /// The schema provided here can be applied to every request requiring authentication.
    /// <see cref="https://developers.google.com/accounts/docs/OAuth2#serviceaccount"/> for more information.
    /// </summary>
    public class GoogleClass
    {
        private String keyPath = "~/App_Data/GoogleApi.json";

        public IList<IList<Object>> GetTriData()
        {
            String trisheetId = "1y-350qe66s0iYSPWqx1F7bRhUnto_9iYlPt6GEaEY9k";
            String trirange = "Sheet1!A3:Q";
            return GetData(trisheetId, trirange);
        }

        public IList<IList<Object>> GetBeerData()
        {
            String beersheetId = "1lytEf1Rf7uhFC_ADg3iaeF1nyadjd0PXwvQE1Qd5HYI";
            String beerrange = "England!A1:L48";
            return GetData(beersheetId, beerrange);
        }

        private IList<IList<object>> GetData(string sheetId, string range)
        {
            GoogleCredential credential;

            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(keyPath)))
            {
                string json = sr.ReadToEnd();
                credential = GoogleCredential.FromJson(json).CreateScoped(new[] { SheetsService.Scope.SpreadsheetsReadonly });
            }

            return ProcessSheet(credential, sheetId, range);
        }

        private IList<IList<Object>> ProcessSheet(GoogleCredential credential, string sheetId, string range)
        {
            var service = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential });

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(sheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            return values;
        }

    }

}