using Realms;
using System;

namespace SocialMedia.XamarinForms.DbAccess.DbModels
{
	public class UserDbModel : RealmObject
	{
		[PrimaryKey]
		public string Id { get; set; }

		public string UserName { get; set; }
        public string Password { get; set; }
		public byte[] ImageBytes { get; set; }
	}
}
