namespace ToDoListDomain.Enum;

public enum StatusCode
{
    TaskIsHasAlready = 1, //завдання вже існує
    TaskNotFound = 2,
    OK = 200,//ок
    InternalServerError = 500, //помилка на сервері
}