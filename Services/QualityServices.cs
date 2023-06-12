namespace TestApi.Services;

using AutoMapper;
using TestApi.Models;
using TestApi.Helpers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public interface IQualityService
{
    Task<IEnumerable<TbQuality>> GetAll();
    Task Create([FromBody]TbQuality tbQuality);
    Task Delete(int id);
    Task Update(int id, [FromBody] TbQuality tbQuality);
}

public class QualityService : IQualityService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public QualityService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TbQuality>> GetAll()
    {
        return await _context.TbQualities.AsNoTracking().ToListAsync();
    }

    public async Task Create([FromBody] TbQuality tbQuality)
    {
        var quality = await _context.TbQualities.AddAsync(new TbQuality()
        {
            QaName = tbQuality.QaName,
            Isactive = tbQuality.Isactive
        });

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var quality = GetJobtype(id);
        _context.TbQualities.Remove(quality);
        await _context.SaveChangesAsync();
    }
    private TbQuality GetJobtype(int id)
    {
        var quality = _context.TbQualities.Find(id);
        if (quality == null) throw new KeyNotFoundException("User not found");
        return quality;
    }

    public async Task Update(int id, [FromBody] TbQuality tbQuality)
    {
        var quality = await _context.TbQualities.FirstOrDefaultAsync(t => t.Id == id);

        if (quality != null)
        {
            quality.QaName = tbQuality.QaName;
            quality.Isactive = tbQuality.Isactive;
            
            await _context.SaveChangesAsync();
        }
    }

}