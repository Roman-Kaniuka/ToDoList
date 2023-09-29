using System.ComponentModel.DataAnnotations;

namespace ToDoListDomain.Enum;
//TODO: #2 Створили Enum для пріоритету завдань
public enum Priority

{ //для того щоб перечислення з Enum відображалися не анг а укр ми додаємо атрибут [Display]
    [Display (Name ="неважливі")]
    Easy = 1,
    [Display (Name ="менш важливі")]
    Medium = 2,
    [Display (Name ="важливі")]
    Hard = 3,
}