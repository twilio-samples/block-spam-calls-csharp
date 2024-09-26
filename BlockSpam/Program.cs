using Twilio.TwiML;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

    const int NomoroboSpamScore = 1;
    const string SuccessfulStatus = "successful";


app.MapPost("/voice", ([FromForm] VoiceRequest request, string addOns) => 
{

   	var response = new VoiceResponse();
	var isCallBlocked = false;

	if (!string.IsNullOrWhiteSpace(addOns))
        {
        Trace.WriteLine(addOns);

        var addOnData = JObject.Parse(addOns);
        if (addOnData["status"]?.ToString() == "successful")
            	{
                isCallBlocked = IsBlockedByNomorobo(addOnData["results"]?["nomorobo_spamscore"])
                            || IsBlockedByMarchex(addOnData["results"]?["marchex_cleancall"]);
                }
            }

            if (isCallBlocked)
            {
                response.Reject();
            }
            else
            {
                response.Say("Ahoy! You've been determined not spam.");
                response.Hangup();
            }

   return Results.Extensions.TwiML(response);
}).DisableAntiforgery();

static bool IsBlockedByNomorobo(JToken nomorobo)
        {
            if (nomorobo?["status"]?.Value<string>() != SuccessfulStatus) return false;

            var score = nomorobo["result"]?["score"]?.Value<int>();
            return score == NomoroboSpamScore;
        }


static bool IsBlockedByMarchex(JToken marchex)
        {
            if (marchex?["status"]?.Value<string>() != SuccessfulStatus) return false;

            var recommendation = marchex["result"]?["result"]?["recommendation"]?.Value<string>();
            return recommendation == "BLOCK";
        }

app.Run();
