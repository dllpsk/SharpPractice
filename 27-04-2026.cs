using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _review;
        public string Name => _name;
        public int Duration => _duration;
        public int[] Review => _review.ToArray();

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _review = new int[0];
        }
        public void Add(int num)
        {
            Array.Resize(ref _review, _review.Length + 1);
            _review[_review.Length - 1] = num; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Harry Potter", 102);
            movie1.Add(5);
            movie1.Add(5);
            movie1.Add(4);

            var temp = new
            {
                MovieType = movie1.GetType().Name,
                movie1.Name,
                movie1.Duration,
                movie1.Review
            };

            Console.WriteLine(temp.Name);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "Test", "example.json");

            // сериализация
            string json = JsonConvert.SerializeObject(temp);
            File.WriteAllText(jsonFilePath, json);
            
            // десериализация
            string jsContent = File.ReadAllText(jsonFilePath);
            var newJson = JsonConvert.DeserializeObject<dynamic>(jsContent);

            Movie movie2 = new Movie((string)newJson.Name, (int)newJson.Duration);
            foreach (int n in newJson.Review)
            {
                movie2.Add((int)n);
            }
            Console.WriteLine(CompareMovies(movie1, movie2));
            

            // Получение путей к папкам

            // Абсолютный путь
            //
            // Относительный путь
            // "dataset/data.txt"

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "example.txt");

            string folderPath1 = Path.Combine(folderPath, "Test");
            string filePath1 = Path.Combine(folderPath1, "example.txt");

            string folderPath1Check = Path.GetDirectoryName(filePath1);
            string fileNameCheck = Path.GetFileName(filePath1);
            string fileExtCheck = Path.GetExtension(filePath1);

            if (!Directory.Exists(folderPath1))
            {
                Directory.CreateDirectory(folderPath1);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                //FileStream fs = File.Create(filePath);
                //fs.Close();
            }

            File.WriteAllText(filePath1, "Hey!");
            File.WriteAllLines(filePath1, new string[] { "So", "cold", "today" });
            // Записывает файл в строку.
            // Если файла не было - создает и записывает
            // Если файл был - перезаписывает содержимое

            File.WriteAllText(filePath1, "");
            File.AppendAllText(filePath1, "Wohoo");
            File.AppendAllLines(filePath1, new string[] { "No", "idea" });


            string content = File.ReadAllText(filePath1);
            string[] lines = File.ReadAllLines(filePath1);

            File.Delete(filePath);
        }
        private static bool CompareMovies(Movie m1, Movie m2)
        {
            if (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Review.Length != m2.Review.Length) return false;
            for (int i = 0; i < m1.Review.Length; i++)
            {
                if (m1.Review[i] != m2.Review[i]) return false;
            }
            return true;
        }
    }
}
