using Realms;
using System;

namespace SocialMedia.XamarinForms.DbAccess.DbModels
{
	public class UserDbModel : RealmObject
	{
		[PrimaryKey]
		public Guid Id { get; set; }

		public string UserName { get; set; }
		public byte[] ImageBytes { get; set; }
	}
}
