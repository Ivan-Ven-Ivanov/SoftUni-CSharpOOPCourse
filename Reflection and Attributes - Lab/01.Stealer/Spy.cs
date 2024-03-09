using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            result.AppendLine($"Class under investigation: {classType.FullName}");

            FieldInfo[] fields = classType.GetFields((BindingFlags)60);
            object instance = Activator.CreateInstance(classType, new object[] { });

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return result.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);



            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (FieldInfo field in fieldInfos)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo method in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            result.AppendLine($"All Private Methods of Class: {classType.FullName}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in privateMethods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] getters = classType.GetMethods((BindingFlags)60)
                .Where(m => m.Name.StartsWith("get"))
                .ToArray();

            MethodInfo[] setters = classType.GetMethods((BindingFlags)60)
                .Where(m => m.Name.StartsWith("set"))
                .ToArray();

            foreach (MethodInfo getter in getters)
            {
                result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (MethodInfo setter in setters)
            {
                result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
