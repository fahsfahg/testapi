namespace TestApi.Services;

using AutoMapper;
using TestApi.Models;
using TestApi.Helpers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public interface IJobtypeService
{
    Task<IEnumerable<TbJobtype>> GetAll();
    Task Create(TbJobtype model);
    Task Delete(int id);
    Task Update(int id, [FromBody] TbJobtype tbJobtype);
}

public class JobtypeService : IJobtypeService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public JobtypeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TbJobtype>> GetAll()
    {
        return await _context.TbJobtypes.ToListAsync();
    }

    public async Task Create(TbJobtype model)
    {
        var jobtype = _mapper.Map<TbJobtype>(model);

        _context.TbJobtypes.Add(jobtype);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var jobtype = GetJobtype(id);
        _context.TbJobtypes.Remove(jobtype);
        await _context.SaveChangesAsync();
    }
    private TbJobtype GetJobtype(int id)
    {
        var jobtype = _context.TbJobtypes.Find(id);
        if (jobtype == null) throw new KeyNotFoundException("User not found");
        return jobtype;
    }

    public async Task Update(int id, [FromBody] TbJobtype tbJobtype)
    {
        var jobtype = await _context.TbJobtypes.FirstOrDefaultAsync(t => t.Code == id);

        if (jobtype != null)
        {
            jobtype.Prefix = tbJobtype.Prefix;
            jobtype.Subtype = tbJobtype.Subtype;
            jobtype.LoadingTime = tbJobtype.LoadingTime;
            jobtype.MaxLoading = tbJobtype.MaxLoading;
            jobtype.UnloadingTime = tbJobtype.UnloadingTime;
            jobtype.MaxUnloading = tbJobtype.MaxUnloading;
            jobtype.Owner = tbJobtype.Owner;
            jobtype.Isdefault = tbJobtype.Isdefault;
            jobtype.Isactive = tbJobtype.Isactive;
            
            await _context.SaveChangesAsync();
        }
    }

}