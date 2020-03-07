using Realms;
using System.Linq;

namespace SocialMedia.XamarinForms.DbAccess.Repository
{
	public class Repository : IRepository
	{
		public T Get<T>(string primaryKey)
			where T : RealmObject
		{
            using (var realm = Realm.GetInstance())
            {
                return realm.Find<T>(primaryKey);
            }
        }

        public IQueryable<T> GetAll<T>()
            where T : RealmObject
        {
            using (var realm = Realm.GetInstance())
            {
                return realm.All<T>();
            }
        }

        public void Save<T>(T @object)
            where T : RealmObject
        {
            using (var realm = Realm.GetInstance())
            {
                realm.Write(() =>
                {
                    realm.Add(@object);
                });
            }
        }
	}
}
