# block-spam-calls-csharp

<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>


## About

This app shows how to build a call forwarding system with voicemail using C# and Twilio.

How it works:

- Call is placed to your Twilio number
- Your app checks the time
- If the time is within the defined window, it will forward the call to another phone number
- If it is not in the defined time window, it will record a voicemail


## Set up

### Requirements

- [dotnet](https://dotnet.microsoft.com/)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)
- [ngrok](https://ngrok.com/)

### Setup

### Install Add-ons

This tutorial will require you to [install Add-ons](https://www.twilio.com/docs/marketplace/listings/usage). You can access the Add-ons in the Twilio console [here](https://www.twilio.com/console/add-ons)

The Spam Filtering Add-ons that are used on this application are:

- Marchex Clean Call
- Nomorobo Spam Score

Once you've selected the Add-on, click on the `Install` button. Then, you will see a pop-up window where you should read and agree the terms, then, click the button `Agree & Install`. For this application, you just need to handle the incoming voice calls, so make sure the `Incoming Voice Call` box for Use In is checked and click `Save`.

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
git clone git@github.com:twilio-samples/block-spam-calls-csharp
cd block-spam-calls-csharp

```

2. Add necessary nuget packages

```bash
dotnet add package Twilio
dotnet add package Twilio.AspNet.Core

```

3. Build to install the dependencies

```bash
dotnet build
```

4. Run the application

```bash
dotnet run
```

5. Use ngrok or other tunneling service to expose your application to the internet

You will need to use ngrok or another tunneling service to allow Twilio to reach your running application. Use the following command, replacing the port number that's shown here with the port that your application is running on.

```bash
ngrock http http://localhost:5183
```

7. Set your ngrok endpoint as a Webhook in the Twilio console. Remember to append /voice to the ngrok URL.

That's it!


## Resources

- The CodeExchange repository can be found [here](https://github.com/twilio-labs/code-exchange/).

## Contributing

This template is open source and welcomes contributions. All contributions are subject to our [Code of Conduct](https://github.com/twilio-labs/.github/blob/master/CODE_OF_CONDUCT.md).


## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
