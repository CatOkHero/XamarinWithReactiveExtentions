using System.Linq;
using Realms;

namespace SocialMedia.XamarinForms.DbAccess.Repository
{
	public interface IRepository
	{
		T Get<T>(string primaryKey)
			where T : RealmObject;

		IQueryable<T> GetAll<T>()
			where T : RealmObject;

		void Save<T>(T @object)
			where T : RealmObject;
	}
}
