using System.Collections.Generic;
using System.Data.Common;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class ArtistService : IArtistService
{
    public Task<Artist> CreateArtist(Artist artist)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Artist>> GetArtistsAsync()
    {   
        var seed = Environment.TickCount;
        var random = new Random(seed);
        List<Artist> list = new();
        for (int i = 0; i < 5; i++)
        {   
            var IdRandom = random.Next(1, 100);
            list.Add(new Artist()
            {
                Id = IdRandom,
                Name = "Name" + IdRandom,
                Label = "Label" + IdRandom,
                IsOnTour = (IdRandom % 2 == 0)
            });
        }
        return Task.FromResult(list.AsEnumerable());
    }

    public Task<Artist> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Artist> UpdateArtist(Artist artist)
    {
        throw new NotImplementedException();
    }
}