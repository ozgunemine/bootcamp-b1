using net_core_bootcamp_b1_ozgun.DTOs;
using net_core_bootcamp_b1_ozgun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_ozgun.Services
{
    public interface IBookService
    {
        string Add(BookAddDto model);
        string Update(BookUpdateDto model);
        string Delete(Guid id);
        IList<BookGetDto> Get();
    }
    public class BookService : IBookService
    {
        private static readonly IList<Book> data = new List<Book>();
        public string Add(BookAddDto model)
        {
            Book entity = new Book
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };
            entity.Name = model.Name;
            entity.Author = model.Author;
            entity.Publisher = model.Publisher;
            entity.ReleaseDate = model.ReleaseDate;
            entity.Price = model.Price;

            data.Add(entity);
            return ("eklendi");
            
        }

        public string Update(BookUpdateDto model)
        {
            var entity = data.Where(x => !x.IsDeleted && x.Id == model.Id).FirstOrDefault();
            if (entity == null)
                return ($"{model.Id} 'e ait kayıt bulunamadı");

            entity.Name = model.Name;
            entity.Author = model.Author;
            entity.Publisher = model.Publisher;

            return ($"{entity.Id} 'e ait kayıt güncellendi");
        }

        public string Delete(Guid id)
        {
            var entity = data.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return ($"{id} 'e ait kayıt bulunamadı");

            entity.IsDeleted = true;

            return ($"{entity.Name} silindi");
        }


        public IList<BookGetDto> Get()
        {
            var result = new List<BookGetDto>();

            result = data
                .Where(x => !x.IsDeleted)
                .Select(s => new BookGetDto
                {
                    Id = s.Id,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    Author = s.Author,
                    Publisher = s.Publisher,
                    ReleaseDate = s.ReleaseDate,
                    Price = s.Price
                })
                .ToList();

            return result;
        }
    }
}
