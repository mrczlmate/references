using DAL6QM_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL6QM_HFT_2023241.Repository
{
    public class BookDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BookDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("book");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book => book
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Book>(book => book
                .HasOne(book => book.Publisher)
                .WithMany(publisher => publisher.Books)
                .HasForeignKey(book => book.PublisherId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Book>(book => book
                .HasOne(book => book.Category)
                .WithMany(category => category.Books)
                .HasForeignKey(book => book.CategoryId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author("1#J.K. Rowling"),
                new Author("2#Agatha Christie"),
                new Author("3#J.R.R. Tolkien"),
                new Author("4#Leo Tolstoy"),
                new Author("5#Gabrielle Zevin"),
                new Author("6#Stephen King"),
                new Author("7#Franz Kafka"),
                new Author("8#Mark Twain"),
                new Author("9#Daphne du Maurier"),
                new Author("10#Charles Dickens"),
                new Author("11#Dan Brown"),
                new Author("12#Isaac Asimov"),
                new Author("13#Johann David Wyss"),
                new Author("14#George Orwell"),
                new Author("15#Haruki Murakami"),
                new Author("16#Mikhail Bulgakov"),
                new Author("17#Ray Bradbury"),
                new Author("18#Herman Melville"),

            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category("1#Fantasy"),
                new Category("2#Krimi"),
                new Category("3#Gyermek könyv"),
                new Category("4#Regény"),
                new Category("5#Novella"),
                new Category("6#Felnőtt regény"),
                new Category("7#Ifjúsági regény"),
                new Category("8#Horror"),
                new Category("9#Thriller"),
                new Category("10#Dark Fantasy"),
                new Category("11#Kaland regény"),
                new Category("12#Romantikus kaland"),
                new Category("13#Sci-fi"),
                new Category("14#Szociális regény"),
                new Category("15#Társadalmi regény"),
                new Category("16#Misztikus krimi"),
                new Category("17#Dystopia"),
                new Category("18#Szatíra"),
                new Category("19#Esszé"),
                new Category("20#Dráma"),
                new Category("21#Életrajz"),
            });

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher("1#Random House"),
                new Publisher("2#Penguin Books"),
                new Publisher("3#HarperCollins"),
                new Publisher("4#Simon & Schuster"),
                new Publisher("5#Houghton Mifflin Harcourt"),
                new Publisher("6#Macmillan Publishers"),
                new Publisher("7#Scholastic"),
                new Publisher("8#Oxford University Press"),
                new Publisher("9#Cambridge University Press"),
                new Publisher("10#Vintage Books"),
                new Publisher("11#Bloomsbury"),
            });

            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book("1#Harry Potter és a Bölcsek Köve#1#1#6#9990"),
                new Book("2#Harry Potter és a Titkok Kamrája#1#1#6#9990"),
                new Book("3#Harry Potter és az Azkabani Fogoly#1#1#6#8990"),
                new Book("4#Harry Potter és a Tűz Serlege#1#1#6#7550"),
                new Book("5#Harry Potter és a Főnix Rendje#1#1#6#9990"),
                new Book("6#Harry Potter és a Félvér Herceg#1#1#6#8000"),
                new Book("7#Harry Potter és a Halál ereklyéi#1#1#6#5750"),
                new Book("8#Selyemfény#2#1#4#3500"),
                new Book("9#A Cuckoo's Calling#2#1#4#6500"),
                new Book("10#Career of Evil#2#1#3#5590"),
                new Book("11#Lethal White#2#1#3#4590"),
                new Book("12#Beedle, a Bárd Meséi#3#1#4#6500"),
                new Book("13#Murder on the Orient Express#2#2#2#5990"),
                new Book("14#A negyvenötös#2#2#2#7430"),
                new Book("15#Curtain: Poirot's Last Case#2#2#2#6590"),
                new Book("16#Tíz kicsi néger#2#2#2#8540"),
                new Book("17#Nem akarom elhinni#2#2#1#4990"),
                new Book("18#Death on the Nile#2#2#1#4750"),
                new Book("19#Murder in Mesopotamia#2#2#1#6660"),
                new Book("20#The ABC Murders#2#2#2#8540"),
                new Book("21#A Gyűrű Szövetsége#1#3#5#6320"),
                new Book("22#A két torony#1#3#5#4450"),
                new Book("23#A hobbit, avagy oda-vissza#1#3#5#3450"),
                new Book("24#A Silmarillion#1#3#1#2990"),
                new Book("25#A Gyűrűk Ura utószava#1#3#3#6220"),
                new Book("26#A hobbit további kalandjai#1#3#4#5550"),
                new Book("27#Háború és béke#4#4#6#2990"),
                new Book("28#Anna Karenina#4#4#6#3210"),
                new Book("29#Feltámadás#4#4#6#3490"),
                new Book("30#A Hajózási Hadakozás#5#4#5#1990"),
                new Book("31#Az életek könyvtára#6#5#9#6350"),
                new Book("32#Elsewhere#7#5#9#5980"),
                new Book("33#The Storied Life of A.J. Fikry#6#5#6#4780"),
                new Book("34#Memoirs of a Teenage Amnesiac#7#5#7#8200"),
                new Book("35#Az#8#6#6#10000"),
                new Book("36#A Zöld Míves#8#6#9#11450"),
                new Book("37#Misery#9#6#8#7550"),
                new Book("38#Carrie#8#6#10#6890"),
                new Book("39#Pet Sematary#8#6#10#8330"),
                new Book("40#Cujo#8#6#9#7990"),
                new Book("41#The Gunslinger#10#6#10#6500"),
                new Book("42#The Drawing of the Three#10#6#9#7440"),
                new Book("43#The Waste Lands#10#6#10#11320"),
                new Book("44#Wizard and Glass#10#6#10#12500"),
                new Book("45#Az ítélet#5#7#7#5000"),
                new Book("46#A per#4#7#6#3500"),
                new Book("47#A fű#5#7#6#5590"),
                new Book("48#A bűntetés#4#7#7#4320"),
                new Book("49#Az átváltozás#5#7#7#5400"),
                new Book("50#A pompei kastély#4#7#6#7550"),
                new Book("51#Tom Sawyer kalandjai#11#8#3#3500"),
                new Book("52#Huckleberry Finn kalandjai#11#8#4#2450"),
                new Book("53#Connecticuti Yankee a King Arthur udvarában#11#8#11#5500"),
                new Book("54#A fekete herceg és a fehér hercegnő#4#8#11#4590"),
                new Book("55#Én, Adam#4#8#11#3490"),
                new Book("56#Rebecca#9#9#9#4590"),
                new Book("57#My Cousin Rachel#9#9#8#13500"),
                new Book("58#Frenchman's Creek#12#9#7#4500"),
                new Book("59#Hungarian Gold#4#9#9#3500"),
                new Book("60#The Scapegoat#4#9#8#6450"),
                new Book("61#The House on the Strand#13#9#8#3450"),
                new Book("62#Oliver Twist#14#10#1#5550"),
                new Book("63#Nagy remények#14#10#1#4590"),
                new Book("64#Az árvák otthona#14#10#2#3450"),
                new Book("65#Nicholas Nickleby#15#10#2#6450"),
                new Book("66#Dombey és fia#15#10#1#3590"),
                new Book("67#Az Da Vinci-kód#16#11#11#11990"),
                new Book("68#Angyalok és démonok#16#11#11#9990"),
                new Book("69#Inferno#16#11#10#10500"),
                new Book("70#Az elveszett jelkép#16#11#10#7590"),
                new Book("71#A digitális erőd#16#11#10#8500"),
                new Book("72#Az elveszett szimbólum#16#11#10#6890"),
                new Book("73#Az Alapítvány#13#12#7#5650"),
                new Book("74#A tévelygő alapítvány#13#12#7#5450"),
                new Book("75#Robotok lázadása#13#12#6#3450"),
                new Book("76#Robotok hajnalteje#13#12#6#2500"),
                new Book("77#Csillagok háborúja#13#12#7#6550"),
                new Book("78#A gyönyörű világűr#13#12#6#3990"),
                new Book("79#Az Alapítvány előzményei#13#12#7#5990"),
                new Book("80#A svájci család Robinson#7#13#7#6590"),
                new Book("81#1984#17#14#3#7490"),
                new Book("82#Állatfarm#18#14#3#8220"),
                new Book("83#Coming Up for Air#4#14#4#6450"),
                new Book("84#Brave New World Revisited#19#14#4#3990"),
                new Book("85#Homage to Catalonia#19#14#3#5450"),
                new Book("86#Keep the Aspidistra Flying#4#14#4#8880"),
                new Book("87#Burmese Days#4#14#4#9230"),
                new Book("88#Norwegian Wood#4#15#8#5500"),
                new Book("89#Az ész életek#4#15#8#7650"),
                new Book("90#Kafka a tengerparton#4#15#8#3400"),
                new Book("91#Szputnyik szerelem#4#15#9#2500"),
                new Book("92#A kert, ahol a csendes szeletől tartanak#4#15#9#2450"),
                new Book("93#A vad bárányok táncolnak#4#15#8#3250"),
                new Book("94#A Mester és Margarita#1#16#11#2450"),
                new Book("95#Sátáni kórház#4#16#11#4320"),
                new Book("96#Fehér garda#4#16#10#3990"),
                new Book("97#Koboldok és halottak#5#16#10#3750"),
                new Book("98#A Szolncev ház#4#16#11#4200"),
                new Book("99#Molière#20#16#10#3330"),
                new Book("100#Fahrenheit 451#13#17#5#7890"),
                new Book("101#Something Wicked This Way Comes#1#17#5#8540"),
                new Book("102#Dandelion Wine#4#17#6#6550"),
                new Book("103#The Illustrated Man#13#17#5#8500"),
                new Book("104#Bradbury Chronicles#21#17#6#4590"),
                new Book("105#Moby Dick#11#18#1#4590"),
                new Book("106#Bartleby, a Scrivener#5#18#1#3550"),
                new Book("107#Billy Budd, Sailor#4#18#2#4650"),
                new Book("108#Typee#21#18#1#5650"),
                new Book("109#Omoo#21#18#2#7300"),
                new Book("110#Redburn#21#18#1#4300"),
                new Book("111#White-Jacket#4#18#2#6550"),
            });
        }
    }
}
