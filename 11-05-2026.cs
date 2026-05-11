using System.Xml.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "movie.xml");

            /* - Класс должен иметь конструктор без параметров
             * - Класс должен быть публичным
             * - В классе все свойства должны быть с публичными get и set */

            // Оригинальный объект -> ДТО объект -> отдать его в сериализатор

            Movie movie1 = new Movie("Ironman", 150);
            movie1.Add(5); movie1.Add(3); movie1.Add(4); movie1.Add(5);

            MovieDTO movie1DTO = new MovieDTO(movie1);

            var serializer = new XmlSerializer(typeof(MovieDTO));
             
            using (var writer = new StreamWriter(filePath)) 
            {
                serializer.Serialize(writer, movie1DTO);
            }

            // Десериализуем объект из файла -> получаем ДТО объект->оригинальный объект
            MovieDTO movieDTO2;
            using (var reader = new StreamReader(filePath))
            {
                movieDTO2 = (MovieDTO)serializer.Deserialize(reader);
            }
            
            Movie movie2 = movieDTO2.CreateMovie();

            if (CompareMovies(movie1, movie2)) 
                Console.WriteLine("Succes");
            else Console.WriteLine("Something's wrong");
        }
        private static bool CompareMovies(Movie m1, Movie m2)
        {
            if (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Rating.Length != m2.Rating.Length) return false;
            for(int i = 0; i < m1.Rating.Length; i++)
            {
                if (m1.Rating[i] != m2.Rating[i]) return false;
            }
            return true;
        }
    }
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _rating;
        public string Name => _name;
        public int Duration => _duration;
        public int[] Rating => _rating.ToArray();

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _rating = new int[0];
        }
        public void Add(int stars)
        {
            Array.Resize(ref _rating, _rating.Length + 1);
            _rating[^1] = stars;
        }
    }
    public class MovieDTO
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int[] Rating { get; set; }
        public MovieDTO() { }
        public MovieDTO(string name, int duration, int[] rating)
        {
            Name = name;
            Duration = duration;
            Rating = rating;
        }
        public MovieDTO(Movie movie)
        {
            Name = movie.Name;
            Duration = movie.Duration;
            Rating = movie.Rating;
        }
        public Movie CreateMovie()
        {
            Movie movie = new Movie(Name, Duration);
            for (int i = 0; i < Rating.Length; i++)
            {
                movie.Add(Rating[i]);
            }
            return movie;
        }
    }
}
