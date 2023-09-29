namespace ToDoListDomain.Enum;

public enum StatusCode
{
    TaskIsHasAlready = 1, //завдання вже існує
    OK = 200,//ок
    InternalServerError = 500, //помилка на сервері
}