using Newtonsoft.Json;
using SocialMedia.XamarinForms.Helpers;
using System.Collections.Generic;
using System.IO;

namespace SocialMedia.XamarinForms.DbAccess
{
	public static class MockDataService
	{
		public static IReadOnlyList<MockDataModel> GetData()
		{
			var mockDataFileName = Constants.MockDataFileName;
			var mockDataFileFolder = Constants.MockDataFileFolder;
			var assembly = typeof(MockDataService).Assembly;
			var filePath = $"{assembly.GetName().Name}.{mockDataFileFolder}.{mockDataFileName}";
			var fileStream = assembly.GetManifestResourceStream(filePath);
			var stringData = string.Empty;
			using (var stream = new StreamReader(fileStream))
			{
				stringData = stream.ReadToEnd();
			}

			var data = JsonConvert.DeserializeObject<IReadOnlyList<MockDataModel>>(stringData);
			return data;
		}
	}
}
