// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;

string path = @"C:\Users\andre\OneDrive\Документы\kk\123123.txt";//путь до файла 
using (FileStream fs = File.OpenRead(path))//открываем файлстрим с нашим файлом 
{
    string[] tt = File.ReadAllLines(path);//тута крута все читается в массив
    foreach (var item in tt)//форыч читает каждую строку в массиве и создает поле с этой строкой
    {
        string[] ss = item.Split(",");//разделяем строку на массив со словами
        User user = new User() {//каждое слово записываем в переменную 
            name = ss[0],//чета
            surname = ss[1],//чета тоже
            login = ss[2]//еще чета
        };
        //_context.Users.Add(user);//нужно было бы добавитиь в бд 
        Console.WriteLine(user.name + " " + user.surname + " " + user.login);//вместо строки выше чекаем че там в юзере
    }
    fs.Close();// закрываем стрим
}
public partial class User//моделька юзера чтобы данные внести:)
{
    public int Id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string login { get; set; }
}