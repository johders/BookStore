using BookStore.Core.Interfaces;
using BookStore.Mobile.Services;
using Microsoft.Extensions.Logging;
using Refit;

namespace BookStore.Mobile
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			builder.Services.AddTransient<IBookService, ApiBookService>()
				.AddSingleton<ICommonService, CommonService>();


			ConfigureRefit(builder.Services);

			return builder.Build();
		}

		private static void ConfigureRefit(IServiceCollection services)
		{
			var refitSettings = new RefitSettings
			{
				HttpMessageHandlerFactory = () =>
				{
#if ANDROID
					return new Xamarin.Android.Net.AndroidMessageHandler
					{
						ServerCertificateCustomValidationCallback = 
						(httpRequestMessage, certificate, chain, sslPolicyErrors) =>

						certificate?.Issuer == "CN=localhost" 
						|| sslPolicyErrors == System.Net.Security.SslPolicyErrors.None
					};
#elif IOS
					return new NSUrlSessionHandler
					{
						TrustOverrideForUrl = (nSUrlSessionHandler, url, secTrust) =>
						url.StartsWith("https://localhost")
					};
					
#endif
					return null;
				}
			};

			services.AddRefitClient<IBookApi>(refitSettings)
				.ConfigureHttpClient(httpClient =>
				{
					string baseUrl = null;
					
					if(DeviceInfo.DeviceType == DeviceType.Physical)
					{
						baseUrl = "https://8dd3m73x-7038.euw.devtunnels.ms/";
						//devtunnel url on physical device
                    }
					else
					{
						//emulator
						baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7038" : "https://localhost:7038";
					}
					httpClient.BaseAddress = new Uri(baseUrl);
                });
		}
	}
}
