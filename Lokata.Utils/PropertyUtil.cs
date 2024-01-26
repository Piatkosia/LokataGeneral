using Lokata.Domain;
using System.Reflection;
namespace Lokata.Utils
{
    public static class PropertyUtil
    {
        public static TargetType CopyProperties<TargetType, SourceType>(this TargetType targetObject, SourceType sourceObject)
            where TargetType : class
        {
            foreach (var property in typeof(TargetType).GetProperties().Where(p => p.CanWrite))
            {
                bool CheckIfPropertyExistInSource(PropertyInfo prop) =>
                    string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType == property.PropertyType;

                if (sourceObject.GetType().GetProperties().Any(CheckIfPropertyExistInSource))
                {
                    property.SetValue(targetObject, sourceObject.GetPropertyValue(property.Name), null);
                }
            }
            return targetObject;
        }
        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName)?.GetValue(source, null);
        }

        public static BaseTable InitializeBaseDatatable<BaseTable>(this BaseTable tableObject, string creator = "DBAdmin") where BaseTable : EntityBase
        {
            tableObject.IsDeleted = false;
            tableObject.CreatedOn = DateTime.Now;
            tableObject.ModifiedOn = DateTime.Now;
            tableObject.CreatedBy = creator;
            tableObject.ModifiedBy = creator;
            return tableObject;
        }

        public async static Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async static Task<T> HandleRequest<T>(this Task<T> serviceMethod) where T : class
        {
            try
            {
                return await serviceMethod;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
