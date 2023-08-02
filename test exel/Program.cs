// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;

List<User> users = new List<User>();
List<Photos> phs = new List<Photos>();
string path = @"C:\Users\andre\OneDrive\Документы\kk\cross table1.txt";//путь до файла 
using (FileStream fs = File.OpenRead(path))//открываем файлстрим с нашим файлом 
{
    string[] tt = File.ReadAllLines(path);//тута крута все читается в массив
    foreach (var item in tt)//форыч читает каждую строку в массиве и создает поле с этой строкой
    {
        string[] ss = item.Split(",");//разделяем строку на массив со словами
        User user = new User() {//каждое слово записываем в переменную 
            name = ss[0],//чета
            surname = ss[1],//чета тоже
           // login = ss[2]//еще чета
        };
        //_context.Users.Add(user);//нужно было бы добавитиь в бд 
        Console.WriteLine(user.name + " " + user.surname);//вместо строки выше чекаем че там в юзере
    }
    fs.Close();// закрываем стрим
}
string path2 = @"C:\Users\andre\OneDrive\Документы\kk\cross table.txt";//путь до файла 
string path3 = @"C:\Users\andre\OneDrive\Документы\kk\phs\";//путь до файла 
using (FileStream fs = File.OpenRead(path2))//открываем файлстрим с нашим файлом 
{
    string[] tt = File.ReadAllLines(path);//тута крута все читается в массив
    foreach (var item in tt)//форыч читает каждую строку в массиве и создает поле с этой строкой
    {
        string[] ss = item.Split(",");//разделяем строку на массив со словами
        byte[] photo = File.ReadAllBytes(path3 + ss[0]);
        Photos photoss = new Photos()
        {
            Photo = photo
        };
        //_context.Users.Add(photoss);//нужно было бы добавитиь в бд 
        Console.WriteLine(photoss.Photo);//вместо строки выше чекаем че там в юзере
    }
    //users = _context.Users.Get();
    //phs = _context.Users.Get();
    foreach (var item in tt)//форыч читает каждую строку в массиве и создает поле с этой строкой
    {
        string[] ss = item.Split(",");//разделяем строку на массив со словами
        User i = users.Find(s => s.Id.ToString() == ss[1]);
        CrossPhotos crossPhotos = new CrossPhotos()
        {
            phId = phs.Find(s => s.Id.ToString() == ss[1]).Id,
            userid = i.Id
        };
        Console.WriteLine(crossPhotos.phId + " " + crossPhotos.userid);
        //_context.Crossphotos.Add(crossPhotos);
    }
    fs.Close();// закрываем стрим
    
}

public partial class User//моделька юзера чтобы данные внести:)
{
    public int Id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    //public string login { get; set; }
}
public partial class Photos//моделька юзера чтобы данные внести:)
{
    public int Id { get; set; }
    public byte[] Photo { get; set; }
}
public partial class CrossPhotos
{
    public int id { get; set; }
    public int phId { get; set; }
    public int userid { get; set; }
}