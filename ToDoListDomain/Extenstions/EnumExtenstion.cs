using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ToDoListDomain.Extenstions;

public static class EnumExtenstion
{
    //TODO #24 Створили розширяючий метод який буде повертати значення [Display] "Enum" але він може не працювати тому треба перевірити додатково
    public static string GetDisplayName(this System.Enum enumValue)
    {//чомусь не працює цей код
        /*return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttributes<DisplayAttribute>()
        ?.GetName() ?? "Невизначений";*/
       
        
        var displayAttribute = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;
        return displayAttribute ?.GetName() ?? "Невизначений";
    }
}