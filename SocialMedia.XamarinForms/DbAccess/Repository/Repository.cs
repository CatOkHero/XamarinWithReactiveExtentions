using Realms;
using System;
using System.Linq;

namespace SocialMedia.XamarinForms.DbAccess.Repository
{
	public class Repository : IRepository
	{
		private Realm realm;

		public Repository()
		{
			realm = Realm.GetInstance();
		}

		public T Get<T>(string primaryKey)
			where T : RealmObject
		{
			using (realm)
			{
				return realm.Find<T>(primaryKey);
			}
		}

		public IQueryable<T> GetAll<T>()
			where T : RealmObject
		{
			return realm.All<T>();
		}
	}
}
