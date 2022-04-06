
using myApp.dataaccess.context;
using myApp.entitiy.LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libraryapp.dataaccess.Concrete.EfCore
{
    enum BookCategories
    {
        Adventure = 1, Classics, Fantasy, Horror, Detective, Mystery, Action, ComicBook, Romance, Autobiographies, History
    }

    public static class SeedDatabase
    {

        public static void SeedLibraryData()
        {


            using (var context = new LibraryContext())
            {
                if (true)
                {
                    Random random = new Random();

                    if (!context.Categories.Any())
                    {
                        List<Category> categories = new List<Category>();

                        for (int i = 1; i <= 10; i++)
                        {
                            categories.Add(new Category()
                            {
                                Id = random.Next(1, 11),
                                Name = Enum.GetName(typeof(BookCategories), i)

                            });
                        }
                        context.Categories.AddRange(categories);
                    }
                    context.SaveChanges();

                    if (context.Authors.Count() == 0)
                    {
                        List<Author> authors = new List<Author>();
                        for (int i = 1; i <= 100; i++)
                        {
                            authors.Add(new Author()
                            {
                                Id = i,
                                PictureUrl = i.ToString(),
                                FirstName = Faker.NameFaker.FirstName(),
                                LastName = Faker.NameFaker.LastName(),
                                Gender = Faker.BooleanFaker.Boolean()

                            });
                        }
                        context.Authors.AddRange(authors);
                    }
                    context.SaveChanges();

                    if (context.Books.Count() == 0)
                    {
                        List<Book> books = new List<Book>();
                        for (int i = 1; i <= 100; i++)
                        {
                            books.Add(
                                            new Book()
                                            {
                                                Id = i,
                                                PublishedDate = Faker.DateTimeFaker.DateTime(),
                                                Url = i.ToString(),
                                                Title = Faker.NameFaker.LastName(),
                                                Description = Faker.TextFaker.Sentence(),
                                                IsApproved = Faker.BooleanFaker.Boolean(),
                                                Rating = random.Next(1, 5),
                                                Price = Faker.NumberFaker.Number(5, 100),
                                                AuthorId = random.Next(1, 100),


                                                CategoryBooks = new List<CategoryBook>()
                                                {

                                                    new CategoryBook()
                                                    {
                                                        CategoryId=random.Next(1,10),
                                                        BookId=i
                                                    }
                                                }


                                            }
                                       );
                        }
                        context.Books.AddRange(books);
                    }
                    context.SaveChanges();


                    if (context.Publishers.Count() == 0)
                    {
                        List<Publisher> publishers = new List<Publisher>();

                        for (int i = 1; i <= 100; i++)
                        {
                            publishers.Add(new Publisher()
                            {
                                Id = i,
                                Name = Faker.CompanyFaker.Name(),
                                Phone = Faker.PhoneFaker.Phone(),
                                Email = Faker.InternetFaker.Email(),



                                PublisherBooks = new List<PublisherBook>()
                                {
                                    new PublisherBook()
                                    {
                                        PublisherId=random.Next(1,100),
                                        BookId=i
                                    }
                                }


                            });
                        }
                        context.Publishers.AddRange(publishers);
                    }
                    context.SaveChanges();

                    if (context.Adresses.Count() == 0)
                    {
                        List<Adress> adresses = new List<Adress>();
                        for (int i = 1; i <= 100; i++)
                        {

                            adresses.Add(

                            new Adress
                            {
                                Id = i,
                                Country = Faker.LocationFaker.Country(),
                                City = Faker.LocationFaker.City(),
                                State = Faker.LocationFaker.StreetName(),
                                Zip = Faker.LocationFaker.ZipCode(),
                                AuthorId = random.Next(1, 100)
                            }

                            );


                        }
                        context.Adresses.AddRange(adresses);
                    }
                    context.SaveChanges();





                }


            }




        }



    }
}
