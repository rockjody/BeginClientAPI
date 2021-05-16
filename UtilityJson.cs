using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace TIC.ClientAPI
{
    public class UtilityJson
    {
        /// <summary>
        /// Json syntax string - Show break lines in nested indend format
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }


        /// <summary>
        /// Serialize object to a nested indend format string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string JsonSerialPretty(object o)
        {
            try
            {
                //one step
                //return JsonPrettify(JsonConvert.SerializeObject(o));

                //debug trac
                var serial = JsonConvert.SerializeObject(o);
                var pretty = JsonPrettify(serial);
                return pretty;
            }
            catch (Exception)
            {
                throw;
            }
            //return "";
        }

        public static string Samples_JsonDiv(string headlineText, object o)
        {
            try
            {
                //Outer Div
                var dynDiv = new HtmlGenericControl("div");
                dynDiv.Attributes["class"] = "content-wrapper main-content clear-fix ";
                //
                var dynH4 = new HtmlGenericControl("h4");
                dynH4.Attributes["class"] = "sample-header ";
                //get name of object ?? How
                Type objectType = o.GetType();
                dynH4.InnerText = string.Format("{0}, json", objectType.ToString().Replace("TimeLib.", "")); //headlineText);
                // -OR- use hard parameter -- its the other 
                //dynH4.InnerText = string.Format("{0}/json, text/json", headlineText.ToString());
                dynDiv.Controls.Add(dynH4);                     //Add to outer Div

                var dynDivCont = new HtmlGenericControl("div");
                dynDivCont.Attributes["class"] = "sample-content ";
                dynDiv.Controls.Add(dynDivCont);                     //Add to outer Div

                var dynSpan = new HtmlGenericControl("span");
                var dynSpanB = new HtmlGenericControl("b");
                dynSpanB.InnerText = "Sample:";
                dynSpan.Controls.Add(dynSpanB);
                dynDivCont.Controls.Add(dynSpan);                     //Add to inner Div

                var dynPre = new HtmlGenericControl("pre");
                dynPre.Attributes["class"] = "wrapped ";
                dynPre.InnerText = JsonSerialPretty(o);
                dynDivCont.Controls.Add(dynPre);                     //Add to inner Div

                // Reference: https://stackoverflow.com/questions/16442497/how-to-get-generated-html-form-htmlgenericcontrol
                // finally, get the html when its ready
                string showguts = "";
                StringBuilder generatedHtml = new StringBuilder();
                using (var htmlStringWriter = new StringWriter(generatedHtml))
                {
                    using (var htmlTextWriter = new HtmlTextWriter(htmlStringWriter))
                    {
                        dynDiv.RenderControl(htmlTextWriter);
                        showguts = generatedHtml.ToString();
                    }
                }

                return showguts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}