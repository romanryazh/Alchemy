using System.Reflection;

namespace Alchemy.Application;

public class ApplicationAssemblyReference
{
    public static Assembly Assembly => typeof(ApplicationAssemblyReference).Assembly;
}